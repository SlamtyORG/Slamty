using Microsoft.AspNetCore.Mvc;
using Slamty.Application.Features.Reports.Queries.GetReportById;
using Slamty.Application.Features.Reports.Queries.GetReports;

namespace Slamty.Api.Controllers.Mobile
{
    public class ReportsController : BaseMobileApiController
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetReports(string userId)
        {
            var response = await Mediator.Send(new GetReportsQuery(userId));
            return HandleResult(response);
        }

        [HttpGet("details/{reportId}")]
        public async Task<IActionResult> GetReportById(string reportId)
        {
            var response = await Mediator.Send(new GetReportByIdQuery(reportId));
            return HandleResult(response);
        }
    }
}
