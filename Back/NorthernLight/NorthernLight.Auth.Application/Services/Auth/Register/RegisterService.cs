using System.Security.Cryptography;
using System.Text;
using NorthernLight.Auth.Domain.Models.Auth;
using NorthernLight.Auth.Domain.Shared;
using NorthernLight.Auth.Persistence.Entities;
using NorthernLight.Auth.Persistence.Repository;
using NorthernLight.Auth.Shared.Exceptions;

namespace NorthernLight.Auth.Application.Services.Auth.Register
{
    public class RegisterService(IRepository<User> userRepository) : IRegisterService
    {
        public async Task<ServiceResult<Guid>> Execute(RegisterDto registerDto, CancellationToken cancellationToken)
        {
            var userName = registerDto.Email;

            if (await UserWithEmailExists(registerDto!.Email).ConfigureAwait(false))
            {
                throw new RecordExistsException("This email is registered");
            }

            if (await UserExists(userName).ConfigureAwait(false))
            {
                throw new RecordExistsException("Username is registered");
            }


            var hmac = new HMACSHA512();
            var newUser = new User()
            {
                Username = userName,
                Email = registerDto.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            await userRepository.Add(newUser, cancellationToken).ConfigureAwait(false);

            return ServiceResult<Guid>.SuccessResult(newUser.Id);
        }

        private async Task<bool> UserExists(string username)
        {
            return await userRepository
                .AnyAsync(x => x.Username.ToLower() == username)
                .ConfigureAwait(false);
        }

        private async Task<bool> UserWithEmailExists(string email)
        {
            return await userRepository.AnyAsync(x => x.Email == email).ConfigureAwait(false);
        }
    }
}