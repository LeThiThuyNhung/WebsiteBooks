using S3Train.Service;
using S3Train.Web.Areas.Admin.Code;
using S3Train.Web.Areas.Admin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S3Train.Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Login model)
        {
            var result = new Account().Login(model.Email, model.Password);
            if(result && ModelState.IsValid)
            {
                SessionHelper.SetSession(new UserSession() { Email = model.Email });
                return RedirectToAction("Index", "Products");
            }
            else if(!result)
            {
                ModelState.AddModelError("", "Username or password wrong!");
            }
            else
            {
                ModelState.AddModelError("", "Username or password wrong!");
            }
            return View(model);
        }
    }
}