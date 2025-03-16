using NorthernLight.Auth.Domain.Models.User;
using NorthernLight.Auth.Domain.Shared;

namespace NorthernLight.Auth.Application.Services.Users.User.GetUsers
{
    public interface IGetUsersService
    {
        Task<ServiceResult<List<UserDTO>>> Execute(CancellationToken cancellationToken, bool? isActive = null);
    }
}
