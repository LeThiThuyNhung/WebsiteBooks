using S3Train.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using S3Train.Domain;

namespace S3Train.Web.Models
{
    public class PayMentViewModel
    {
        public ApplicationUser User { get; set; }
        public Guid Id { get; set; }
        //public string ImagePath { get; set; }
        //public string NameProduct { get; set; }
        //public string Summary { get; set; }
        //public string DisplayPrice { get; set; }
        //public string Barcode { get; set; }
        //public int Amount { get; set; }

        public List<CartViewModel> Card { get; set; }
    }
}