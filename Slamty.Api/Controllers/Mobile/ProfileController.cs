using Microsoft.AspNetCore.Mvc;
using Slamty.Application.Features.UserProfile.Commands.UpdateProfile;
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


    }
}
