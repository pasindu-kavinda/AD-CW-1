using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Models
{
    public class TruckModel
    {
        public int Id { get; set; }
        public string TruckNumber { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public string Status { get; set; }
        public int Capacity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
