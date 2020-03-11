using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S3Train.Web.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult MyCart()
        {
            return View();
        }
    }
}