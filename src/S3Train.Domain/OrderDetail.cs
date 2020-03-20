using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Domain
{
    public class OrderDetail : EntityBase
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int OrderQuantity { get; set; }
        public Decimal Total { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
