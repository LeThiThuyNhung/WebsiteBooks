using S3Train.Domain;
using S3Train.DTOs;
using System;
using System.Collections.Generic;


namespace S3Train.Contract
{
    public interface IProductsByCategoryService : IGenenicServiceBase<Category>
    {
        IList<ProductDTO> GetProductsByCategoryItems(Guid CategoryId);
    }
}