using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.DTOs
{
    public class ProductDTO
    {
        public Guid ProductId { get; set; }
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

        public PublisherDTO Publisher  { get; set; }
        public IList<AuthorDTO> Author { get; set; }
        public CategoryDTO Category { get; set; }
        public IList<PromotionDTO> Promotion { get; set; }
    }
}
