using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Slamty.Domain.Entities;

namespace Slamty.Infrastructure.Data.Configurations.User
{
    public class UserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasQueryFilter(u => !u.IsDeleted);
        }
    }
}
