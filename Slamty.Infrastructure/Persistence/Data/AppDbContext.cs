using Microsoft.EntityFrameworkCore;

namespace Slamty.Infrastracture.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
