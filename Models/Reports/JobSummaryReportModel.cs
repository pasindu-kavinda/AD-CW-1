using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Models.Reports
{
    public class JobSummaryReportModel
    {
        public string JobNumber { get; set; }
        public string CustomerName { get; set; }
        public string PickupLocation { get; set; }
        public string DeliveryLocation { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ScheduledDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string Status { get; set; }
        public decimal EstimatedCost { get; set; }
        public decimal? ActualCost { get; set; }
        public string TransportUnit { get; set; }
        public string DriverName { get; set; }
        public decimal TotalWeight { get; set; }
        public decimal TotalVolume { get; set; }
        public int DaysToComplete { get; set; }
    }
}
