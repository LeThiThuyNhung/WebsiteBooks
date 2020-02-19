using System;

namespace S3Train.Domain
{
    public class Product : EntityBase
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public int? Rating { get; set; }

        public virtual Category Category { get; set; }
    }
}