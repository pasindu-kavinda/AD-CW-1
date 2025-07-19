using AD_CW_1.Models.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Business.Interface
{
    interface IDashboardService
    {
        DashboardMetricsModel GetDashboardMetrics();
        List<MonthlyJobsModel> GetMonthlyJobsData(int year);
        List<MonthlyTransportUnitsModel> GetMonthlyTransportUnitsData(int year);
        List<SalesPersonPerformanceModel> GetSalesPersonPerformance();
    }
}
