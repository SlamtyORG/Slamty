using MediatR;
using Slamty.Application.Auth.Dtos;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Auth.Commands.ResetPassword
{
    public record ResetPasswordCommand(ResetPasswordDto ResetPasswordDto) : IRequest<ApiResponse<bool>>;


}
