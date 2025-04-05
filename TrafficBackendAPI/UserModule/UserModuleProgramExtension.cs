using Microsoft.Extensions.DependencyInjection;
using TrafficBackendAPI.UserModule.Services;

namespace TrafficBackendAPI.UserModule
{
    public static class UserModuleProgramExtension
    {
        public static void RegisterUserModule(this IServiceCollection services)
        {
            RegisterServices(services);
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining<UserModuleAssemblyMarker>());

            services.AddScoped<IUserService, UserService>();
        }
    }
}
