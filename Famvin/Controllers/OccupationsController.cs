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
    public class OccupationsController : Controller
    {
        private FamVinEntities db = new FamVinEntities();

        public ActionResult Index()
        {
            return View(db.Occupation.ToList().OrderBy(x => x.Name));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Occupation occupation = db.Occupation.Find(id);
            if (occupation == null)
            {
                return HttpNotFound();
            }
            return View(occupation);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Occupation occupation)
        {
            if (ModelState.IsValid)
            {
                db.Occupation.Add(occupation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(occupation);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Occupation occupation = db.Occupation.Find(id);
            if (occupation == null)
            {
                return HttpNotFound();
            }
            return View(occupation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Occupation occupation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(occupation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(occupation);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Occupation occupation = db.Occupation.Find(id);
            if (occupation == null)
            {
                return HttpNotFound();
            }
            return View(occupation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Occupation occupation = db.Occupation.Find(id);
            db.Occupation.Remove(occupation);
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
