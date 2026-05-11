using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Slamty.Domain.Interfaces.Repositores;
using Slamty.Domain.Interfaces.Servicese;
using Slamty.Infrastructure.Data;
using Slamty.Infrastructure.Identity;
using Slamty.Infrastructure.Repository;
using Slamty.Infrastructure.Servicese;

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
            services.AddScoped(typeof(ITokenService), typeof(TokenService));
        }
    }
}
