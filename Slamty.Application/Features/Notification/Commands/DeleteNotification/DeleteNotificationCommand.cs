using MediatR;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Features.Notification.Commands.DeleteNotification
{
    public record DeleteNotificationCommand(string NotificationId) : IRequest<ApiResponse<bool>>;
}
