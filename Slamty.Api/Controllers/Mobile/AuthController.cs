using Microsoft.AspNetCore.Mvc;
using Slamty.Application.Auth.Command.Login;

namespace Slamty.Api.Controllers.Mobile
{
    public class AuthController : BaseMobileApiController
    {
        [HttpGet]
        public async Task<ActionResult> Login(LoginCommand request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
