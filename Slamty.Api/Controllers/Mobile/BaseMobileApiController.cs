using Microsoft.AspNetCore.Mvc;
using Slamty.API.Controllers;
using System.Security.Claims;

namespace Slamty.Api.Controllers.Mobile
{
    [Route("api/mobile/[controller]")]
    [ApiController]
    public class BaseMobileApiController : BaseApiController
    {
        protected string? UserId
        {
            get
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                return userIdClaim;
            }
        }
    }
}
