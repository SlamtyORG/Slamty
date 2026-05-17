using MediatR;
using Slamty.Application.Auth.Dtos;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Auth.Commands.VerifyOTP
{
    public record VerifyOTPCommand(OTPVerificationDto OTPVerificationDto) : IRequest<ApiResponse<bool>>;


}
