using System;
using System.Collections.Generic;
using System.Linq;
using S3Train.Contract;
using S3Train.Domain;

namespace S3Train.Service
{
    public class CSProductService : GenenicServiceBase<Product>, ICSProductService
    {
        public CSProductService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public IList<Product> GetCSProductItems()
        {

            var csbook = DbContext.Products
                .Where(x => x.CreatedDate == null)
                .Select(n => new Product
                {
                    NameProduct = n.NameProduct,
                    ImagePath = n.ImagePath,
                    Price = n.Price,
                }).ToList();
            return csbook;
        }
    }
}
