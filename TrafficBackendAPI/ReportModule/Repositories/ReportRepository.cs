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
        public async Task<ReportModel?> Add(ReportModel reportModel)
        {
            await _reportDbContext.Set<ReportModel>().AddAsync(reportModel);
            await _reportDbContext.SaveChangesAsync();

            return reportModel;
        }

        public async Task Delete(Guid reportId)
        {
            var report = await GetById(reportId);
            
            if(report is not null)
            {
                _reportDbContext.Set<ReportModel>().Remove(report);
                await _reportDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<ReportModel>?> GetAll(List<Guid> reportListId, bool asNoTracking)
        {
            var result = new List<ReportModel>();

            if(reportListId is null && !asNoTracking)
            {
                result = await _reportDbContext.Set<ReportModel>().ToListAsync();
            }
            else if(reportListId is null && asNoTracking)
            {
                result = await _reportDbContext.Set<ReportModel>().AsNoTracking().ToListAsync();
            }
            else if(reportListId is not null && !asNoTracking)
            {
                result = await _reportDbContext.Set<ReportModel>()
                    .Where(x => reportListId.Contains(x.Id))
                    .ToListAsync();
            }
            else if(reportListId is not null && asNoTracking)
            {
                result = await _reportDbContext.Set<ReportModel>()
                    .Where(x => reportListId.Contains(x.Id))
                    .AsNoTracking()
                    .ToListAsync();
            }

            return result;
        }

        public async Task<ReportModel?> GetById(Guid reportId)
        {
           return await _reportDbContext.Set<ReportModel>().FindAsync(reportId);
        }

        public async Task Update(ReportModel reportModel)
        {
            _reportDbContext.Set<ReportModel>().Entry(reportModel).State = EntityState.Modified;
            await _reportDbContext.SaveChangesAsync();
        }
        #endregion
    }
}
