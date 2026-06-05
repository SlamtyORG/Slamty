using Microsoft.AspNetCore.Mvc;
using Slamty.Application.Features.Reports.Commands.UpdateReport;

namespace Slamty.Api.Controllers.Mobile;

[Route("api/[controller]")]
[ApiController]
public class ReportsController : BaseMobileApiController
{
    [HttpPut("UpdateReport")]
    public async Task<IActionResult> UpdateReport(UpdateReportCommand request)
    {
        var response = await Mediator.Send(request);
        return HandleResult(response);
    }
}