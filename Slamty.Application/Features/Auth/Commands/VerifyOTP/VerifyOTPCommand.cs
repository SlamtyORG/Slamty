using MediatR;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Features.Auth.Commands.VerifyOTP
{
    public record VerifyOTPCommand(string EmailAddress, string OTP) : IRequest<ApiResponse<bool>>;


}
