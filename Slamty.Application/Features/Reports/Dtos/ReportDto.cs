using Slamty.Domain.Contracts;
using Slamty.Domain.Enums;
using System.Text.Json.Serialization;

namespace Slamty.Application.Features.Reports.Dtos
{
    public sealed record ReportDto : ISoftDeletable
    {
        private DateTime _date;
        public double Lat { get; set; }
        public double Lng { get; set; }
        public required string Description { get; set; }
        public List<string> Attachments { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ReportTypes Type { get; set; }
        public bool ActiveNow { get; set; } = false;
        public DateTime Date
        {
            get
            {
                return _date;

            }
            set
            {
                if (ActiveNow) _date = DateTime.UtcNow;
                else _date = value;
            }
        }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
