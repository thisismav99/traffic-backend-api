using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TrafficBackendAPI.DatabaseModule.Repositories;

namespace TrafficBackendAPI.DatabaseModule
{
    public static class DatabaseModuleProgramExtension
    {
        public static void RegisterDatabaseModule(this IServiceCollection services, List<string> connectionStrings)
        {
            RegisterDatabases(services, connectionStrings);
            RegisterServices(services);
        }

        public static void RegisterDatabases(IServiceCollection services, List<string> connectionStrings)
        {
            foreach(var connectionString in connectionStrings) 
            {
                if(connectionString.Contains("UserDB")) 
                { 
                    services.AddDbContext<UserDbContext>(options =>
                        options.UseSqlServer(connectionString)
                            .UseLazyLoadingProxies()
                    ); 
                }
            }
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
        }
    }
}
