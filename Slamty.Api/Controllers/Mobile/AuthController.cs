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

namespace Slamty.Api.Controllers.Mobile
{
    public class AuthController : BaseMobileApiController
    {
        [HttpGet("Login")]
        public async Task<IActionResult> Login(LoginCommand request)
        {
            var response = await Mediator.Send(request);
            return HandleResult(response);
        }

        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordCommand request)
        {
            var response = await Mediator.Send(request);
            return HandleResult(response);
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand request)
        {
            var response = await Mediator.Send(request);
            return HandleResult(response);
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken(RefreshTokenCommand request)
        {
            var response = await Mediator.Send(request);
            return HandleResult(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegistrationCommand request)
        {
            var response = await Mediator.Send(request);
            return HandleResult(response);
        }

        [HttpPost("SendOTP")]
        [EnableRateLimiting("requestLimit")]
        public async Task<IActionResult> SendOTP(SendOTPCommand request)
        {
            var response = await Mediator.Send(request);
            return HandleResult(response);
        }

        [HttpPost("VerifyOTP")]
        [EnableRateLimiting("requestLimit")]
        public async Task<IActionResult> VerifyOTP(VerifyOTPCommand request)
        {
            var response = await Mediator.Send(request);
            return HandleResult(response);
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout(LogoutCommand request)
        {
            var response = await Mediator.Send(request);
            return HandleResult(response);
        }


    }
}
