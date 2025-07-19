using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Models.Dashboard
{
    public class MonthlyTransportUnitsModel
    {
        public string Month { get; set; }
        public int Year { get; set; }
        public int? ActiveUnits { get; set; }
        public int TotalUnits { get; set; }
        public decimal? Utilization { get; set; }
    }
}
