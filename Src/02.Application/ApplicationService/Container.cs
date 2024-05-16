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

            return services;
        }
    }
}

