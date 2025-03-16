using Microsoft.EntityFrameworkCore;
using NorthernLight.Auth.Application.Services.Users.User.GetUser.HelperMethods;
using NorthernLight.Auth.Domain.Models.User;
using NorthernLight.Auth.Domain.Shared;
using NorthernLight.Auth.Persistence.Repository;
using NorthernLight.Auth.Shared.Exceptions;

namespace NorthernLight.Auth.Application.Services.Users.User.GetUser
{
    public class GetUserService(IRepository<Persistence.Entities.User> userRepository) : IGetUserService
    {
        public async Task<ServiceResult<UserDTO>> GetUserByEmail(string email, CancellationToken cancellationToken)
        {
            var getUser = userRepository.Where(x => x.Email == email)
                .Include(x => x.UserProfile)
                .Include(x => x.UserJobPositions)
                    .ThenInclude(x => x.Department)
                .Include(x => x.UserJobPositions)
                    .ThenInclude(x => x.Position);
            var userPayload = await UserServiceHelperMethods.UserPayloadAsync(getUser, cancellationToken).ConfigureAwait(false);
            return userPayload == null
                ? throw new NotFoundException("USER_IN_THIS_MAIL_NOT_FOUND")
                : ServiceResult<UserDTO>.SuccessResult(userPayload);
        }

        public async Task<ServiceResult<UserDTO>> GetUserByPersonalNumber(string personalNumber, CancellationToken cancellationToken)
        {
            var getUser = userRepository.GetIncluding(x => x.UserProfile).Where(x => x.UserProfile != null && x.UserProfile.PersonalNumber == personalNumber)
                  .Include(x => x.UserProfile)
                .Include(x => x.UserJobPositions)
                    .ThenInclude(x => x.Department)
                .Include(x => x.UserJobPositions)
                    .ThenInclude(x => x.Position);
            var userPayload = await UserServiceHelperMethods.UserPayloadAsync(getUser, cancellationToken).ConfigureAwait(false);
            return userPayload == null
                ? throw new NotFoundException("USER_IN_THIS_MAIL_NOT_FOUND")
                : ServiceResult<UserDTO>.SuccessResult(userPayload);
        }

        public async Task<ServiceResult<UserDTO>> GetUserByUserId(Guid userId, CancellationToken cancellationToken)
        {
            var getUser = userRepository.Where(x => x.Id == userId).Include(x => x.UserProfile)
                  .Include(x => x.UserProfile)
                .Include(x => x.UserJobPositions)
                    .ThenInclude(x => x.Department)
                .Include(x => x.UserJobPositions)
                    .ThenInclude(x => x.Position);
            var userPayload = await UserServiceHelperMethods.UserPayloadAsync(getUser, cancellationToken).ConfigureAwait(false);
            return userPayload == null
                ? throw new NotFoundException("USER_IN_THIS_MAIL_NOT_FOUND")
                : ServiceResult<UserDTO>.SuccessResult(userPayload);
        }

        public async Task<ServiceResult<UserDTO>> GetUserByUserName(string userName, CancellationToken cancellationToken)
        {
            var getUser = userRepository.Where(x => x.Username == userName).Include(x => x.UserProfile)
                  .Include(x => x.UserProfile)
                .Include(x => x.UserJobPositions)
                    .ThenInclude(x => x.Department)
                .Include(x => x.UserJobPositions)
                    .ThenInclude(x => x.Position);
            var userPayload = await UserServiceHelperMethods.UserPayloadAsync(getUser, cancellationToken).ConfigureAwait(false);
            return userPayload == null
                ? throw new NotFoundException("USER_IN_THIS_MAIL_NOT_FOUND")
                : ServiceResult<UserDTO>.SuccessResult(userPayload);
        }


    }
}
