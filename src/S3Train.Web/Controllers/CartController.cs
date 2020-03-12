using S3Train.Contract;
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
        //private readonly ICartService _cartService;
        private const string CartSession = "CartSession";
        //public CartController(ICartService cartService)
        //{
        //    _cartService = cartService;

        //}
        // GET: Cart
        public ActionResult MyCart()
        {
            //var cart = Session[CartSession];
            //var list = new List<CartViewModel>();
            //if (cart != null)
            //{
            //    list = (List<CartViewModel>)cart;
            //}
                return View();
        }

        public ActionResult AddItems(Guid Id, int Quantity)
        {
            //var cartItems = _cartService.GetCart(Id, Quantity);
            var cart = Session[CartSession];
            if(cart != null)
            {
                var list = (List<CartViewModel>)cart;
                if (list.Exists(x => x.product.Id == Id))
                {
                    foreach (var item in list)
                    {
                        if (item.product.Id == Id)
                        {
                            item.Amount += Quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartViewModel();
                    item.product.Id = Id;
                    item.Amount = Quantity;
                    list.Add(item);
                }
                foreach(var item in list)
                {
                    if(item.product.Id == Id)
                    {
                        item.Amount += Quantity;
                    }
                }
                Session[CartSession] = list;
            }
            else
            {
                var item = new CartViewModel();
                item.product.Id = Id;
                item.Amount = Quantity;
                var list = new List<CartViewModel>();

                Session[CartSession] = list;
            }
            return RedirectToAction("MyCart");
        }
    }
}