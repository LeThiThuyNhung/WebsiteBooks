using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Domain
{
    public class Promotion : EntityBase
    {
        public string PromotionName { get; set; }
        public DateTime StartTime { get; set; } 
        public DateTime EndTime { get; set; }
        public virtual ICollection<PromotionDetail> PromotionDetails { get; set; }
    }
}
