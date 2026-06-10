using Microsoft.AspNetCore.Mvc;
using Slamty.Application.Features.Home.Dtos;
using Slamty.Application.Features.Reports.Commands.CreateReport;
using Slamty.Application.Features.Reports.Commands.DeleteReport;
using Slamty.Application.Features.Reports.Queries.GetReportById;
using Slamty.Application.Features.Reports.Queries.GetReports;
using Slamty.Application.ResponseTypes;

namespace Slamty.Api.Controllers.Mobile
{
    public class ReportsController : BaseMobileApiController
    {

        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<ReportDto>>))]
        public async Task<IActionResult> GetReports(string userId)
        {
            var response = await Mediator.Send(new GetReportsQuery(userId));
            return HandleResult(response);
        }

        [HttpGet("details/{reportId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<ReportDto>))]
        public async Task<IActionResult> GetReportById(string reportId)
        {
            var response = await Mediator.Send(new GetReportByIdQuery(reportId));
            return HandleResult(response);
        }

        [HttpPost("CreateReport")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<string>))]
        public async Task<IActionResult> CreateReport(CreateReportCommand command)
        {
            var response = await Mediator.Send(command);
            return HandleResult(response);
        }

        [HttpDelete("DeleteReport")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<bool>))]
        public async Task<IActionResult> DeleteReport(DeleteReportCommand command)
        {
            var response = await Mediator.Send(command);
            return HandleResult(response);
        }
    }
}
