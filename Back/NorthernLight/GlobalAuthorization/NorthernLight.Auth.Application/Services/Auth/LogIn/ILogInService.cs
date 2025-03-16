using NorthernLight.Auth.Domain.Models.Auth;
using NorthernLight.Auth.Domain.Shared;

namespace NorthernLight.Auth.Application.Services.Auth.LogIn
{
    public interface ILogInService
    {
        Task<ServiceResult<LoginResponse>> Exeute(LoginDto loginDto, CancellationToken cancellationToken);
    }
}
