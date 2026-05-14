using Slamty.Domain.Enums;

namespace Slamty.Domain.Entities
{
    public class MobileUser : BaseEntity
    {
        public string ImageUrl { get; set; }
        public int NationalId { get; set; }
        public BloodTypes BloodType { get; set; }
        public bool IsDeaf { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
