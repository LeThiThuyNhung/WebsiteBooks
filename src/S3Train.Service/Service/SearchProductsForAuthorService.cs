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
    public class SearchProductsForAuthorService : GenenicServiceBase<ProducDTO>, ISearchProductsForAuthorService
    {
        public SearchProductsForAuthorService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public IList<ProductDTO> GetProductsSearchForAuhtorItems(string Name)
        {
            var productSearchForAuthor = DbContext.Author_Products.Include("Author")
                .Where(x => x.Author.NameAuthor == Name || x.Product.NameProduct.Contains(Name))
                .Select(x => new ProductDTO
                {
                    Id = x.Product.Id,
                    NameProduct = x.Product.NameProduct,
                    ImagePath = x.Product.ImagePath,
                    Price = x.Product.Price,
                }).ToList();
          
            return productSearchForAuthor;

        }
    }
}
