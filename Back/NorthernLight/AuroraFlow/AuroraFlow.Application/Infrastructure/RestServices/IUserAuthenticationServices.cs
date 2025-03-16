using AuroraFlow.Domain.Models.Users;
using AuroraFlow.Domain.Shared;
using RestEase;

namespace AuroraFlow.Application.Infrastructure.RestServices;

public interface IUserAuthenticationServices
{
    
    [AllowAnyStatusCode]
    [Post("api/Auth/SignIn")]
    Task<ServiceResult<LoginResponse>> SignInAsync([Body] LoginDto loginDto);
}