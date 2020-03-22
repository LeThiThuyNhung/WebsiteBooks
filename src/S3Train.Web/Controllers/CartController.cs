using S3Train.Contract;
using S3Train.Domain;
using S3Train.DTOs;
using S3Train.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S3Train.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        public const string CartSession = "CartSession";
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
            var CartItem = _cartService.GetCart(Id);
            var currentCartItems = (List<CartViewModel>)Session[CartSession] ?? new List<CartViewModel>(); ;
            if (currentCartItems.Exists(x => x.Products.Id == Id))
            {
                currentCartItems.SingleOrDefault(q => q.Products.Id == Id).Amount += Quantity;
            }
            else
            {
                currentCartItems.Add(new CartViewModel
                {
                    Products = new ProductDTO
                    {
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
            List<CartViewModel> cart = (List<CartViewModel>)Session[CartSession];
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

        public ActionResult Buy(Guid Id)
        {
            var CartItem = _cartService.GetCart(Id);
            var currentCartItems = (List<CartViewModel>)Session[CartSession] ?? new List<CartViewModel>(); ;
            if (currentCartItems.Exists(x => x.Products.Id == Id))
            {
                currentCartItems.SingleOrDefault(q => q.Products.Id == Id).Amount++;
            }
            else
            {
                currentCartItems.Add(new CartViewModel
                {
                    Products = new ProductDTO
                    {
                        Id = Id,
                        NameProduct = CartItem.NameProduct,
                        ImagePath = CartItem.ImagePath,
                        Barcode = CartItem.Barcode,
                        Price = CartItem.Price,

                    },
                    Amount = 1

                });
            }
            Session[CartSession] = currentCartItems;
            return RedirectToAction("MyCart");
        }

        public ActionResult PayMent()
        {
            var cartSession = (List<CartViewModel>)Session[CartSession];
            var payMent = new PayMentViewModel
            {
               
                    Card = cartSession,
            };
            return View(payMent.Card);
        }

        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult AddAddress()
        {
            var user = db.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();

            var model = new ApplicationUser
            {
                Id = user.Id,
                Address = user.Address,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                EmailConfirmed = user.EmailConfirmed,
                SecurityStamp = user.SecurityStamp,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                TwoFactorEnabled = user.TwoFactorEnabled,
                LockoutEndDateUtc = user.LockoutEndDateUtc,
                LockoutEnabled = user.LockoutEnabled,
                AccessFailedCount = user.AccessFailedCount,
                UserName = user.UserName,
                FullName = user.FullName,
                DateofBirth = user.DateofBirth,
                Gender = user.Gender
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAddress([Bind(Include = "Id,Address,Email,PasswordHash,EmailConfirmed,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,FullName,DateofBirth,Gender")] ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PayMent", "Cart");
            }
            return View(user);
        }
    }
}