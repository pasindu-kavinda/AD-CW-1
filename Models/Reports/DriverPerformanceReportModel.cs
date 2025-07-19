using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Models.Reports
{
    public class DriverPerformanceReportModel
    {
        public string DriverName { get; set; }
        public string LicenseNumber { get; set; }
        public string Phone { get; set; }
        public int TotalJobs { get; set; }
        public int CompletedJobs { get; set; }
        public int OnTimeJobs { get; set; }
        public decimal CompletionRate { get; set; }
        public decimal OnTimeRate { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal AverageJobValue { get; set; }
        public int ActiveDays { get; set; }
        public string CurrentStatus { get; set; }
    }
}
