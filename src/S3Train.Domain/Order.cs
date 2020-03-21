using System;
using System.Collections.Generic;

namespace S3Train.Domain
{
    public class Order : EntityBase
    {
        public DateTime DatePayment { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public Decimal TotalMoney { get; set; }
        public Guid ApplicationUserId { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
