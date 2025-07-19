using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Models.Dashboard
{
    public class DashboardMetricsModel
    {
        public int TotalCustomers { get; set; }
        public int CustomerIncreasePercentage { get; set; }
        public int TotalTransportUnits { get; set; }
        public int TransportUnitsIncreasePercentage { get; set; }
        public int TotalCompletedJobs { get; set; }
        public int CompletedJobsIncreasePercentage { get; set; }
    }
}
