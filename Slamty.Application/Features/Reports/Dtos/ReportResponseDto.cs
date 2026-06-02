using Slamty.Domain.Enums;

namespace Slamty.Application.Features.Reports.Dtos;

public class ReportResponseDto
{
#pragma warning disable CS8618
    public string Id { get; set; }
    public double Lat { get; set; }
    public double Lng { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public bool IsNow { get; set; }
    public ReportTypes Type { get; set; }
}