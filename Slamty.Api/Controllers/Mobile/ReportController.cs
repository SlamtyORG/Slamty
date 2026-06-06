using Microsoft.AspNetCore.Mvc;
using Slamty.Application.Features.Reports.Commands.CreateReport;
using Slamty.Application.Features.Reports.Commands.DeleteReport;

namespace Slamty.Api.Controllers.Mobile
{
    public class ReportController : BaseMobileApiController
    {
        [HttpPost("CreateReport")]
        public async Task<IActionResult> CreateReport(CreateReportCommand command)
        {
            var response = await Mediator.Send(command);
            return HandleResult(response);
        }

        [HttpDelete("DeleteReport")]
        public async Task<IActionResult> DeleteReport(DeleteReportCommand command)
        {
            var response = await Mediator.Send(command);
            return HandleResult(response);
        }
    }
}
