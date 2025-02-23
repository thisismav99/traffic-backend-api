using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TrafficBackendAPI.UserModule.Repositories;

namespace TrafficBackendAPI.UserModule
{
    public static class UserModuleProgramExtension
    {
        public static void RegisterUserModule(this IServiceCollection services, string connectionString)
        {
            RegisterDatabase(services, connectionString);
            RegisterServices(services);
        }

        public static void RegisterDatabase(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<UserDbContext>(options =>
                options.UseSqlServer(connectionString)
            );
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
        }
    }
}
