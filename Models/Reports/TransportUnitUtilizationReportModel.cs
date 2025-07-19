using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Models.Reports
{
    public class TransportUnitUtilizationReportModel
    {
        public string UnitNumber { get; set; }
        public string TruckNumber { get; set; }
        public string TruckModel { get; set; }
        public string DriverName { get; set; }
        public string AssistantName { get; set; }
        public int TotalJobs { get; set; }
        public int CompletedJobs { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalWeight { get; set; }
        public decimal TotalVolume { get; set; }
        public int UtilizationDays { get; set; }
        public decimal UtilizationPercentage { get; set; }
        public string Status { get; set; }
    }
}
