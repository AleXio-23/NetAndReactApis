using NorthernLight.Auth.Domain.Models.Auth;
using NorthernLight.Auth.Domain.Shared;

namespace NorthernLight.Auth.Application.Services.Auth.Register
{
    public interface IRegisterService
    {
        Task<ServiceResult<Guid>> Execute(RegisterDto registerDto, CancellationToken cancellationToken);
    }
}