using S3Train.Contract;
using S3Train.Domain;
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
            var cart = Session[CartSession];
            var list  = new List<CartViewModel>();
            if(cart != null)
            {
                list = (List<CartViewModel>)cart;
            }
            return View(cart);
        }

        public RedirectToRouteResult AddItems(Guid Id, int Quantity)
        {
            var CartItem = _cartService.GetCart(Id, Quantity);
            var cart = Session[CartSession];
            if(cart!= null)
            {
                var list = (List<CartViewModel>)cart;
                if(list.Exists(x => x.Product.Id == Id))
                {
                    foreach(var item in list)
                    {
                        if (item.Product.Id == Id)
                        {
                            item.Amount += Quantity;
                        }
                    }
                }
                else
                {
                    var newItem = new CartViewModel();
                    newItem.Product.Id = CartItem.Id;
                    newItem.Amount = Quantity;
                    list.Add(newItem);
                }
                Session[CartSession] = list;
            }
            else
            {
                var newItem = new CartViewModel();
                newItem.Product.Id = CartItem.Id;
                newItem.Amount = Quantity;
                var list = new List<CartViewModel>();
                list.Add(newItem);
                Session[CartSession] = list;
            }
            //if (Session["cart"] == null)
            //{
            //    Session["cart"] = new List<CartViewModel>();
            //}
            //List<CartViewModel> cart = Session["cart"] as List<CartViewModel>;
            //if (cart.FirstOrDefault(m => m.Product. == Id) == null)
            //{
            //    var newItem = new CartViewModel()
            //    {
            //        ProductId = Id,
            //        Amount = Quantity,
            //        Product = Cart.Select (m => new ProductViewModel
            //        {
            //            ImagePath = m.ImagePath,
            //            NameProduct = m.NameProduct,
            //            DisplayPrice = $"${m.Price}",
            //            Barcode = m.Barcode,
            //        }).ToList(),
                    
            //    };
            //    cart.Add(newItem);
            //}
            //else
            //{
            //    CartViewModel cartItem = cart.FirstOrDefault(m => m.ProductId == Id);
            //    cartItem.Amount++;
            //}
            return RedirectToAction("MyCart");
        }
    }
}