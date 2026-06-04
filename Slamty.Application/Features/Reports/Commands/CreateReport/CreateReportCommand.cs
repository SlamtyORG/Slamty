using MediatR;
using Slamty.Application.Features.Reports.Dtos;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Features.Reports.Commands.CreateReport
{
    public record CreateReportCommand(ReportDto ReportDto) : IRequest<ApiResponse>;
}
