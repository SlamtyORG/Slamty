using Slamty.Domain.Entities;

namespace Slamty.Domain.Specifications
{
    public class GetNotificationByUserIdSpec : BaseSpecification<Notification>
    {
        public GetNotificationByUserIdSpec(string userId) : base(n => n.UserId == userId)
        {
            OrderBy = n => n.Date;
        }
    }
}
