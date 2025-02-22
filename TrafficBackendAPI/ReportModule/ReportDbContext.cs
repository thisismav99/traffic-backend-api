using Microsoft.EntityFrameworkCore;
using TrafficBackendAPI.ReportModule.ModelMappings;

namespace TrafficBackendAPI.ReportModule
{
    internal class ReportDbContext : DbContext
    {
        #region Constructor
        public ReportDbContext()
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
