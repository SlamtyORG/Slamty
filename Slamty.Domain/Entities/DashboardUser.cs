namespace Slamty.Domain.Entities
{
    public class DashboardUser : BaseEntity
    {
        public AppUser User { get; set; }
    }
}
