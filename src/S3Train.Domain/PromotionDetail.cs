using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Domain
{
    public class PromotionDetail : EntityBase
    {
        public Guid ProductId { get; set; }
        public Guid PromotionId { get; set; }
        public double PromotionPercent { get; set; }
        public virtual Product Product { get; set; }
        public virtual Promotion Promotion { get; set; }
    }
}
