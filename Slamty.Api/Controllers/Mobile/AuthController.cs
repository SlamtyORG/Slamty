using Microsoft.AspNetCore.Mvc;
using Slamty.Application.Auth.Command.Login;
using Slamty.Application.Auth.Commands.Registration;
using Slamty.Application.Auth.Commands.ResetPassword;
using Slamty.Application.Auth.Commands.SendOTP;
using Slamty.Application.Auth.Commands.VerifyOTP;

namespace Slamty.Api.Controllers.Mobile
{
    public class AuthController : BaseMobileApiController
    {
        [HttpGet("Login")]
        public async Task<IActionResult> Login(LoginCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegistrationCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("SendOTP")]
        public async Task<IActionResult> SendOTP(SendOTPCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("VerifyOTP")]
        public async Task<IActionResult> VerifyOTP(VerifyOTPCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
