using System;
using System.Collections.Generic;
using System.Linq;
using S3Train.Contract;
using S3Train.Domain;


namespace S3Train.Service
{
    public class NewProductService : GenenicServiceBase<Product>, IProductService
    {
        public NewProductService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public IList<Product> GetNewProductItems()
        {
            var newbook = (from c in DbContext.Products
                           where c.UpdatedDate != null
                           orderby c.CreatedDate descending
                           select new
                           {
                               c.Id,
                               c.NameProduct,
                               c.Price,
                               c.ImagePath,
                           }).Take(8).ToList();
            var book = newbook
                .Select(n => new Product
               {
                   Id =n.Id,
                   NameProduct = n.NameProduct,
                   ImagePath = n.ImagePath,
                   Price = n.Price,
               }).ToList();
            return book;
        }

       
    }
}