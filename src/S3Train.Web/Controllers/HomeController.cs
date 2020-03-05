using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using S3Train.Contract;
using S3Train.Domain;
using S3Train.Web.Models;
using S3Train.DTOs;

namespace S3Train.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _newProductService;
        private readonly IProductAdvertisementService _productAdvertisementService;
        private readonly ICategoryService _categoryService;
        private readonly ICSProductService _cSProductService;
        private readonly IPromotionDetailService _promotionProductService;

        public HomeController(IProductService newProductService, IProductAdvertisementService productAdvertisementService, ICategoryService categoryService, ICSProductService cSProductSerVice, IPromotionDetailService promotionDetailService)
        {
            _newProductService = newProductService;
            _productAdvertisementService = productAdvertisementService;
            _categoryService = categoryService;
            _cSProductService = cSProductSerVice;
            _promotionProductService = promotionDetailService;
        }

        public ActionResult Index()
        {
            var model = new HomeViewModel
            {
                SliderItems = GetHomeSlider(_productAdvertisementService.GetSliderItems()),
                NewProducts = GetHomeNewProducts(_newProductService.GetNewProductItems()),
                //CategoryItems = GetHomeCategory(_categoryService.GetCategoryItems())
                CSProducts = GetHomeCSProducts(_cSProductService.GetCSProductItems()),
                PromotionProducts = GetHomeBestSellerProducts(_promotionProductService.GetPromotionDetail()),
            };

            return View(model);
        }

       
        private static IEnumerable<IGrouping<int, ProductViewModel>> GetHomeNewProducts(IList<Product> products)
        {
            return products.Select((x, i) => new ProductViewModel
            {
                Id = x.Id,
                ImagePath = x.ImagePath,
                NameProduct = x.NameProduct,
                DisplayPrice = $"${x.Price}",
                Grouping = i / 4
            }).GroupBy(e => e.Grouping).ToList();
        }

        private static IEnumerable<IGrouping<int, CSProductViewModel>> GetHomeCSProducts(IList<Product> products)
        {
            return products.Select((x, i) => new CSProductViewModel
            {
                Id = x.Id,
                ImagePath = x.ImagePath,
                NameProduct = x.NameProduct,
                DisplayPrice = $"${x.Price}",
                Grouping = i / 4
            }).GroupBy(e => e.Grouping).ToList();
        }

        private static IEnumerable<IGrouping<int, PromotionProductViewModel>> GetHomeBestSellerProducts(IList<PromotionDetailDTO> promotionDetail)
        {
            return promotionDetail.Select((x, i) => new PromotionProductViewModel
            {
                Id = x.ProductId,
                ImagePath = x.ImagePath,
                NameProduct = x.NameProduct,
                DisplayPrice = $"${x.Price}",
                Grouping = i / 4
            }).GroupBy(e => e.Grouping).ToList();
        }

        private static IList<SliderItemViewModel> GetHomeSlider(IList<ProductAdvertisement> productAds)
        {
            return productAds.Select(x => new SliderItemViewModel
            {
                ImagePath = x.ImagePath,
                Title = x.Title,
                Description = x.Description,
                EventUrl = x.EventUrl,
            }).ToList();
        }

        private static IList<CategoryViewModel> GetHomeCategory(IList<Category> category)
        {
            return category.Select(x => new CategoryViewModel
            {
                NameCategory = x.NameCategory
            }).ToList();

        }



    }
}