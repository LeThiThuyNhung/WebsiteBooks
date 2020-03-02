using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using S3Train.Contract;
using S3Train.Domain;
using S3Train.Web.Models;
using System;

namespace S3Train.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductDetailService _detailProductService;

        public ProductController(IProductDetailService detailProductService)
        {
            _detailProductService = detailProductService;
        }

        public ActionResult Detail (Guid id)
        {
            var prodDetail = _detailProductService.GetProductDetail(id);

            var productDetailViewModel = new ProductDetailViewModel
            {
                Name = prodDetail.NameProduct,
                ImagePath = prodDetail.ImagePath,
                DisplayPrice = $"{prodDetail.Price}",
                Rating = prodDetail.Rating ?? 0,
                NamePublisher = prodDetail.Publisher.NamePublisher,
            };

            return View(productDetailViewModel);
        }

        private static ProductDetailViewModel GetDetailProduct(Product product)
        {
            return new ProductDetailViewModel
            {
                Id = product.Id,
                ImagePath = product.ImagePath,
                Name = product.NameProduct,
                DisplayPrice = $"{product.Price}",
                Rating = product.Rating ?? 0,
                NamePublisher = product.Publisher.NamePublisher,

            };
        }
    }
}