using MediatR;
using Slamty.Application.Interfaces.Servicese;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Features.UserProfile.Commands.AddNotify
{
    public class AddNotifyCommandHandler : IRequestHandler<AddNotifyCommand, ApiResponse<bool>>
    {
        private readonly INotifyService _notifyService;

        public AddNotifyCommandHandler(INotifyService notifyService)
        {
            _notifyService = notifyService;
        }

        public async Task<ApiResponse<bool>> Handle(AddNotifyCommand request, CancellationToken cancellationToken)
        {
            await _notifyService.Interested(request.NotifyType, request.UserId);
            return new ApiResponse<bool>
            (
                System.Net.HttpStatusCode.OK,
                true,
                "Notification added successfully."
            );
        }
    }
}
