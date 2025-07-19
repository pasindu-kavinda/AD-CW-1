using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Models
{
    public class JobModel
    {
        public int Id { get; set; }
        public string JobNumber { get; set; }
        public int CustomerId { get; set; }
        public string PickupLocation { get; set; }
        public string DeliveryLocation { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ScheduledDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string Description { get; set; }
        public decimal EstimatedCost { get; set; }
        public decimal? ActualCost { get; set; }
        public string Status { get; set; } = "1";
        public int? TransportUnitId { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public string CustomerName { get; set; }
        public string TransportUnitNumber { get; set; }
    }
}
