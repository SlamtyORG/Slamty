using MediatR;
using Slamty.Application.Interfaces.Servicese;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Features.UserProfile.Commands.RemoveNotify
{
    public class RemoveNotifyCommandHandler : IRequestHandler<RemoveNotifyCommand, ApiResponse<bool>>
    {
        private readonly INotifyService _notifyService;

        public RemoveNotifyCommandHandler(INotifyService notifyService)
        {
            _notifyService = notifyService;
        }

        public async Task<ApiResponse<bool>> Handle(RemoveNotifyCommand request, CancellationToken cancellationToken)
        {
            await _notifyService.NotInterested(request.NotifyType, request.UserId);
            return new ApiResponse<bool>
            (
                System.Net.HttpStatusCode.OK,
                true,
                "Notification removed successfully."
            );
        }
    }
}
