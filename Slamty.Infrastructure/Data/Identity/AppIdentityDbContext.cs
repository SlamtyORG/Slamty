using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Slamty.Domain.Entities;
using Slamty.Infrastructure.Data.Configurations.User;

namespace Slamty.Infrastructure.Data.Identity
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) :
            base(options)
        {
        }
        public DbSet<DashboardUser> DashboardUsers { get; set; }
        public DbSet<MobileUser> MobileUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(UserConfig).Assembly);
        }

    }
}
