using Slamty.Domain.Enums;

namespace Slamty.Domain.Entities
{
    public class Notify : BaseEntity
    {
        public NotifyType NotifyType { get; set; }
        public string UserId { get; set; }
    }
}
