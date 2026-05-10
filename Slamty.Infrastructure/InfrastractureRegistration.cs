using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Slamty.Core.Interfaces.Infrastracture;
using Slamty.Infrastracture.Persistence.AppIdentity;
using Slamty.Infrastracture.Persistence.Data;
using Slamty.Infrastracture.Persistence.Repository;

namespace Slamty.Infrastracture
{
    public static class InfrastractureRegistration
    {
        public static void AddInfrastractureRegister(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("IdentityConnection")));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        }
    }
}
