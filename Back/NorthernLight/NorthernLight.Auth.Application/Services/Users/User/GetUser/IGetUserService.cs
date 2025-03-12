using NorthernLight.Auth.Domain.Models.User;
using NorthernLight.Auth.Domain.Shared;

namespace NorthernLight.Auth.Application.Services.Users.User.GetUser
{
    public interface IGetUserService
    {
        Task<ServiceResult<UserDTO>> GetUserByUserId(Guid userId, CancellationToken cancellationToken);
        Task<ServiceResult<UserDTO>> GetUserByEmail(string email, CancellationToken cancellationToken);
        Task<ServiceResult<UserDTO>> GetUserByUserName(string userName, CancellationToken cancellationToken);
        Task<ServiceResult<UserDTO>> GetUserByPersonalNumber(string personalNumber, CancellationToken cancellationToken);

    }
}
