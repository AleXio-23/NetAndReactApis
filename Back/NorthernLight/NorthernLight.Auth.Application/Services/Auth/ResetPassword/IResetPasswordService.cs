using NorthernLight.Auth.Domain.Shared;

namespace NorthernLight.Auth.Application.Services.Auth.ResetPassword
{
    public interface IResetPasswordService
    {
        Task<ServiceResult<string>> Execute(string usernameOrEmail, CancellationToken cancellationToken);
    }
}
