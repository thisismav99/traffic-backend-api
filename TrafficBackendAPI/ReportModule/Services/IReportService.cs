using TrafficBackendAPI.ReportModule.Models;

namespace TrafficBackendAPI.ReportModule.Services
{
    internal interface IReportService
    {
        Task<(ReportModel?, string)> AddReport(ReportModel report);
        Task<(ReportModel?, string)> GetReportById(Guid id);
        Task<(List<ReportModel>?, string)> GetReports();
    }
}
