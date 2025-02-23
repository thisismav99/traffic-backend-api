using Microsoft.EntityFrameworkCore;
using TrafficBackendAPI.ReportModule.ModelMappings;

namespace TrafficBackendAPI.ReportModule
{
    public class ReportDbContext : DbContext
    {
        #region Constructor
        public ReportDbContext(DbContextOptions<ReportDbContext> options) : base(options)
        {
            
        }
        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ReportModelMapping());
        }
        #endregion
    }
}
