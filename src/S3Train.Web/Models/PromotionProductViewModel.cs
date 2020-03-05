using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S3Train.Web.Models
{
    public class PromotionProductViewModel
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; }
        public string NameProduct { get; set; }
        public string DisplayPrice { get; set; }
        public double PromotionDetail { get; set; }
        public int Grouping { get; set; }
    }
}