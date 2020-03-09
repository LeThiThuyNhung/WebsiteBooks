using S3Train.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S3Train.Contract;

namespace S3Train.Service
{
    public class SearchProductsForNameService : GenenicServiceBase<Product>, ISearchProductsForNameService
    {
        public SearchProductsForNameService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IList<Product> GetProductsSearchForNameItems(string Name)
        {
            var products = DbContext.Products.Where(x => x.NameProduct.Contains(Name)).ToList();
            return products;
        }
    }
}
