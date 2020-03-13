using S3Train.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S3Train.Web.Models
{
    public class CartViewModel
    {
        public Product Product { get; set; }
        public int Amount { get; set; }
       
    }
}