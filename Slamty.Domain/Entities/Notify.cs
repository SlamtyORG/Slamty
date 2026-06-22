using Slamty.Domain.Enums;

namespace Slamty.Domain.Entities
{
    public class Notify : BaseEntity
    {
        public NotifyType NotifyType { get; set; }
        public Guid UserId { get; set; }
    }
}
