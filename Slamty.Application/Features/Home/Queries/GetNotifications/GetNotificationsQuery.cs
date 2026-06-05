using MediatR;
using Slamty.Application.Features.Home.Dtos;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Features.Home.Queries.GetNotifications
{
    public class GetNotificationsQuery : IRequest<ApiResponse<List<NotificationDto>>>
    {
        public GetNotificationsQuery(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; }
    }
}
