using MediatR;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Features.Auth.Commands.ForgetPassword
{
    public record ForgetPasswordCommand(string Email) : IRequest<ApiResponse<bool>>;

}
