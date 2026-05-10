using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Slamty.Core.Entities;

namespace Slamty.Infrastracture.Persistence.AppIdentity
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<DashboardUser> DashboardUsers { get; set; }
        public DbSet<MobileUser> MobileUsers { get; set; }
    }
}
