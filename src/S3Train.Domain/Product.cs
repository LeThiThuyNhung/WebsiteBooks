﻿using System;

namespace S3Train.Domain
{
    public class Product : EntityBase
    {
        public Guid CategoryId { get; set; }
        public Guid PublisherId { get; set; }
        public string NameProduct { get; set; }
        public string Summary { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public string Barcode { get; set; }
        public int ReleaseYear { get; set; }
        public int Amount { get; set; }
        public int? Rating { get; set; }

        public virtual Category Category { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}