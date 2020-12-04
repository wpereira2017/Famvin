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
    public class CountriesController : Controller
    {
        private FamVinEntities db = new FamVinEntities();

        public ActionResult Index()
        {
            var country = db.Country.Include(c => c.Region);
            return View(country.ToList().OrderBy(x => x.Region.Name ).ThenBy( x => x.Name));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Country.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        public ActionResult Create()
        {
            ViewBag.IdRegion = new SelectList(db.Region, "IdRegion", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                db.Country.Add(country);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdRegion = new SelectList(db.Region, "IdRegion", "Name", country.IdRegion);
            return View(country);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Country.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdRegion = new SelectList(db.Region, "IdRegion", "Name", country.IdRegion);
            return View(country);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                db.Entry(country).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdRegion = new SelectList(db.Region, "IdRegion", "Name", country.IdRegion);
            return View(country);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Country.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Country country = db.Country.Find(id);
            db.Country.Remove(country);
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

        public ActionResult GetCountryMembers()
        {
            var totals = from m in db.Member
                         join c in db.Council on m.IdCouncil equals c.IdCouncil 
                         join cc in db.Country on c.IdCountry equals cc.IdCountry
                         group m by new
                         {
                             cc.IdCountry,
                             cc.Name
                         }
                         into grouped
                         select new
                         {
                             Country = grouped.Key.Name,
                             TotalMembers = grouped.Count()
                         };

            return Json(totals, JsonRequestBehavior.AllowGet);
        }
    }
}
