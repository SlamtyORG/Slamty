using MediatR;
using Slamty.Application.Features.Auth.Dtos;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Features.UserProfile.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest<ApiResponse<AuthResponseDto>>
    {
        public string UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
