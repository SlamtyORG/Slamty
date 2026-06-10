using MediatR;
using Slamty.Application.Features.Notification.Dtos;
using Slamty.Application.Interfaces.Repositores;
using Slamty.Application.ResponseTypes;
using Slamty.Domain.Specifications;
using System.Net;

namespace Slamty.Application.Features.Notification.Queries.GetNotifications
{
    public class GetNotificationsQueryHandler : IRequestHandler<GetNotificationsQuery, ApiResponse<List<NotificationDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetNotificationsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<List<NotificationDto>>> Handle(GetNotificationsQuery request, CancellationToken cancellationToken)
        {
            var notificationSpec = new GetNotificationByUserIdSpec(request.UserId);

            var notifications = await _unitOfWork.Repository<Domain.Entities.Notification>().GetBySpecAsync(notificationSpec);

            var notificationDtos = notifications.Select(n => new NotificationDto
            {
                Id = n.Id,
                Message = n.Message,
                Status = n.NotificationStatus,
                Date = n.Date
            }).ToList();

            return new ApiResponse<List<NotificationDto>>(HttpStatusCode.OK, notificationDtos, "Notifications retrieved successfully.");
        }
    }
}
