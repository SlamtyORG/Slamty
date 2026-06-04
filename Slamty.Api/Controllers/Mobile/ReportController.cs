using Microsoft.AspNetCore.Mvc;
using Slamty.Application.Features.Reports.Commands.CreateReport;

namespace Slamty.Api.Controllers.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : BaseMobileApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateReport(CreateReportCommand command)
        {
            var response = await Mediator.Send(command);
            return HandleResult(response);
        }
    }
}
