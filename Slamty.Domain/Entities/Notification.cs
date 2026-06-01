using Slamty.Domain.Enums;

namespace Slamty.Domain.Entities
{
    public class Notification : BaseEntity
    {
        public string Message { get; set; }
        public NotificationStatus NotificationStatus { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
