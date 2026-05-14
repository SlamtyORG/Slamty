using Microsoft.AspNetCore.Mvc;
using Slamty.Application.Auth.Command.Login;
using Slamty.Application.Auth.Commands.Registration;
using Slamty.Application.Auth.Commands.ResetPassword;
using Slamty.Application.Auth.Dtos;

namespace Slamty.Api.Controllers.Mobile
{
    public class AuthController : BaseMobileApiController
    {
        [HttpGet("Login")]
        public async Task<ActionResult> Login(LoginCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("ForgetPassword")]
        public async Task<ActionResult> ForgetPassword(string userEmail)
        {
            var response = await Mediator.Send(new ForgetPasswordCommand(userEmail));
            return Ok(response);
        }

        [HttpPost("ResetPassword")]
        public async Task<ActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            var response = await Mediator.Send(new ResetPasswordCommand(resetPasswordDto));
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegistrationCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
