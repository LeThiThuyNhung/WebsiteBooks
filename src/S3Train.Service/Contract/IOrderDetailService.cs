using S3Train.Domain;
using S3Train.DTOs;
using System;

namespace S3Train.Contract
{
    public interface IOrderDetailService: IGenenicServiceBase<OrderDetail>
    {
        void InsertOrderDetail(OrderDetail orderDetail);
    }
}
