using Microsoft.AspNetCore.Mvc;
using Slamty.Application.Features.UserProfile.Commands.AddNotify;
using Slamty.Application.Features.UserProfile.Commands.ChangePassword;
using Slamty.Application.Features.UserProfile.Commands.DeleteProfile;
using Slamty.Application.Features.UserProfile.Commands.RemoveNotify;
using Slamty.Application.Features.UserProfile.Commands.UpdateProfile;
using Slamty.Application.Features.UserProfile.Commands.UpdateProfileImage;
using Slamty.Application.Features.UserProfile.Queries.GetProfile;

namespace Slamty.Api.Controllers.Mobile
{
    public class ProfileController : BaseMobileApiController
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetProfile(string userId)
        {
            var response = await Mediator.Send(new GetProfileQuery(userId));
            return HandleResult(response);
        }

        [HttpPut("UpdateProfile")]
        public async Task<IActionResult> UpdateProfile(UpdateProfileCommand command)
        {
            var response = await Mediator.Send(command);
            return HandleResult(response);
        }

        [HttpPut("UpdateProfileImage")]
        public async Task<IActionResult> UpdateProfileImage(UpdateProfileImageCommand command)
        {
            var response = await Mediator.Send(command);
            return HandleResult(response);
        }

        [HttpDelete("DeleteProfile")]
        public async Task<IActionResult> DeleteProfile(DeleteProfileCommand command)
        {
            var response = await Mediator.Send(command);
            return HandleResult(response);
        }

        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordCommand command)
        {
            var response = await Mediator.Send(command);
            return HandleResult(response);
        }
        [HttpPost("AddNotify")]
        public async Task<IActionResult> AddNotify(AddNotifyCommand command)
        {
            var response = await Mediator.Send(command);
            return HandleResult(response);
        }

        [HttpPost("RemoveNotify")]
        public async Task<IActionResult> RemoveNotify(RemoveNotifyCommand command)
        {
            var response = await Mediator.Send(command);
            return HandleResult(response);
        }
    }
}
