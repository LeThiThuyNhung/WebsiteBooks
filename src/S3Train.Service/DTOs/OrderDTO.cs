using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.DTOs
{
    public class OrderDTO
    {
        public DateTime DatePayment { get; set; }
        public string Status { get; set; }
        public Decimal TotalMoney { get; set; }
        public string Note { get; set; }
        public string FullName { get; set; }
        public Guid Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
