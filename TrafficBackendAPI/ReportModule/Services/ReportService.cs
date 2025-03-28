using TrafficBackendAPI.ReportModule.Models;
using TrafficBackendAPI.ReportModule.Repositories;
using TrafficBackendAPI.ReportModule.Utilities;

namespace TrafficBackendAPI.ReportModule.Services
{
    internal class ReportService : IReportService
    {
        #region Variables
        private IReportRepository _reportRepository;
        #endregion

        #region Constructor
        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        #endregion

        #region Methods
        public async Task<(ReportModel?, string)> AddReport(ReportModel report)
        {
            try
            {
                var data = await _reportRepository.Add(report);

                if (data is not null)
                {
                    return (data, ResponseMessageHelper.ServiceCommandMessage(1));
                }
                else
                {
                    return (null, ResponseMessageHelper.ServiceCommandMessage(2));
                }
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }

        public async Task<(ReportModel?, string)> GetReportById(Guid id)
        {
            try
            {
                var data = await _reportRepository.GetById(id);

                if(data is not null)
                {
                    return (data, ResponseMessageHelper.ServiceQueryMessage(1));
                }
                else
                {
                    return (null, ResponseMessageHelper.ServiceQueryMessage(2));
                }
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }

        public async Task<(List<ReportModel>?, string)> GetReports()
        {
            try
            {
                var data = await _reportRepository.GetAll();

                if (data is not null)
                {
                    return (data, ResponseMessageHelper.ServiceQueryMessage(1));
                }
                else
                {
                    return (null, ResponseMessageHelper.ServiceQueryMessage(2));
                }
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }
        #endregion
    }
}
