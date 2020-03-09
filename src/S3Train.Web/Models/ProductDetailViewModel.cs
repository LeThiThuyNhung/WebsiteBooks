using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S3Train.Web.Models
{
    public class ProductDetailViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string DisplayPrice { get; set; }
        public string ImagePath { get; set; }
        public string Barcode { get; set; }
        public int ReleaseYear { get; set; }
        public int Amount { get; set; }
        public int? Rating { get; set; }

        public string NamePublisher { get; set; }
        public string AuthorName { get; set; }
        public string PromotionPercent { get; set; }
        public string CategoryName { get; set; }
    }
}