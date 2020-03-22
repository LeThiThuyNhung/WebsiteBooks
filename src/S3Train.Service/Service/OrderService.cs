using S3Train.Contract;
using S3Train.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Service
{
    public class OrderService : GenenicServiceBase<Order>, IOrderService
    {
        public OrderService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Guid InsertOrder(Order order)
        {
            order.Id = Guid.NewGuid();
            DbContext.Orders.Add(order);
            DbContext.SaveChanges();

            return order.Id;
        }
    }
}
