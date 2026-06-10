using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Slamty.API.Controllers;

namespace Slamty.Api.Controllers.Mobile
{
    [Route("api/mobile/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class BaseMobileApiController : BaseApiController
    {
    }
}
