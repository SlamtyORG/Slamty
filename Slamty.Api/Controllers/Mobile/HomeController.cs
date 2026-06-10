using Microsoft.AspNetCore.Mvc;
using Slamty.Application.Features.Home.Dtos;
using Slamty.Application.Features.Home.Queries.GetHome;
using Slamty.Application.ResponseTypes;

namespace Slamty.Api.Controllers.Mobile
{
    public class HomeController : BaseMobileApiController
    {

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<HomeResponseDto>))]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetHome(string userId)
        {
            var response = await Mediator.Send(new GetHomeQuery(userId));
            return HandleResult(response);
        }
    }
}
