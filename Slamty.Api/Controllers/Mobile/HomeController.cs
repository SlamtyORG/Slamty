using Microsoft.AspNetCore.Mvc;
using Slamty.Application.Features.Home.Queries.GetHome;

namespace Slamty.Api.Controllers.Mobile
{
    public class HomeController : BaseMobileApiController
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetHome(string userId)
        {
            var response = await Mediator.Send(new GetHomeQuery(userId));
            return HandleResult(response);
        }
    }
}
