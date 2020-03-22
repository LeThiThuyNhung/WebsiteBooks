using System;
using System.Collections.Generic;
using System.Linq;
using S3Train.Contract;
using S3Train.Domain;
using S3Train.DTOs;
namespace S3Train.Service
{
    public class OrderDetailService: GenenicServiceBase<OrderDetail>, IOrderDetailService
    {
        public OrderDetailService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public void InsertOrderDetail(OrderDetail orderDetail)
        {
            
                orderDetail.Id = Guid.NewGuid();
                DbContext.OrderDetails.Add(orderDetail);
                DbContext.SaveChanges();
            
        }
    }
}
