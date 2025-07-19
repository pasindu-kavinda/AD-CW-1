using LiveCharts.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Models
{
    public class JobProductModel
    {
        public int Id { get; set; }
        public int? JobId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? CustomWeight { get; set; }
        public string CustomDimensions { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public string ProductName { get; set; }
        public string JobNumber { get; set; }
    }
}
