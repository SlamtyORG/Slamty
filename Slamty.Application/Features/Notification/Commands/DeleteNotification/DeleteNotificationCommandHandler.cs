using MediatR;
using Slamty.Application.Interfaces.Repositores;
using Slamty.Application.ResponseTypes;
using System.Net;

namespace Slamty.Application.Features.Notification.Commands.DeleteNotification
{
    public class DeleteNotificationCommandHandler : IRequestHandler<DeleteNotificationCommand, ApiResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteNotificationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<bool>> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = await _unitOfWork.Repository<Domain.Entities.Notification>().GetByIdAsync(Guid.Parse(request.NotificationId));

            if (notification == null)
                return new ApiResponse<bool>(HttpStatusCode.NotFound, false, "Notification not found");


            _unitOfWork.Repository<Domain.Entities.Notification>().Delete(notification);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
                return new ApiResponse<bool>(HttpStatusCode.InternalServerError, false, "Failed to delete notification");


            return new ApiResponse<bool>(HttpStatusCode.OK, true, "Notification deleted successfully");
        }
    }
}
