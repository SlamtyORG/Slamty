using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Slamty.Application.Features.Auth.Commands.ForgetPassword;
using Slamty.Application.Features.Auth.Commands.Login;
using Slamty.Application.Features.Auth.Commands.Logout;
using Slamty.Application.Features.Auth.Commands.RefreshToken;
using Slamty.Application.Features.Auth.Commands.Registration;
using Slamty.Application.Features.Auth.Commands.ResetPassword;
using Slamty.Application.Features.Auth.Commands.SendOTP;
using Slamty.Application.Features.Auth.Commands.VerifyOTP;
using Slamty.Application.Features.Auth.Dtos;
using Slamty.Application.ResponseTypes;

namespace Slamty.Api.Controllers.Mobile
{

    public class AuthController : BaseMobileApiController
    {
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<AuthResponseDto>))]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginCommand request)
        {
            var response = await Mediator.Send(request);
            return HandleResult(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<bool>))]
        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordCommand request)
        {
            var response = await Mediator.Send(request);
            return HandleResult(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<bool>))]
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand request)
        {
            var response = await Mediator.Send(request);
            return HandleResult(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<AuthResponseDto>))]
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken(RefreshTokenCommand request)
        {
            var response = await Mediator.Send(request);
            return HandleResult(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<AuthResponseDto>))]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegistrationCommand request)
        {
            var response = await Mediator.Send(request);
            return HandleResult(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<bool>))]
        [HttpPost("SendOTP")]
        [EnableRateLimiting("requestLimit")]
        public async Task<IActionResult> SendOTP(SendOTPCommand request)
        {
            var response = await Mediator.Send(request);
            return HandleResult(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<AuthResponseDto>))]
        [HttpPost("VerifyOTP")]
        [EnableRateLimiting("requestLimit")]
        public async Task<IActionResult> VerifyOTP(VerifyOTPCommand request)
        {
            var response = await Mediator.Send(request);
            return HandleResult(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<string>))]
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout(LogoutCommand request)
        {
            var response = await Mediator.Send(request);
            return HandleResult(response);
        }


    }
}
