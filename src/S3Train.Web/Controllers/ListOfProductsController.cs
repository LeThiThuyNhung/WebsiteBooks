using S3Train.Contract;
using S3Train.Domain;
using S3Train.DTOs;
using S3Train.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S3Train.Web.Controllers
{
    public class ListOfProductsController : Controller
    {
        private readonly IProductService _newProductsService;
        private readonly ICSProductService _cSProductsService;
        private readonly IPromotionDetailService _bestSellerProductsService;


        public ListOfProductsController(IProductService newProductsService,  ICSProductService cSProductsSerVice, IPromotionDetailService bestSellerProductsService)
        {
            _newProductsService = newProductsService;
            _cSProductsService = cSProductsSerVice;
            _bestSellerProductsService = bestSellerProductsService;
        }
        // GET: ListOfProducts
        public ActionResult NewProducts()
        {
            var model = new HomeViewModel
            {
                newProducts = GetNewProducts(_newProductsService.GetNewProductItems()),
            };

            return View(model);
        }

        public ActionResult cSProducts()
        {
            var csproducts = new HomeViewModel
            {
                csProducts = GetCSProducts(_cSProductsService.GetCSProductItems()),
            };

            return View(csproducts);
        }

        public ActionResult bestSellerProducts()
        {
            var csproducts = new HomeViewModel
            {
                bestSellerProducts = GetBestSellerProducts(_bestSellerProductsService.GetPromotionDetail()),
            };

            return View(csproducts);
        }

        private static IList<ProductViewModel> GetNewProducts(IList<Product> products)
        {
            return products.Select((x) => new ProductViewModel
            {
                Id = x.Id,
                ImagePath = x.ImagePath,
                NameProduct = x.NameProduct,
                DisplayPrice = $"${x.Price}",
            }).ToList();
        }

        private static IList<CSProductViewModel> GetCSProducts(IList<Product> products)
        {
            return products.Select((x) => new CSProductViewModel
            {
                Id = x.Id,
                ImagePath = x.ImagePath,
                NameProduct = x.NameProduct,
                DisplayPrice = $"${x.Price}",
            }).ToList();
        }

        private static IList<PromotionProductViewModel> GetBestSellerProducts(IList<ProductDTO> promotionDetail)
        {
            return promotionDetail.Select((x) => new PromotionProductViewModel
            {
                Id = x.ProductId,
                ImagePath = x.ImagePath,
                NameProduct = x.NameProduct,
                DisplayPrice = $"${x.Price}",
            }).ToList();
        }
    }
}