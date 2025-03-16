using AuroraFlow.Application.Services.Auth.SignIn;
using AuroraFlow.Domain.Models.Users;
using AuroraFlow.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace AuroraFlow.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(ISignInService signInService) : ControllerBase
{
    [HttpPost("SignIn")]
    public async Task<ActionResult<ServiceResult<LoginResponse>>> SignIn([FromBody] LoginDto loginDto,
        CancellationToken cancellationToken)
    {
        await signInService.Execute(loginDto, cancellationToken).ConfigureAwait(false);

        return Ok();
    }
}