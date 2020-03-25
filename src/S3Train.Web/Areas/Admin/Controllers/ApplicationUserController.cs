using PagedList;
using S3Train.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace S3Train.Web.Areas.Admin.Controllers
{
    public class ApplicationUserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/ApplicationUser
        public ActionResult Index(int? page)
        {
            if (Session["Email"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                int pageNumber = (page ?? 1);
                int pageSize = 10;
                return View(db.Users.ToList().OrderBy(t => t.FullName).ToPagedList(pageNumber, pageSize));
            }
            
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/ApplicationUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}