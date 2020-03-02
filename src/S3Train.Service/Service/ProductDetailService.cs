using S3Train.Contract;
using S3Train.Domain;
using S3Train.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Service
{
    public class ProductDetailService : GenenicServiceBase<Product>, IProductDetailService
    {
        public ProductDetailService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public ProductDTO GetProductDetail(Guid id)
        {
            var productDetail = DbContext.Products.Include("Publisher")
                .Where(u => u.Id == id)
                .Select(n => new ProductDTO
                {
                    NameProduct = n.NameProduct,
                    ImagePath = n.ImagePath,
                    Price = n.Price,
                    Rating = n.Rating,
                    Publisher = new PublisherDTO {
                        NamePublisher = n.Publisher.NamePublisher
                    }
                }).SingleOrDefault();
            return productDetail;
        }
    }
}
