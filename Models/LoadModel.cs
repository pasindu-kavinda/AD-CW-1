using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Models
{
    public class LoadModel
    {
        public int Id { get; set; }
        public string LoadNumber { get; set; }
        public int JobId { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public decimal Volume { get; set; }
        public string Instructions { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public string JobNumber { get; set; }
    }
}
