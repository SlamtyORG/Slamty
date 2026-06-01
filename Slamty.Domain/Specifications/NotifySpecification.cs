using Slamty.Domain.Entities;
using Slamty.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slamty.Domain.Specifications
{
    public class NotifySpecification : BaseSpecification<Notify>
    {
        public NotifySpecification(NotifyType notifyType,string? UserId = null) : base(n => n.NotifyType == notifyType &&((string.IsNullOrEmpty(UserId))|| (n.UserId == UserId)))
        {
        }
    }
}
