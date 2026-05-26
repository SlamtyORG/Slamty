namespace Slamty.Application.Features.Home.Dtos
{
    public sealed record HomeResponseDto
    {
        public List<ReportDto> LatestReports { get; set; }
    }
}
