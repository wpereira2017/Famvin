using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Famvin.Models;

namespace Famvin.Controllers
{
    public class RegionsController : Controller
    {
        private FamVinEntities db = new FamVinEntities();

        public ActionResult Index()
        {
            return View(db.Region.ToList().OrderBy(x => x.Name));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Region region = db.Region.Find(id);
            if (region == null)
            {
                return HttpNotFound();
            }
            return View(region);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Region region)
        {
            if (ModelState.IsValid)
            {
                db.Region.Add(region);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(region);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Region region = db.Region.Find(id);
            if (region == null)
            {
                return HttpNotFound();
            }
            return View(region);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Region region)
        {
            if (ModelState.IsValid)
            {
                db.Entry(region).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(region);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Region region = db.Region.Find(id);
            if (region == null)
            {
                return HttpNotFound();
            }
            return View(region);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Region region = db.Region.Find(id);
            db.Region.Remove(region);
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

        public ActionResult GetRegionMembers()
        {
            var totals = from m in db.Member
                         join r in db.Region on m.IdRegion equals r.IdRegion
                         group m by new {
                             r.IdRegion,
                             r.Name
                         }
                         into grouped
                         select new
                         {
                             Region = grouped.Key.Name,
                             TotalMembers = grouped.Count()
                         };

            return Json(totals, JsonRequestBehavior.AllowGet);
        }
    }
}
