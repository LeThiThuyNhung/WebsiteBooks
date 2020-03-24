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
            var productDetail = DbContext.Products.Include("Publisher").Include("Author")
                .Where(u => u.Id == id)
                .Select(n => new ProductDTO
                {
                    Id = n.Id,
                    NameProduct = n.NameProduct,
                    ImagePath = n.ImagePath,
                    Price = n.Price,
                    Rating = n.Rating,
                    Summary = n.Summary,
                    Barcode = n.Barcode,
                    ReleaseYear = n.ReleaseYear,
                    UpdatedDate = n.UpdatedDate,
                    Publisher = new PublisherDTO
                    {
                        NamePublisher = n.Publisher.NamePublisher
                    },
                    Author = n.Author_Products.Select(q => new AuthorDTO
                    {
                        AuthorId = q.AuthorId,
                        NameAuthor = q.Author.NameAuthor
                    }).ToList(),
                    Category = new CategoryDTO
                    {
                        CategoryName = n.Category.NameCategory
                    },
                    Promotion = n.PromotionDetails.Select(x => new PromotionDTO {
                        PromotionPercent = x.PromotionPercent
                    }).ToList(),
                }).SingleOrDefault();

                var listAuthorId = productDetail.Author.Select(q => q.AuthorId);

                productDetail.RelatedProduct = DbContext.Author_Products.Include("Product")
                .Where(q => listAuthorId.Contains(q.AuthorId) && q.ProductId!= id).Select(n => new ProductDTO {
                    ProductId = n.Product.Id,
                    NameProduct = n.Product.NameProduct,
                    ImagePath = n.Product.ImagePath,
                    Price = n.Product.Price
                }).ToList();
               

            return productDetail;

        }
    }
}
