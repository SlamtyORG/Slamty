using Microsoft.AspNetCore.Mvc;
using Slamty.Application.ResponseTypes;
using System.Net;

namespace Slamty.API.Controllers
{
    [ApiController]
    [Route("home")]
    public class HomeController : BaseApiController
    {
        [HttpGet]
        public IActionResult GetHome()
        {
            var response = new ApiResponse<string>(
                HttpStatusCode.OK,
                "Slamty API is running");

            return HandleResult(response);
        }
    }
}
