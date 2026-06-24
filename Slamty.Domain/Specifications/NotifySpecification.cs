using Slamty.Domain.Entities;
using Slamty.Domain.Enums;

namespace Slamty.Domain.Specifications
{
    public class NotifySpecification : BaseSpecification<Notify>
    {
        public NotifySpecification(NotifyType notifyType, Guid? UserId = null) : base(n => n.NotifyType == notifyType && ((UserId == null) || (n.UserId == UserId)))
        {
        }
    }
}
