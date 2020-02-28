using S3Train.Contract;
using S3Train.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Service
{
    public class DetailProductService : GenenicServiceBase<Product>, IProductService
    {
        public DetailProductService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public IList<Product> GetProductItems()
        {

            return this.EntityDbSet.ToList();
        }
    }
}
