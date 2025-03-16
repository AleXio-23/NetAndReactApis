using Microsoft.AspNetCore.Mvc;
using NorthernLight.Auth.Application.Services.Auth.ChangePassword;
using NorthernLight.Auth.Application.Services.Auth.GoogleLogIn;
using NorthernLight.Auth.Application.Services.Auth.LogIn;
using NorthernLight.Auth.Application.Services.Auth.Register;
using NorthernLight.Auth.Application.Services.Auth.ResetPassword;
using NorthernLight.Auth.Domain.Models.Auth;
using NorthernLight.Auth.Domain.Models.Auth.ChangePassword;
using NorthernLight.Auth.Domain.Shared;
using NorthernLight.Auth.Persistence.Entities;

namespace NorthernLight.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(
        IRegisterService registeredServices,
        ILogInService logInService,
        IGoogleLogInService googleLogInService,
        IResetPasswordService resetPasswordService,
        IChangePasswordRequestService changePasswordRequestService)
        : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<ServiceResult<User>>> RegisterNewUser([FromBody] RegisterDto registerDto,
            CancellationToken cancellationToken)
        {
            var result = await registeredServices.Execute(registerDto, cancellationToken).ConfigureAwait(false);

            return Ok(result);
        }


        [HttpPost("signIn")]
        public async Task<ActionResult<ServiceResult<LoginResponse>>> SignIn([FromBody] LoginDto loginDto,
            CancellationToken cancellationToken)
        {
            var result = await logInService.Exeute(loginDto, cancellationToken).ConfigureAwait(false);

            return Ok(result);
        }


        [HttpPost("GoogleSignIn")]
        public async Task<ActionResult<ServiceResult<LoginResponse>>> GoogleSignIn([FromBody] GoogleLoginDto login,
            CancellationToken cancellationToken)
        {
            var result = await googleLogInService.Execute(login.GoogleAccessToken, cancellationToken)
                .ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost("ResetPassword")]
        public async Task<ActionResult<ServiceResult<string>>> ResetPassword(
            [FromBody] Domain.Models.Auth.ResetPasswordRequest request, CancellationToken cancellationToken)
        {
            var result = await resetPasswordService.Execute(request.UserNameOrEmail, cancellationToken)
                .ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost("ChangePasswordByToken")]
        public async Task<ActionResult<ServiceResult<bool>>> ChangePasswordByToken(
            [FromBody] ChangePasswordWithTokenRequest request, CancellationToken cancellationToken)
        {
            var result = await changePasswordRequestService.Execute(request, cancellationToken).ConfigureAwait(false);

            return Ok(result);
        }
    }
}