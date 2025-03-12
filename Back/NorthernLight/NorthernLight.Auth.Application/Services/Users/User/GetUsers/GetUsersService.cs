using NorthernLight.Auth.Application.Services.Users.User.GetUsers.HelperMethods;
using NorthernLight.Auth.Domain.Models.User;
using NorthernLight.Auth.Domain.Shared;
using NorthernLight.Auth.Persistence.Repository;

namespace NorthernLight.Auth.Application.Services.Users.User.GetUsers
{
    public class GetUsersService(IRepository<Persistence.Entities.User> userRepository) : IGetUsersService
    {
        public async Task<ServiceResult<List<UserDTO>>> Execute(CancellationToken cancellationToken,
            bool? isActive = null)
        {
            var getUsers = userRepository.GetAllAsQueryable();

            if (isActive != null)
            {
                getUsers = getUsers.Where(x => x.IsActive == isActive);
            }

            var getUsersPayload = await UsersServiceHelperMethods.UsersPayloadAsync(getUsers, cancellationToken)
                .ConfigureAwait(false);

            return ServiceResult<List<UserDTO>>.SuccessResult(getUsersPayload);
        }
    }
}