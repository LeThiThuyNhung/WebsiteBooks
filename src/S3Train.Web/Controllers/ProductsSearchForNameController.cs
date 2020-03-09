using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using S3Train.Contract;
using S3Train.Domain;
using S3Train.Web.Models;
using System;
using PagedList;
using PagedList.Mvc;

namespace S3Train.Web.Controllers
{
    public class ProductsSearchForNameController : Controller
    {
        private readonly ISearchProductsForNameService _searchForName;
        public ActionResult Index()
        {
            return View();
        }

        public ProductsSearchForNameController(ISearchProductsForNameService searchForName)
        {
            _searchForName = searchForName;
        }

        public ActionResult ProductsSearchForName(string Name, int? page)
        {

            var productsSearchForName = new HomeViewModel
            {
                productsSearchForName = GetProductsSearchForName(_searchForName.GetProductsSearchForNameItems(Name))
            };
            return View(productsSearchForName);
        }

        private static IList<ProductsSearchForNameViewModel> GetProductsSearchForName(IList<Product> proForName)
        {
            return proForName.Select(x => new ProductsSearchForNameViewModel
            {
                Id = x.Id,
                ImagePath = x.ImagePath,
                NameProduct = x.NameProduct,
                DisplayPrice = $"${x.Price}",
            }).ToList();
        }
    }
}