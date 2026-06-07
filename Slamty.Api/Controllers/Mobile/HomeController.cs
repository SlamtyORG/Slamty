using Microsoft.AspNetCore.Mvc;
using Slamty.Application.Features.Home.Commands;
using Slamty.Application.Features.Home.Queries.GetHome;
using Slamty.Application.Features.Home.Queries.GetNotifications;

namespace Slamty.Api.Controllers.Mobile
{
    public class HomeController : BaseMobileApiController
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetHome(string userId)
        {
            var response = await Mediator.Send(new GetHomeQuery(userId));
            return HandleResult(response);
        }

        [HttpGet("Notifications/{userId}")]
        public async Task<IActionResult> GetNotifications(string userId)
        {
            var response = await Mediator.Send(new GetNotificationsQuery(userId));
            return HandleResult(response);
        }

        [HttpDelete("Notifications/{notificationId}")]
        public async Task<IActionResult> DeleteNotifications(string notificationId)
        {
            var response = await Mediator.Send(new DeleteNotificationCommand(notificationId));
            return HandleResult(response);
        }
    }
}
