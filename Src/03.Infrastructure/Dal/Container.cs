using Interfaces.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace Dal
{
    public static class Container
    {
        public static IServiceCollection AddDalServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped(typeof(ICud<>), typeof(Cud<>));
            services.AddScoped(typeof(IQuery<>), typeof(Query<>));

            string connection = Configuration.GetConnectionString("TodoDb") ?? "";
            ApplicationDbContext.ConnectionString = connection;
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

            return services;
        }
    }
}
