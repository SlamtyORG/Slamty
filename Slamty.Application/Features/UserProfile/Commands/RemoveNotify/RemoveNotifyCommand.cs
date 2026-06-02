using MediatR;
using Slamty.Application.ResponseTypes;
using Slamty.Domain.Enums;

namespace Slamty.Application.Features.UserProfile.Commands.RemoveNotify
{
    public class RemoveNotifyCommand : IRequest<ApiResponse<bool>>
    {
        public NotifyType NotifyType { get; set; }
        public string UserId { get; set; }
    }
}
