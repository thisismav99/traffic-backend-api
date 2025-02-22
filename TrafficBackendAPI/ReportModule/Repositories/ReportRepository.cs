using Microsoft.EntityFrameworkCore;
using TrafficBackendAPI.ReportModule.Models;

namespace TrafficBackendAPI.ReportModule.Repositories
{
    internal class ReportRepository : IReportRepository
    {
        #region Variables
        private readonly ReportDbContext _reportDbContext;
        #endregion

        #region Constructor
        public ReportRepository(ReportDbContext reportDbContext)
        {
            _reportDbContext = reportDbContext;
        }
        #endregion

        #region Methods
        public async Task<Guid> AddReport(ReportModel reportModel)
        {
            await _reportDbContext.Set<ReportModel>().AddAsync(reportModel);
            await _reportDbContext.SaveChangesAsync();

            return reportModel.Id;
        }

        public async Task DeleteReport(Guid reportId)
        {
            var report = await GetReportById(reportId);
            
            if(report is not null)
            {
                _reportDbContext.Set<ReportModel>().Remove(report);
                await _reportDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<ReportModel>?> GetAllReports()
        {
            return await _reportDbContext.Set<ReportModel>().ToListAsync();
        }

        public async Task<ReportModel?> GetReportById(Guid reportId)
        {
           return await _reportDbContext.Set<ReportModel>().FindAsync(reportId);
        }

        public async Task UpdateReport(ReportModel reportModel)
        {
            _reportDbContext.Set<ReportModel>().Entry(reportModel).State = EntityState.Modified;
            await _reportDbContext.SaveChangesAsync();
        }
        #endregion
    }
}
