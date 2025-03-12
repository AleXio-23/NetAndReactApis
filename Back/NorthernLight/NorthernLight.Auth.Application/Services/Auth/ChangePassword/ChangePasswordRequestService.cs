using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NorthernLight.Auth.Domain.Models.Auth.ChangePassword;
using NorthernLight.Auth.Domain.Shared;
using NorthernLight.Auth.Persistence.Entities;
using NorthernLight.Auth.Persistence.Repository;
using NorthernLight.Auth.Shared.Constants;
using NorthernLight.Auth.Shared.GuardChecks;

namespace NorthernLight.Auth.Application.Services.Auth.ChangePassword
{
    public class ChangePasswordRequestService(IRepository<User> userRepository) : IChangePasswordRequestService
    {
        public async Task<ServiceResult<bool>> Execute(ChangePasswordWithTokenRequest request,
            CancellationToken cancellationToken)
        {
            Guard.NotNullOrEmpty(request.Token, nameof(request.Token), ExceptionMessageConstants.TOKEN_NOT_FOUND);
            if (!IsTokenValid(request.Token!))
            {
                throw new ArgumentException(ExceptionMessageConstants.INVALID_TOKEN, nameof(request.Token));
            }

            ValidatePasswords(request.Password, request.ConfirmPassword);

            var getUserEmailFromToken = ExtractEmailFromToken(request.Token!);
            var getUser = await userRepository.Where(x => x.Email == getUserEmailFromToken)
                .FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

            Guard.NotNull(getUser, nameof(getUser));

            var hmac = new HMACSHA512();


            getUser!.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password!));
            getUser!.PasswordSalt = hmac.Key;

            await userRepository.Update(getUser, cancellationToken).ConfigureAwait(false);

            return ServiceResult<bool>.SuccessResult(true);
        }

        private static void ValidatePasswords(string? password, string? repeatPassword)
        {
            Guard.NotNullOrEmpty(password, nameof(password), ExceptionMessageConstants.PASSWORD_CANT_BE_EMTPY);
            if (!password!.Equals(repeatPassword))
            {
                throw new ArgumentException(ExceptionMessageConstants.PASSWORDS_MISMATCH_ERROR);
            }
        }

        private static string ExtractEmailFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);


            var emailClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "email");

            if (emailClaim != null)
            {
                return emailClaim.Value;
            }
            else
            {
                throw new ArgumentException(ExceptionMessageConstants.INVALID_TOKEN);
            }
        }

        private static bool IsTokenValid(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            if (tokenHandler.ReadToken(token) is not JwtSecurityToken jwtToken)
            {
                throw new ArgumentException(ExceptionMessageConstants.TOKEN_NOT_FOUND);
            }

            var expiration = jwtToken.ValidTo;

            return expiration < DateTime.UtcNow;
        }
    }
}