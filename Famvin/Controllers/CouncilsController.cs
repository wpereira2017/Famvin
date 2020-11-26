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

        // GET: Councils
        public ActionResult Index()
        {
            var council = db.Council.Include(c => c.Region);
            return View(council.ToList());
        }

        // GET: Councils/Details/5
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

        // GET: Councils/Create
        public ActionResult Create()
        {
            ViewBag.IdRegion = new SelectList(db.Region, "IdRegion", "Name");
            return View();
        }

        // POST: Councils/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCouncil,IdRegion,Name")] Council council)
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

        // GET: Councils/Edit/5
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

        // POST: Councils/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCouncil,IdRegion,Name")] Council council)
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

        // GET: Councils/Delete/5
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

        // POST: Councils/Delete/5
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
