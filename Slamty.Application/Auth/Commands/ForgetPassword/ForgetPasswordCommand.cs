using MediatR;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Auth.Commands.ResetPassword
{
    public record ForgetPasswordCommand(string email) : IRequest<ApiResponse<bool>>;

}
