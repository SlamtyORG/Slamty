using Microsoft.AspNetCore.Mvc;

namespace Slamty.Api.Controllers.Mobile
{
    public class AuthController : BaseMobileApiController
    {
        [HttpGet]
        public ActionResult Login()
        {
            return Ok();
        }
    }
}
