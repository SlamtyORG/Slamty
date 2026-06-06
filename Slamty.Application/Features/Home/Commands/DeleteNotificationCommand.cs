using MediatR;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Features.Home.Commands
{
    public record DeleteNotificationCommand(string NotificationId) : IRequest<ApiResponse<bool>>;
}
