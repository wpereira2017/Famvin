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
    public class CouncilsController : Controller
    {
        private FamVinEntities db = new FamVinEntities();

        public ActionResult Index()
        {
            var council = db.Council.Include(c => c.Region);
            return View(council.ToList().OrderBy(x => x.Region.Name).ThenBy( x => x.Name ));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Council council = db.Council.Find(id);
            if (council == null)
            {
                return HttpNotFound();
            }
            return View(council);
        }

        public ActionResult Create()
        {
            ViewBag.IdRegion = new SelectList(db.Region, "IdRegion", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Council council)
        {
            if (ModelState.IsValid)
            {
                db.Council.Add(council);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdRegion = new SelectList(db.Region, "IdRegion", "Name", council.IdRegion);
            return View(council);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Council council = db.Council.Find(id);
            if (council == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdRegion = new SelectList(db.Region, "IdRegion", "Name", council.IdRegion);
            return View(council);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Council council)
        {
            if (ModelState.IsValid)
            {
                db.Entry(council).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdRegion = new SelectList(db.Region, "IdRegion", "Name", council.IdRegion);
            return View(council);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Council council = db.Council.Find(id);
            if (council == null)
            {
                return HttpNotFound();
            }
            return View(council);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Council council = db.Council.Find(id);
            db.Council.Remove(council);
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
