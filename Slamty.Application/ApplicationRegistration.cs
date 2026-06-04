using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Slamty.Application.PipelineBehaviour;

namespace Slamty.Application
{
    public static class ApplicationRegistration
    {
        public static void AddApplicationRegister(this IServiceCollection services)
        {
            services.AddMediatR(opt =>
            opt.RegisterServicesFromAssembly(typeof(IAssemblyMarker).Assembly));
            services.AddValidatorsFromAssembly(typeof(IAssemblyMarker).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPipline<,>));
        }
    }
}
