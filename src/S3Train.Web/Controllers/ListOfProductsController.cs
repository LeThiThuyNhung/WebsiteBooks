using S3Train.Contract;
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
        public ActionResult NewProducts(int page = 1, int pagesize = 4)
        {
            int totalRecord = 0;

            var model = new HomeViewModel
            {
                newProducts = GetNewProducts(_newProductsService.GetNewProductItems(), ref totalRecord, page, pagesize),
            };

            ViewBag.ToTal = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling(((double)totalRecord / (double)pagesize));

            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Pre = page - 1;

            return View(model);
        }

        public ActionResult cSProducts(int page = 1, int pagesize = 4)
        {
            int totalRecord = 0;

            var csproducts = new HomeViewModel
            {
                csProducts = GetCSProducts(_cSProductsService.GetCSProductItems(), ref totalRecord, page, pagesize),
            };

            ViewBag.ToTal = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling(((double)totalRecord / (double)pagesize));

            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Pre = page - 1;

            return View(csproducts);
        }

        public ActionResult bestSellerProducts(int page = 1, int pagesize = 4)
        {
            int totalRecord = 0;
            var csproducts = new HomeViewModel
            {
                bestSellerProducts = GetBestSellerProducts(_bestSellerProductsService.GetPromotionDetail(), ref totalRecord, page, pagesize),
            };

            ViewBag.ToTal = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling(((double)totalRecord / (double)pagesize));

            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Pre = page - 1;

            return View(csproducts);
        }

        private static IList<ProductViewModel> GetNewProducts(IList<ProductDTO> products, ref int totalRecord, int page = 1, int pagesize = 4)
        {
            var totalPro = products.Select((x) => new ProductViewModel
            {
                Id = x.Id,
                ImagePath = x.ImagePath,
                NameProduct = x.NameProduct,
                DisplayPrice = $"${x.Price}",
            });

            var model = totalPro.OrderBy(x => x.NameProduct).Skip((page - 1) * pagesize).Take(pagesize).ToList();
            totalRecord = totalPro.Count();

            return model;
        }

        private static IList<CSProductViewModel> GetCSProducts(IList<ProductDTO> products, ref int totalRecord, int page = 1, int pagesize = 4)
        {
            var totalPro = products.Select((x) => new CSProductViewModel
            {
                Id = x.Id,
                ImagePath = x.ImagePath,
                NameProduct = x.NameProduct,
                DisplayPrice = $"${x.Price}",
            });

            var model = totalPro.OrderBy(x => x.NameProduct).Skip((page - 1) * pagesize).Take(pagesize).ToList();
            totalRecord = totalPro.Count();

            return model;
        }

        private static IList<PromotionProductViewModel> GetBestSellerProducts(IList<ProductDTO> promotionDetail, ref int totalRecord, int page = 1, int pagesize = 4)
        {
            var totalPro = promotionDetail.Select((x) => new PromotionProductViewModel
            {
                Id = x.ProductId,
                ImagePath = x.ImagePath,
                NameProduct = x.NameProduct,
                DisplayPrice = $"${x.Price}",
            });

            var model = totalPro.OrderBy(x => x.NameProduct).Skip((page - 1) * pagesize).Take(pagesize).ToList();
            totalRecord = totalPro.Count();

            return model;
        }
    }
}