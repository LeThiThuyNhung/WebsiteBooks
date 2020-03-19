using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S3Train.Web.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        //[Authorize]
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            if(Session["Email"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
            
        }
    }
}