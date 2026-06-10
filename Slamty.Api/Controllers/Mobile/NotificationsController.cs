using Microsoft.AspNetCore.Mvc;
using Slamty.Application.Features.Notification.Commands.DeleteNotification;
using Slamty.Application.Features.Notification.Commands.UpdateNotification;
using Slamty.Application.Features.Notification.Dtos;
using Slamty.Application.Features.Notification.Queries.GetNotifications;
using Slamty.Application.ResponseTypes;

namespace Slamty.Api.Controllers.Mobile
{
    public class NotificationsController : BaseMobileApiController
    {
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<NotificationDto>>))]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetNotifications(string userId)
        {
            var response = await Mediator.Send(new GetNotificationsQuery(userId));
            return HandleResult(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<bool>))]
        [HttpDelete("{notificationId}")]
        public async Task<IActionResult> DeleteNotifications(string notificationId)
        {
            var response = await Mediator.Send(new DeleteNotificationCommand(notificationId));
            return HandleResult(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<bool>))]
        [HttpPut("{notificationId}")]
        public async Task<IActionResult> UpdateNotifications(UpdateNotificationCommand requset)
        {
            var response = await Mediator.Send(requset);
            return HandleResult(response);
        }
    }
}
