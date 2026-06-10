using Microsoft.AspNetCore.Mvc;
using Slamty.Application.Features.Auth.Dtos;
using Slamty.Application.Features.UserProfile.Commands.AddNotify;
using Slamty.Application.Features.UserProfile.Commands.ChangePassword;
using Slamty.Application.Features.UserProfile.Commands.DeleteProfile;
using Slamty.Application.Features.UserProfile.Commands.RemoveNotify;
using Slamty.Application.Features.UserProfile.Commands.UpdateProfile;
using Slamty.Application.Features.UserProfile.Commands.UpdateProfileImage;
using Slamty.Application.Features.UserProfile.Dtos;
using Slamty.Application.Features.UserProfile.Queries.GetProfile;
using Slamty.Application.ResponseTypes;

namespace Slamty.Api.Controllers.Mobile
{
    public class ProfileController : BaseMobileApiController
    {

        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<ProfileResponseDto>))]
        public async Task<IActionResult> GetProfile(string userId)
        {
            var response = await Mediator.Send(new GetProfileQuery(userId));
            return HandleResult(response);
        }

        [HttpPut("UpdateProfile")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<ProfileResponseDto>))]
        public async Task<IActionResult> UpdateProfile(UpdateProfileCommand command)
        {
            var response = await Mediator.Send(command);
            return HandleResult(response);
        }

        [HttpPut("UpdateProfileImage")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<string>))]
        public async Task<IActionResult> UpdateProfileImage(UpdateProfileImageCommand command)
        {
            var response = await Mediator.Send(command);
            return HandleResult(response);
        }

        [HttpDelete("DeleteProfile")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<bool>))]
        public async Task<IActionResult> DeleteProfile(DeleteProfileCommand command)
        {
            var response = await Mediator.Send(command);
            return HandleResult(response);
        }

        [HttpPut("ChangePassword")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<AuthResponseDto>))]
        public async Task<IActionResult> ChangePassword(ChangePasswordCommand command)
        {
            var response = await Mediator.Send(command);
            return HandleResult(response);
        }

        [HttpPost("AddNotify")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<bool>))]
        public async Task<IActionResult> AddNotify(AddNotifyCommand command)
        {
            var response = await Mediator.Send(command);
            return HandleResult(response);
        }

        [HttpPost("RemoveNotify")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<bool>))]
        public async Task<IActionResult> RemoveNotify(RemoveNotifyCommand command)
        {
            var response = await Mediator.Send(command);
            return HandleResult(response);
        }
    }
}
