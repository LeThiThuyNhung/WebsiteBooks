using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.DTOs
{
    public class PromotionDetailDTO
    {
        public Guid ProductId { get; set; }
        public string NameProduct { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public double PromotionPercent { get; set; }

        public ProductDTO PromotionDetail { get; set; }
    }
}
