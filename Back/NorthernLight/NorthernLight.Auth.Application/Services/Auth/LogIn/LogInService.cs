using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using NorthernLight.Auth.Domain.Models.Auth;
using NorthernLight.Auth.Domain.Shared;
using NorthernLight.Auth.Persistence.Entities;
using NorthernLight.Auth.Persistence.Repository;
using NorthernLight.Auth.Shared.Exceptions;

namespace NorthernLight.Auth.Application.Services.Auth.LogIn
{
    public class LogInService(
        IRepository<User> userRepository,
        IRepository<RefreshToken> refreshTokenRepository,
        IRepository<VwUserSignInResponse> vwUserSignInResponseRepository,
        IConfiguration configuration)
        : ILogInService
    {
        public async Task<ServiceResult<LoginResponse>> Exeute(LoginDto loginDto, CancellationToken cancellationToken)
        {
            var user = IsValidEmail(loginDto.EmailOrUsername ?? "")
                ? await userRepository
                    .SingleOrDefaultAsync(x => x.Email == loginDto.EmailOrUsername,
                        cancellationToken: cancellationToken).ConfigureAwait(false)
                : await userRepository
                    .SingleOrDefaultAsync(x => x.Username == (loginDto.EmailOrUsername ?? "").ToLower(),
                        cancellationToken: cancellationToken).ConfigureAwait(false);
            if (string.IsNullOrEmpty(loginDto.EmailOrUsername))
            {
                throw new ArgumentException("WRONG_USERNAME");
            }

            if (string.IsNullOrEmpty(loginDto.Password))
            {
                throw new ArgumentException("WRONG_PASSWORD");
            }

            if (user == null)
            {
                var errorMessage = $"User {loginDto.EmailOrUsername} not found";
                //await _userActionLogger.Execute(userId: null, actionName: "Auth", actionResult: "Failed", ErrorReason: errorMessage, cancellationToken: cancellationToken).ConfigureAwait(false);
                throw new ArgumentException("USER_NOT_FOUND");
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            if (computedHash.Where((t, i) => t != user.PasswordHash[i]).Any())
            {
                var errorMessage = $"User {loginDto.EmailOrUsername}: Incorrect password";
                //await _userActionLogger.Execute(userId: null, actionName: "Auth", actionResult: "Failed", ErrorReason: errorMessage, cancellationToken: cancellationToken).ConfigureAwait(false);
                throw new ArgumentException("WRONG_PASSWORD");
            }

            var jwtSecret = configuration["Jwt:Secret"] ?? throw new NotFoundException("Jwt Secret Key not found");

            var generateToken = GenerateJwtToken(user, jwtSecret, false);
            var generateRefreshToken = GenerateJwtToken(user, jwtSecret, true);

            var checkRefreshTokenIfExists = await refreshTokenRepository
                .FirstOrDefaultAsync(x => x.UserId == user.Id, cancellationToken).ConfigureAwait(false);
            if (checkRefreshTokenIfExists != null)
            {
                checkRefreshTokenIfExists.Token = generateRefreshToken.Item1;
                checkRefreshTokenIfExists.ExpiryDate = generateRefreshToken.Item2;
            }
            else
            {
                var refreshTokenObject = new RefreshToken()
                {
                    UserId = user.Id,
                    Token = generateRefreshToken.Item1,
                    ExpiryDate = generateRefreshToken.Item2
                };
                await refreshTokenRepository.Add(refreshTokenObject, cancellationToken).ConfigureAwait(false);
            }


            var getUser = await vwUserSignInResponseRepository.Where(x => x.Id == user.Id).Select(op =>
                new LoginResponse()
                {
                    AccessToken = generateToken.Item1
                }).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

            if (getUser == null)
            {
                var errorMessage = $"User in id {user.Id} no found";
                //await _userActionLogger.Execute(userId: user.Id, actionName: "Auth", actionResult: "Failed", ErrorReason: errorMessage, cancellationToken: cancellationToken).ConfigureAwait(false);
                throw new NotFoundException("USER_NOT_FOUND");
            }

            //await _userActionLogger.Execute(userId: user.Id, actionName: "Auth", actionResult: "Success", ErrorReason: null, cancellationToken: cancellationToken).ConfigureAwait(false);
            return ServiceResult<LoginResponse>.SuccessResult(getUser);
        }

        private static bool IsValidEmail(string email)
        {
            const string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            Regex regex = new(pattern);
            var match = regex.Match(email);
            return match.Success;
        }

        private static (string, DateTime) GenerateJwtToken(User user, string jwtSecret, bool isRefreshToken)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSecret ?? "");

            var expireDate = isRefreshToken ? DateTime.UtcNow.AddHours(24) : DateTime.UtcNow.AddMinutes(5);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),

                Expires = expireDate,
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return (jwtTokenHandler.WriteToken(token), expireDate);
        }
    }
}