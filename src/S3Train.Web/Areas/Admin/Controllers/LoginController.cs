using S3Train.Domain;
using S3Train.Service;
using S3Train.Web.Areas.Admin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace S3Train.Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            HttpCookie cookie = Request.Cookies["Login"];
            if(cookie != null)
            {
                ViewBag.email = cookie["email"].ToString();
                //string EncryptedPassword = cookie["password"].ToString();
                //byte[] b = Convert.FromBase64String(EncryptedPassword);
                //string decryptPassword = ASCIIEncoding.ASCII.GetString(b);
                //ViewBag.password = decryptPassword.ToString();
                ViewBag.password = cookie["password"].ToString();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Login l)
        {
            ////var result = new Account().Login(model.Email, model.Password);
            //if(Membership.ValidateUser(model.Email, model.Password) && ModelState.IsValid)
            //{
            //    //SessionHelper.SetSession(new UserSession() { Email = model.Email });
            //    FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
            //    return RedirectToAction("Index", "HomeAdmin");
            //}
            //else
            //{
            //    ModelState.AddModelError("", "Username or password wrong!");
            //}
            HttpCookie cookie = new HttpCookie("Login");
            if (ModelState.IsValid == true)
            {
                if(l.RememberMe == true)
                {
                    cookie["email"] = l.Email;

                    byte[] b = ASCIIEncoding.ASCII.GetBytes(l.Password);
                    string EncryptedPassword = Convert.ToBase64String(b);
                    cookie["password"] = l.Password;
                    cookie.Expires = DateTime.Now.AddDays(2);
                    HttpContext.Response.Cookies.Add(cookie);
                }
                else
                {
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Response.Cookies.Add(cookie);
                }

                var row = db.Staffs.Where(m => m.Email == l.Email && m.Password == l.Password).FirstOrDefault();
                if(row != null)
                {
                    Session["Email"] = l.Email;
                    TempData["Message"] = "<script>alert('Login successfull!!!')</script>";
                    return RedirectToAction("Index", "HomeAdmin");
                }
                else
                {
                    ModelState.AddModelError("", "Username or password wrong!");
                    //TempData["Message"] = "<script>alert('Login failed!!!')</script>";
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            if(Session["Email"] != null)
            {
                Session.Abandon();
                return RedirectToAction("Index", "Login");
            }
            return View();

        }
    }
}