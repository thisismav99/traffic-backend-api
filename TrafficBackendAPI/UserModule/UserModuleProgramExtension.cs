using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TrafficBackendAPI.UserModule.Repositories;
using TrafficBackendAPI.UserModule.Services;

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
            services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining<UserModuleAssemblyMarker>());

            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            services.AddScoped<IUserService, UserService>();
        }
    }
}
