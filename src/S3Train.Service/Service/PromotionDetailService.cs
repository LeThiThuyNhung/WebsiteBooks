using S3Train.Contract;
using S3Train.Domain;
using S3Train.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace S3Train.Service
{
    public class PromotionDetailService: GenenicServiceBase<PromotionDetail>, IPromotionDetailService
    {
        public PromotionDetailService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IList<ProductDTO> GetPromotionDetail()
        {
            var product = DbContext.Products
                .Where(n => n.PromotionDetails.Any(a => a.PromotionPercent > 0))
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

            return product;
        }
    }
}
