using MediatR;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Features.Auth.Commands.ResetPassword
{
    public record ResetPasswordCommand(string UserEmail, string ValidationToken, string NewPassword, string ConfirmNewPassword) : IRequest<ApiResponse<bool>>;


}
