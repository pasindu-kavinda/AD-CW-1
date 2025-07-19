using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Models.Dashboard
{
    public class MonthlyJobsModel
    {
        public string Month { get; set; }
        public int Year { get; set; }
        public int? CompletedJobs { get; set; }
        public int? TotalJobs { get; set; }
        public decimal Revenue { get; set; }
    }
}
