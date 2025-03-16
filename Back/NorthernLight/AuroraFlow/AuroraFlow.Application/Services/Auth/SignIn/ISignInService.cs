using AuroraFlow.Domain.Models.Users;
using AuroraFlow.Domain.Shared;

namespace AuroraFlow.Application.Services.Auth.SignIn;

public interface ISignInService
{
    Task<ServiceResult<LoginResponse>> Execute(LoginDto loginDto, CancellationToken cancellationToken);
}