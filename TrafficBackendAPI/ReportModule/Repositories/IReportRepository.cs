using TrafficBackendAPI.ReportModule.Models;

namespace TrafficBackendAPI.ReportModule.Repositories
{
    internal interface IReportRepository
    {
        Task<Guid> AddReport(ReportModel reportModel);
        Task<ReportModel?> GetReportById(Guid reportId);
        Task<List<ReportModel>?> GetAllReports();
        Task UpdateReport(ReportModel reportModel);
        Task DeleteReport(Guid reportId);
    }
}
