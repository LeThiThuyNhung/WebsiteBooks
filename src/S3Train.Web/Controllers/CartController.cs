using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using S3Train.Web.Models;
using S3Train.Domain;
using S3Train.Contract;
using System.Collections.Generic;
using System;
using S3Train.DTOs;

namespace S3Train.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        public const string CartSession = "CartSession";
        public CartController(ICartService cartService, IOrderService orderService, IOrderDetailService orderDetailService)
        {
            _cartService = cartService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;

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
            var userId = User.Identity.GetUserId();
            ApplicationDbContext db = new ApplicationDbContext();
            var user = db.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
            var cartSession = (List<CartViewModel>)Session[CartSession];
            var payMent = new PayMentViewModel
            {
               
                    Cart = cartSession,
                    User = new ApplicationUser
                    {
                        

                        FullName = user.FullName,
                        Address = user.Address,
                        PhoneNumber = user.PhoneNumber,
                    }
            };
            return View(payMent);
        }

        public ActionResult Order()
        {
            var userId = User.Identity.GetUserId();
            var cartSession = (List<CartViewModel>)Session[CartSession];
            var order = new Order
            {
                ApplicationUserId = userId,
                DatePayment = DateTime.Now,
                TotalMoney = cartSession.Sum(m => m.Amount * m.Products.Price),
            };
            var id = _orderService.InsertOrder(order);
            foreach (var item in cartSession)
            {
                var orderDetail = new OrderDetail
                {
                    OrderId = id,
                    OrderQuantity = item.Amount,
                    Price = item.Products.Price,
                    Total = item.Amount * item.Products.Price,
                    ProductId = item.Products.Id,
                };
                _orderDetailService.InsertOrderDetail(orderDetail);
            }
            Session[CartSession] = null;
            return RedirectToAction("MyCart");
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