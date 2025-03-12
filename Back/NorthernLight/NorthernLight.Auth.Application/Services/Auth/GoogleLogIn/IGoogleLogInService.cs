using NorthernLight.Auth.Domain.Models.Auth;
using NorthernLight.Auth.Domain.Shared;

namespace NorthernLight.Auth.Application.Services.Auth.GoogleLogIn
{
    public interface IGoogleLogInService
    {
        Task<ServiceResult<LoginResponse>> Execute(string googleAccessToken, CancellationToken cancellationToken);
    }
}
