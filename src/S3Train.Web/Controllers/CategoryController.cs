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
    public class CategoryController : Controller
    {
        private readonly IProductsByCategoryService _productsByCategory;

        public CategoryController(IProductsByCategoryService ProductsByCategory)
        {
            _productsByCategory = ProductsByCategory;

        }
        // GET: ProductsByCategory
        public ActionResult ProductsByCategory(Guid CategoryId)
        {

            var productsByCategory = new HomeViewModel
            {
                productsByCategory = GetBroductsByCategory(_productsByCategory.GetProductsByCategoryItems(CategoryId))
            };

            return View(productsByCategory);
        }

        private static IList<CategoryViewModel> GetBroductsByCategory(IList<ProductDTO> proByCa)
        {
            return proByCa.Select(x => new CategoryViewModel
            {
                Id = x.CategoryId,
                ImagePath = x.ImagePath,
                Name = x.NameProduct,
                DisplayPrice = $"${x.Price}",
                ProductId = x.ProductId,
                NameCategory = x.Category.CategoryName,
            }).ToList();
        }
    }
}