namespace Slamty.Domain.Entities
{
    public class Report : BaseEntity
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
        public DateTime Date { get; set; }
        public bool IsNow { get; set; }
    }
}
