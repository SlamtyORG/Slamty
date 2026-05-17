using MediatR;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Auth.Commands.SendOTP
{
    public record SendOTPCommand(string EmailAddress) : IRequest<ApiResponse<bool>>;

}
