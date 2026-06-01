using MediatR;
using Slamty.Application.ResponseTypes;
using Slamty.Domain.Enums;

namespace Slamty.Application.Features.UserProfile.Commands.AddNotify
{
    public class AddNotifyCommand : IRequest<ApiResponse<bool>>
    {
        public NotifyType NotifyType { get; set; }
        public string UserId { get; set; }
    }
}
