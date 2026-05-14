using MediatR;
using Microsoft.AspNetCore.Mvc;
using Slamty.Application.Auth.Command.Login;
using Slamty.Application.Auth.Commands.ResetPassword;
using Slamty.Application.Auth.Dtos;

namespace Slamty.Api.Controllers.Mobile
{
    public class AuthController : BaseMobileApiController
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult> Login(LoginCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult> ForgetPassword(string userEmail)
        {
            var response = await _mediator.Send(new ForgetPasswordCommand(userEmail));
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            var response = await _mediator.Send(new ResetPasswordCommand(resetPasswordDto));
            return Ok(response);
        }
    }
}
