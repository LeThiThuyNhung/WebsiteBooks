using System;
using System.Collections.Generic;
using System.Linq;
using S3Train.Contract;
using S3Train.Domain;
using S3Train.DTOs;

namespace S3Train.Service
{
    public class CSProductService : GenenicServiceBase<ProducDTO>, ICSProductService
    {
        public CSProductService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public IList<ProductDTO> GetCSProductItems()
        {
            var csbook = DbContext.Products
                .Where(x => x.UpdatedDate == null)
                .Select(n => new ProductDTO
                {
                    ProductId = n.Id,
                    NameProduct = n.NameProduct,
                    ImagePath = n.ImagePath,
                    Price = n.Price,
                    Promotion = n.PromotionDetails.Select(x => new PromotionDTO
                    {
                        PromotionPercent = x.PromotionPercent,
                    }).ToList(),
                }).ToList();
            return csbook;
        }
    }
}
