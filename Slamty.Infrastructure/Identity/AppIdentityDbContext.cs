using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Slamty.Domain.Entities;

namespace Slamty.Infrastructure.Identity
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
