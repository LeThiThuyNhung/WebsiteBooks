using System;
using System.Collections.Generic;
using System.Linq;
using S3Train.Contract;
using S3Train.Domain;
using S3Train.DTOs;

namespace S3Train.Service
{
    public class CSProductService : GenenicServiceBase<Product>, ICSProductService
    {
        public CSProductService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public IList<Product> GetCSProductItems()
        {

            var csbook = DbContext.Products.Where(x =>x.UpdatedDate == null).ToList(); 
            return csbook;
        }
    }
}
