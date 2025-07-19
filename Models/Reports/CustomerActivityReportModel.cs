using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Models.Reports
{
    public class CustomerActivityReportModel
    {
        public string CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int TotalJobs { get; set; }
        public int CompletedJobs { get; set; }
        public int PendingJobs { get; set; }
        public int CancelledJobs { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal AverageJobValue { get; set; }
        public DateTime LastJobDate { get; set; }
        public string Status { get; set; }
    }
}
