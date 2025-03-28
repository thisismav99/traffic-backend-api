using TrafficBackendAPI.ReportModule.Models;

namespace TrafficBackendAPI.ReportModule.Repositories
{
    internal interface IReportRepository
    {
        Task<ReportModel?> Add(ReportModel reportModel);
        Task<ReportModel?> GetById(Guid reportId);
        Task<List<ReportModel>?> GetAll();
        Task Update(ReportModel reportModel);
        Task Delete(Guid reportId);
    }
}
