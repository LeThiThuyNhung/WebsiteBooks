using System;
using System.Collections.Generic;
using S3Train.Domain;
using S3Train.DTOs;

namespace S3Train.Contract
{
    public interface IProductDetailService : IGenenicServiceBase<Product>
    {
        ProductDTO GetProductDetail(Guid id);
    }
}