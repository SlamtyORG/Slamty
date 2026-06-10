using MediatR;
using Slamty.Application.ResponseTypes;
using Slamty.Domain.Enums;

namespace Slamty.Application.Features.Notification.Commands.UpdateNotification
{
    public record UpdateNotificationCommand(string NotificationId, NotificationStatus Status) : IRequest<ApiResponse<bool>>;
}
