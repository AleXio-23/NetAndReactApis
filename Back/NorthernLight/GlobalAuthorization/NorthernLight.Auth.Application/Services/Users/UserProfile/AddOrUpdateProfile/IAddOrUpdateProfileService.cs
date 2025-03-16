using NorthernLight.Auth.Domain.Models.User;
using NorthernLight.Auth.Domain.Shared;

namespace NorthernLight.Auth.Application.Services.Users.UserProfile.AddOrUpdateProfile
{
    public interface IAddOrUpdateProfileService
    {
        Task<ServiceResult<UserDTO>> Execute(UserProfileDTO userProfile, CancellationToken cancellationToken);
    }
}
