using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuroraFlow.Application.Infrastructure.RestServices;
using AuroraFlow.Application.Infrastructure.Settings;
using AuroraFlow.Domain.Models.Users;
using AuroraFlow.Domain.Shared;
using AuroraFlow.Persistance.Entities;
using AuroraFlow.Persistance.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RestEase;

namespace AuroraFlow.Application.Services.Auth.SignIn;

public class SignInService(
    IOptions<ConnectedApis> connectedApisOptions,
    IAuroraFlowUnitOfWork dbContext,
    IConfiguration configuration)
    : ISignInService
{
    private readonly ConnectedApis _connectedApis = connectedApisOptions.Value;

    public async Task<ServiceResult<LoginResponse>> Execute(LoginDto loginDto, CancellationToken cancellationToken)
    {
        var userAuthApi = RestClient.For<IUserAuthenticationServices>(_connectedApis.GlobalAuthorisation);
        var userResponse = await userAuthApi.SignInAsync(loginDto);

        if (userResponse.Success)
        {
            var getUserId = userResponse.Data?.User?.Id;
            if (getUserId == null)
            {
                throw new ArgumentException("USER_NOT_FOUND");
            }

            var getUser = await dbContext.Users.All.AsNoTracking()
                .FirstOrDefaultAsync(x => x.GlobalUserId == getUserId, cancellationToken: cancellationToken);

            if (getUser == null)
            {
                var user = new User()
                {
                    GlobalUserId = getUserId.Value
                };
                await dbContext.Users.AddAsync(user, cancellationToken);
            }

            var jwtSecret = configuration["Jwt:Secret"] ?? throw new ArgumentException("Jwt Secret Key not found");
            var generateToken = GenerateJwtToken(userResponse.Data?.User!, jwtSecret, false);
            var generateRefreshToken = GenerateJwtToken(userResponse.Data?.User!, jwtSecret, true);

            var checkRefreshTokenIfExists = await dbContext.RefreshToken
                .FirstOrDefaultAsync(x => x.UserId == getUserId, cancellationToken).ConfigureAwait(false);
            if (checkRefreshTokenIfExists != null)
            {
                checkRefreshTokenIfExists.Token = generateRefreshToken.Item1;
                checkRefreshTokenIfExists.ExpiryDate = generateRefreshToken.Item2;
            }
            else
            {
                var refreshTokenObject = new RefreshToken()
                {
                    UserId = getUserId,
                    Token = generateRefreshToken.Item1,
                    ExpiryDate = generateRefreshToken.Item2
                };
                await dbContext.RefreshToken.AddAsync(refreshTokenObject, cancellationToken).ConfigureAwait(false);
            }

            return ServiceResult<LoginResponse>.SuccessResult(new LoginResponse()
            {
                AccessToken = generateToken.Item1,
                User = userResponse.Data?.User
            });
        }

        throw new ArgumentException(userResponse.ErrorMessage ?? "AUTHORIZATION_ERROR");
    }

    private static (string, DateTime) GenerateJwtToken(UserDto user, string jwtSecret, bool isRefreshToken)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(jwtSecret ?? "");

        var expireDate = isRefreshToken ? DateTime.UtcNow.AddHours(24) : DateTime.UtcNow.AddMinutes(5);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
                new Claim(JwtRegisteredClaimNames.Sub, user.Username ?? string.Empty),
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