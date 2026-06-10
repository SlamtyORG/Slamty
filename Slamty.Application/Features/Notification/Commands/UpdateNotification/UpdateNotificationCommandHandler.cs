using MediatR;
using Microsoft.Extensions.Logging;
using Slamty.Application.Interfaces.Repositores;
using Slamty.Application.ResponseTypes;
using System.Net;

namespace Slamty.Application.Features.Notification.Commands.UpdateNotification
{
    public class UpdateNotificationCommandHandler : IRequestHandler<UpdateNotificationCommand, ApiResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateNotificationCommandHandler> _logger;

        public UpdateNotificationCommandHandler(IUnitOfWork unitOfWork, ILogger<UpdateNotificationCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ApiResponse<bool>> Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = await _unitOfWork.Repository<Domain.Entities.Notification>().GetByIdAsync(Guid.Parse(request.NotificationId));
            if (notification == null)
            {
                _logger.LogWarning("Notification with ID {NotificationId} not found.", request.NotificationId);
                return new ApiResponse<bool>(HttpStatusCode.NotFound, false, "Notification not found.");
            }
            notification.NotificationStatus = request.Status;
            _unitOfWork.Repository<Domain.Entities.Notification>().Update(notification);
            var result = await _unitOfWork.Complete();
            if (result <= 0)
            {
                _logger.LogError("Failed to update notification with ID {NotificationId}.", request.NotificationId);
                return new ApiResponse<bool>(HttpStatusCode.InternalServerError, false, "Failed to update notification.");
            }
            return new ApiResponse<bool>(HttpStatusCode.OK, true, "Notification updated successfully.");
        }
    }
}
