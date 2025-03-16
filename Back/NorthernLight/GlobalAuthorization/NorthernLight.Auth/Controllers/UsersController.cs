using Microsoft.AspNetCore.Mvc;
using NorthernLight.Auth.Application.Services.Users.User.ActivateOrDeactivateUser;
using NorthernLight.Auth.Application.Services.Users.User.GetUser;
using NorthernLight.Auth.Application.Services.Users.User.GetUsers;
using NorthernLight.Auth.Application.Services.Users.UserProfile.AddOrUpdateProfile;
using NorthernLight.Auth.Domain.Models.User;
using NorthernLight.Auth.Domain.Shared;

namespace NorthernLight.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UsersController(
        IGetUserService getUserService,
        IGetUsersService getUsersService,
        IActivateOrDeactivateUserService activateOrDeactivateUserService,
        IAddOrUpdateProfileService addOrUpdateProfileService) : ControllerBase
    {
        [HttpGet("GetUsers")]
        public async Task<ActionResult<ServiceResult<UserDTO>>> GetUsers(CancellationToken cancellationToken,
            [FromQuery] bool? isActive = null)
        {
            return Ok(await getUsersService.Execute(cancellationToken, isActive).ConfigureAwait(false));
        }

        [HttpGet("GetUserByUserId")]
        public async Task<ActionResult<ServiceResult<UserDTO>>> GetUserByUserId([FromQuery] Guid userId,
            CancellationToken cancellationToken)
        {
            return Ok(await getUserService.GetUserByUserId(userId, cancellationToken).ConfigureAwait(false));
        }

        [HttpGet("GetUserByEmail")]
        public async Task<ActionResult<ServiceResult<UserDTO>>> GetUserByEmail([FromQuery] string email,
            CancellationToken cancellationToken)
        {
            return Ok(await getUserService.GetUserByEmail(email, cancellationToken).ConfigureAwait(false));
        }

        [HttpGet("GetUserByUserName")]
        public async Task<ActionResult<ServiceResult<UserDTO>>> GetUserByUserName([FromQuery] string userName,
            CancellationToken cancellationToken)
        {
            return Ok(await getUserService.GetUserByUserName(userName, cancellationToken).ConfigureAwait(false));
        }

        [HttpGet("GetUserByPersonalNumber")]
        public async Task<ActionResult<ServiceResult<UserDTO>>> GetUserByPersonalNumber(
            [FromQuery] string personalNumber, CancellationToken cancellationToken)
        {
            return Ok(await getUserService.GetUserByPersonalNumber(personalNumber, cancellationToken)
                .ConfigureAwait(false));
        }

        [HttpPost("ActivateUser")]
        public async Task<ActionResult<ServiceResult<UserGuideRequest>>> ActivateUser(
            [FromBody] UserGuideRequest userGuideRequest, CancellationToken cancellationToken)
        {
            await activateOrDeactivateUserService.Activate(userGuideRequest.UserId, cancellationToken)
                .ConfigureAwait(false);
            return Ok(userGuideRequest);
        }

        [HttpPost("DeactivateUser")]
        public async Task<ActionResult<ServiceResult<UserGuideRequest>>> DeactivateUser(
            [FromBody] UserGuideRequest userGuideRequest, CancellationToken cancellationToken)
        {
            await activateOrDeactivateUserService.Deactivate(userGuideRequest.UserId, cancellationToken)
                .ConfigureAwait(false);
            return Ok(userGuideRequest);
        }

        [HttpPost("CreateOrUpdateUserprofile")]
        public async Task<ActionResult<ServiceResult<UserDTO>>> AddOrUpdateProfile(
            [FromBody] UserProfileDTO userProfileDto, CancellationToken cancellationToken)
        {
            return Ok(await addOrUpdateProfileService.Execute(userProfileDto, cancellationToken).ConfigureAwait(false));
        }
    }
}