using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using S3Train.Contract;
using S3Train.Domain;
using S3Train.Web.Models;
using System;
using S3Train.DTOs;

namespace S3Train.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductDetailService _detailProductService;

        public ProductController(IProductDetailService detailProductService)
        {
            _detailProductService = detailProductService;

        }

        public ActionResult Detail(Guid id)
        {
            var prodDetail = _detailProductService.GetProductDetail(id);
            var productDetailViewModel = new ProductDetailViewModel
            {
                Id = prodDetail.Id,
                Name = prodDetail.NameProduct,
                ImagePath = prodDetail.ImagePath,
                DisplayPrice = $"{prodDetail.Price}",
                Price = prodDetail.Price,
                Rating = prodDetail.Rating ?? 0,
                Summary = prodDetail.Summary,
                Barcode = prodDetail.Barcode,
                ReleaseYear = prodDetail.ReleaseYear,
                NamePublisher = prodDetail.Publisher.NamePublisher,
                CategoryName = prodDetail.Category.CategoryName,
                UpdatedDate = prodDetail.UpdatedDate,
                PromotionPercent = prodDetail.Promotion.First().PromotionPercent,
                AuthorName = String.Join(", ", prodDetail.Author.Select(x => x.NameAuthor)),
                RelatedProduct = prodDetail.RelatedProduct.Select(q => new ProductViewModel
                {
                    Id = q.ProductId,
                    NameProduct = q.NameProduct,
                    ImagePath = q.ImagePath,
                    DisplayPrice = q.Price.ToString()
                }).ToList()
            };

            return View(productDetailViewModel);
        }

    }

       
}