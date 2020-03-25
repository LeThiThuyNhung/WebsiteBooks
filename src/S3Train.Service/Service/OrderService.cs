using S3Train.Contract;
using S3Train.Domain;
using S3Train.DTOs;
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

        public IList<OrderDTO> GetOrders(string ApplicationUserId)
        {
            var orderUser = (from o in DbContext.Orders
                             join a in DbContext.Users on o.ApplicationUserId equals a.Id
                             where a.Id == ApplicationUserId
                             select new
                             {
                                 o.Id,
                                 o.DatePayment,
                                 o.Status,
                                 o.Note,
                                 o.TotalMoney,
                                 a.FullName,
                                 o.CreatedDate,
                                 o.UpdatedDate,
                                 o.IsActive
                             }).ToList();

            var pro = orderUser
                .Select(n => new OrderDTO
                {
                    Id = n.Id,
                    DatePayment = n.DatePayment,
                    Status = n.Status,
                    Note = n.Note,
                    TotalMoney = n.TotalMoney,
                    FullName = n.FullName,
                    CreatedDate = n.CreatedDate,
                    UpdatedDate = n.UpdatedDate,
                    IsActive = n.IsActive
                }).ToList();

            return pro;
        }
        public IList<ProductDTO> GetProductsByUserItems(Guid OrderId)
        {
            var proUser = (from p in DbContext.Products
                          join d in DbContext.OrderDetails on p.Id equals d.ProductId
                          join o in DbContext.Orders on d.OrderId equals o.Id
                          where o.Id == OrderId
                           select new
                          {
                              p.Id,
                              p.ImagePath,
                              p.NameProduct,
                              p.Barcode,
                              d.Price,
                              d.OrderQuantity,
                              d.Total
                          }).ToList();

            var pro = proUser
                .Select(n => new ProductDTO
                {
                    Id = n.Id,
                    ImagePath = n.ImagePath,
                    NameProduct = n.NameProduct,
                    Barcode = n.Barcode,
                    Price = n.Price,
                    OrderQuantity = n.OrderQuantity,
                    ToTal = n.Total
                }).ToList();

            return pro;
        }
    }
}
