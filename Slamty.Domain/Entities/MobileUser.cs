using Slamty.Domain.Enums;

namespace Slamty.Domain.Entities
{
    public class MobileUser : BaseEntity
    {
        public string? ImageUrl { get; set; }
        public string NationalId { get; set; }
        public BloodTypes BloodType { get; set; }
        public bool IsDeaf { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public List<Report> Reports { get; set; } = new List<Report>();
        public List<Device> Devices { get; set; } = new List<Device>();
        public List<Location> Locations { get; set; } = new List<Location>();
        public Rating Rating { get; set; }
    }
}
