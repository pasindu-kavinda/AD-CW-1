using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Models
{
    public class TransportUnitModel
    {
        public int Id { get; set; }
        public string UnitNumber { get; set; }
        public int TruckId { get; set; }
        public int DriverId { get; set; }
        public int? AssistantId { get; set; }
        public string Status { get; set; } = "1";
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public string TruckNumber { get; set; }
        public string DriverName { get; set; }
        public string AssistantName { get; set; }
    }
}
