using System;
using System.Collections.Generic;
using System.Linq;
using S3Train.Contract;
using S3Train.Domain;
using S3Train.DTOs;

namespace S3Train.Service
{
    public class ProductsByCategoryService : GenenicServiceBase<Category>, IProductsByCategoryService
    {
        public ProductsByCategoryService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IList<ProductDTO> GetProductsByCategoryItems(Guid CategoryId)
        {
            var product = DbContext.Products.Include("Category")
                .Where(n => n.Category.Id == CategoryId)
                 .Select(n => new ProductDTO
                 {
                     ProductId = n.Id,
                     CategoryId = n.CategoryId,
                     NameProduct = n.NameProduct,
                     ImagePath = n.ImagePath,
                     Price = n.Price,
                     Barcode = n.Barcode,
                     UpdatedDate = n.UpdatedDate,
                     Category = new CategoryDTO
                     {
                         CategoryName = n.Category.NameCategory
                     },
                     Promotion = n.PromotionDetails.Select(x => new PromotionDTO
                     {
                         PromotionPercent = x.PromotionPercent,
                     }).ToList(),
                 }).ToList();
            return product;
        }
    }
}
