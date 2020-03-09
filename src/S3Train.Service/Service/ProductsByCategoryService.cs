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
                     Category = new CategoryDTO
                     {
                         CategoryName = n.Category.NameCategory
                     },
                 }).ToList();
            return product;
        }
    }
}
