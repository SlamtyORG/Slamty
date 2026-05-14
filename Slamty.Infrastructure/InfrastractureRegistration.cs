using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Slamty.Application.Interfaces.Repositores;
using Slamty.Application.Interfaces.Servicese;
using Slamty.Infrastracture.Persistence.Repository;
using Slamty.Infrastructure.Data.Identity;
using Slamty.Infrastructure.Repository;
using Slamty.Infrastructure.Servicese;


namespace Slamty.Infrastracture
{
    public static class InfrastractureRegistration
    {
        public static void AddInfrastractureRegister(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("IdentityConnection")));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(ITokenService), typeof(TokenService));
            services.AddScoped(typeof(IEmailSenderService), typeof(EmailSenderService));
        }
    }
}
