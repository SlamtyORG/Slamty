using MediatR;
using Slamty.Application.ResponseTypes;
using Slamty.Domain.Enums;

namespace Slamty.Application.Features.Reports.Commands.CreateReport
{
    public record CreateReportCommand(double Lat, double Lng, string Description, List<string> Attachments, ReportTypes Type, DateTime Date) : IRequest<ApiResponse<string>>;

}
