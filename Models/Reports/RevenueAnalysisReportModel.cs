using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Models.Reports
{
    public class RevenueAnalysisReportModel
    {
        public DateTime Period { get; set; }
        public int TotalJobs { get; set; }
        public decimal EstimatedRevenue { get; set; }
        public decimal ActualRevenue { get; set; }
        public decimal RevenueVariance { get; set; }
        public decimal AverageJobValue { get; set; }
        public int NewCustomers { get; set; }
        public int RepeatCustomers { get; set; }
        public string TopCustomer { get; set; }
        public decimal TopCustomerRevenue { get; set; }
    }
}
