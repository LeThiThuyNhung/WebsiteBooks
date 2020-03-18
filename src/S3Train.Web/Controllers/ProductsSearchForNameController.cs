using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using S3Train.Contract;
using S3Train.Domain;
using S3Train.Web.Models;
using System;
using PagedList;
using PagedList.Mvc;
using S3Train.DTOs;

namespace S3Train.Web.Controllers
{
    public class ProductsSearchForNameController : Controller
    {
        private readonly ISearchProductsForAuthorService _searchForAuthor;

        public ProductsSearchForNameController(ISearchProductsForAuthorService searchForAuthor)
        {
            _searchForAuthor = searchForAuthor;
        }

        public ActionResult ProductsSearchForAuthor(string Name)
        {
            var productsSearchForAuthor = new HomeViewModel
            {
                productsSearchForName = GetProductsSearchForName(_searchForAuthor.GetProductsSearchForAuhtorItems(Name))
            };
            return View(productsSearchForAuthor);
        }

        private IList<ProductsSearchForNameViewModel> GetProductsSearchForName(IList<ProductDTO> proForAuthor)
        {
            return proForAuthor.Select(x => new ProductsSearchForNameViewModel
            {
                Id = x.Id,
                ImagePath = x.ImagePath,
                NameProduct = x.NameProduct,
                DisplayPrice = $"${x.Price}",
            }).ToList();
        }
    }
}