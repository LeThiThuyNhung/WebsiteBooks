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

        public IList<PromotionDetailDTO> GetPromotionDetail()
        {
            var promotionDetail = DbContext.PromotionDetails.Include("Product")
                .Where (x => x.PromotionPercent >  0)
                .Select(n => new PromotionDetailDTO
                {
                   PromotionPercent = n.PromotionPercent,
                   PromotionDetail = new ProductDTO
                   {
                       ProductId = n.Product.Id,
                       NameProduct = n.Product.NameProduct,
                       ImagePath = n.Product.ImagePath,
                       Price = n.Product.Price,
                   }

                }).ToList();
            return promotionDetail;
        }
    }
}
