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

        // GET: Occupations
        public ActionResult Index()
        {
            return View(db.Occupation.ToList());
        }

        // GET: Occupations/Details/5
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

        // GET: Occupations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Occupations/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdOccupation,Name")] Occupation occupation)
        {
            if (ModelState.IsValid)
            {
                db.Occupation.Add(occupation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(occupation);
        }

        // GET: Occupations/Edit/5
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

        // POST: Occupations/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdOccupation,Name")] Occupation occupation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(occupation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(occupation);
        }

        // GET: Occupations/Delete/5
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

        // POST: Occupations/Delete/5
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
