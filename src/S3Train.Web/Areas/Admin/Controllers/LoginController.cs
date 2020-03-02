using S3Train.Service;
using S3Train.Web.Areas.Admin.Code;
using S3Train.Web.Areas.Admin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
            //var result = new Account().Login(model.Email, model.Password);
            if(Membership.ValidateUser(model.Email, model.Password) && ModelState.IsValid)
            {
                //SessionHelper.SetSession(new UserSession() { Email = model.Email });
                FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                return RedirectToAction("Index", "HomeAdmin");
            }
            else
            {
                ModelState.AddModelError("", "Username or password wrong!");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}