using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TrafficBackendAPI.ReportModule.Repositories;
using TrafficBackendAPI.ReportModule.Services;

namespace TrafficBackendAPI.ReportModule
{
    public static class ReportModuleProgramExtension
    {
        public static void RegisterReportModule(this IServiceCollection services, string connectionString)
        {
            RegisterDatabase(services, connectionString);
            RegisterServices(services);
        }

        public static void RegisterDatabase(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ReportDbContext>(options =>
                options.UseSqlServer(connectionString)
            );
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IReportService, ReportService>();
        }
    }
}
