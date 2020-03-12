using S3Train.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S3Train.Web.Models
{
    public class CartViewModel
    {
        public Product product { get; set; }
        public string ImagePath { get; set; }
        public string NameProduct { get; set; }
        public string Summary { get; set; }
        public string DisplayPrice { get; set; }
        public int Amount { get; set; }
    }
}