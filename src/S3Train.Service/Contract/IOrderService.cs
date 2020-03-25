﻿using S3Train.Domain;
using S3Train.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Contract
{
    public interface IOrderService : IGenenicServiceBase<Order>
    {
       Guid InsertOrder(Order order);
        IList<ProductDTO> GetProductsByUserItems(string ApplicationUserId);
    }
}
