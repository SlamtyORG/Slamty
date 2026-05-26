using Slamty.Domain.Enums;

namespace Slamty.Application.Features.Home.Dtos
{
    public sealed record ReportDto
    {
        public string Id { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Description { get; set; }
        public List<string> Attachments { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public bool IsNow { get; set; }
    }
}
