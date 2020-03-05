using System;

namespace S3Train.Domain
{
    public class ProductAdvertisement : EntityBase
    {
        public Guid ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string EventUrl{ get; set; }
        public string ImagePath { get; set; }
        public ProductAdvertisementType AdType { get; set; }
        public virtual Product Product { get; set; }
    }
}