using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using S3Train.Contract;
using S3Train.Domain;
using S3Train.Web.Models;

namespace S3Train.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductAdvertisementService _productAdvertisementService;
        private readonly ICategoryService _categoryService;

        public HomeController(IProductService productService, IProductAdvertisementService productAdvertisementService, ICategoryService categoryService)
        {
            _productService = productService;
            _productAdvertisementService = productAdvertisementService;
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var model = new HomeViewModel
            {
                SliderItems = GetHomeSlider(_productAdvertisementService.GetSliderItems()),
                Products = GetHomeProducts(_productService.GetNewProductItems()),
                //CategoryItems = GetHomeCategory(_categoryService.GetCategoryItems())
            };

            return View(model);
        }

        private static IEnumerable<IGrouping<int, ProductViewModel>> GetHomeProducts(IList<Product> products)
        {
            return products.Select((x, i) => new ProductViewModel
            {
                Id = x.Id,
                ImagePath = x.ImagePath,
                NameProduct = x.NameProduct,
                DisplayPrice = $"${x.Price}",
                Rating = x.Rating ?? 0,
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
                Name = x.NameCategory
            }).ToList();

        }

       

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}