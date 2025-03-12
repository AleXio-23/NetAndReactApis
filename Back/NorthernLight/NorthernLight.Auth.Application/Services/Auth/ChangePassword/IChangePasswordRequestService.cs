using NorthernLight.Auth.Domain.Models.Auth.ChangePassword;
using NorthernLight.Auth.Domain.Shared;

namespace NorthernLight.Auth.Application.Services.Auth.ChangePassword
{
    public interface IChangePasswordRequestService
    {
        Task<ServiceResult<bool>> Execute(ChangePasswordWithTokenRequest request, CancellationToken cancellationToken);
    }
}
