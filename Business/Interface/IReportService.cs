using AD_CW_1.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Business.Interface
{
    interface IReportService
    {
        List<CustomerActivityReportModel> GetCustomerActivityReport(DateTime startDate, DateTime endDate, int? userId = null);
        List<JobSummaryReportModel> GetJobSummaryReport(DateTime startDate, DateTime endDate, int? userId = null);
        List<TransportUnitUtilizationReportModel> GetTransportUnitUtilizationReport(DateTime startDate, DateTime endDate);
        List<DriverPerformanceReportModel> GetDriverPerformanceReport(DateTime startDate, DateTime endDate);
        List<RevenueAnalysisReportModel> GetRevenueAnalysisReport(DateTime startDate, DateTime endDate, string groupBy = "month");

        bool ExportToPDF<T>(List<T> data, string reportTitle, string filePath);
        bool ExportToExcel<T>(List<T> data, string reportTitle, string filePath);
        bool ExportToExcelWithClosedXML<T>(List<T> data, string reportTitle, string filePath);
    }
}
