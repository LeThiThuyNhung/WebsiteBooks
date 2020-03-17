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
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private const string CartSession = "CartSession";
        public CartController(ICartService cartService)
        {
            _cartService = cartService;

        }
        // GET: Cart
        public ActionResult MyCart()
        {
            var cart = (List<CartViewModel>)Session[CartSession];
          
            return View(cart);
        }

        public RedirectToRouteResult AddItems(Guid Id, int Quantity)
        {
            var CartItem = _cartService.GetCart(Id, Quantity);
            var currentCartItems = (List<CartViewModel>)Session[CartSession] ?? new List<CartViewModel>(); ;
            if (currentCartItems.Exists(x => x.Products.Id == Id))
            {
                currentCartItems.SingleOrDefault(q => q.Products.Id == Id).Amount += Quantity;
            }
            else
            {
                currentCartItems.Add(new CartViewModel
                {
                    Products = new ProductDTO {
                        Id = Id,
                        NameProduct = CartItem.NameProduct,
                        ImagePath = CartItem.ImagePath,
                        Barcode = CartItem.Barcode,
                        Price = CartItem.Price,

                    },
                    Amount = Quantity

                });
            }
            Session[CartSession] = currentCartItems;
            return RedirectToAction("MyCart");
        }

        public ActionResult UpdateQuantity(Guid Id, int NewQuan)
        {
            List<CartViewModel> cart = (List<CartViewModel>)Session[CartSession]  ;
            CartViewModel updateItem = cart.FirstOrDefault(m => m.Products.Id == Id);
            if (updateItem != null)
            {
                updateItem.Amount = NewQuan;
            }
            return Json(updateItem);

        }


        public ActionResult RemoveItem(Guid Id)
        {
            var removeCart = (List<CartViewModel>)Session[CartSession];
            removeCart.RemoveAll(x => x.Products.Id == Id);
            Session[CartSession] = removeCart;
            return Json(removeCart);

        }
    }
}