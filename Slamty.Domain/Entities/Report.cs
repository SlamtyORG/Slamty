using Slamty.Domain.Enums;

namespace Slamty.Domain.Entities
{
    public class Report : BaseEntity
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Description { get; set; }
        public List<string> Attachments { get; set; }
        public ReportTypes Type { get; set; }
        public bool ActiveNow { get; set; }
        public DateTime Date { get; set; }
        public ReportStatus Status { get; set; } = ReportStatus.Pending;
    }
}
