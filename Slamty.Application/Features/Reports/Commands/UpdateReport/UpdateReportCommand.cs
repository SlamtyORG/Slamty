using Microsoft.AspNetCore.Http;
using Slamty.Application.Features.Reports.Dtos;
using Slamty.Domain.Enums;

namespace Slamty.Application.Features.Reports.Commands.UpdateReport;

public class UpdateReportCommand : IRequest<ApiResponse<ReportResponseDto>>
{
#pragma warning disable CS8618
    public string Id { get; set; }
    public double Lat { get; set; }
    public double Lng { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public bool IsNow { get; set; }
    public ReportTypes Type { get; set; }

    public List<IFormFile>? Attatchments { get; set; }
}