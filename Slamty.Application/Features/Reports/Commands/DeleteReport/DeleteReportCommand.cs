using MediatR;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Features.Reports.Commands.DeleteReport
{
    public record DeleteReportCommand(Guid ReportId) : IRequest<ApiResponse<bool>>;


}
