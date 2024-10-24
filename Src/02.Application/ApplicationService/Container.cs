using ApplicationService.Behaviours;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ApplicationService
{
    public static class ApplicationAssembly
    {
        public static readonly Assembly Instance = typeof(ApplicationAssembly).Assembly;
    }
    public static class Container
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddMediatR(configure =>
            {
                configure.RegisterServicesFromAssembly(ApplicationAssembly.Instance);
            });
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}

