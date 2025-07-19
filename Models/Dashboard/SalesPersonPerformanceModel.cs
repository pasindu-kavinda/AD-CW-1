using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Models.Dashboard
{
    public class SalesPersonPerformanceModel
    {
        public string SalesPersonName { get; set; }
        public int JobsThisYear { get; set; }
        public int JobsLastYear { get; set; }
        public decimal RevenueThisYear { get; set; }
        public decimal RevenueLastYear { get; set; }
    }
}
