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
    public class Members1Controller : Controller
    {
        private FamVinEntities db = new FamVinEntities();

        public ActionResult Index()
        {
            var member = db.Member.Include(m => m.Branch).Include(m => m.Council).Include(m => m.Occupation).Include(m => m.Position).Include(m => m.Region);
            return View(member.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        public ActionResult Create()
        {
            ViewBag.IdBranch = new SelectList(db.Branch, "IdBranch", "Code");
            ViewBag.IdCouncil = new SelectList(db.Council, "IdCouncil", "Name");
            ViewBag.IdOccupation = new SelectList(db.Occupation, "IdOccupation", "Name");
            ViewBag.IdPosition1 = new SelectList(db.Position, "IdPosition", "Name");
            ViewBag.IdRegion = new SelectList(db.Region, "IdRegion", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMember,IdRegion,IdCouncil,IdPosition1,IdOccupation,IdBranch,IdPosition2,Name,Email,Phone")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Member.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdBranch = new SelectList(db.Branch, "IdBranch", "Code", member.IdBranch);
            ViewBag.IdCouncil = new SelectList(db.Council, "IdCouncil", "Name", member.IdCouncil);
            ViewBag.IdOccupation = new SelectList(db.Occupation, "IdOccupation", "Name", member.IdOccupation);
            ViewBag.IdPosition1 = new SelectList(db.Position, "IdPosition", "Name", member.IdPosition1);
            ViewBag.IdRegion = new SelectList(db.Region, "IdRegion", "Name", member.IdRegion);
            return View(member);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdBranch = new SelectList(db.Branch, "IdBranch", "Code", member.IdBranch);
            ViewBag.IdCouncil = new SelectList(db.Council, "IdCouncil", "Name", member.IdCouncil);
            ViewBag.IdOccupation = new SelectList(db.Occupation, "IdOccupation", "Name", member.IdOccupation);
            ViewBag.IdPosition1 = new SelectList(db.Position, "IdPosition", "Name", member.IdPosition1);
            ViewBag.IdRegion = new SelectList(db.Region, "IdRegion", "Name", member.IdRegion);
            return View(member);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMember,IdRegion,IdCouncil,IdPosition1,IdOccupation,IdBranch,IdPosition2,Name,Email,Phone")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdBranch = new SelectList(db.Branch, "IdBranch", "Code", member.IdBranch);
            ViewBag.IdCouncil = new SelectList(db.Council, "IdCouncil", "Name", member.IdCouncil);
            ViewBag.IdOccupation = new SelectList(db.Occupation, "IdOccupation", "Name", member.IdOccupation);
            ViewBag.IdPosition1 = new SelectList(db.Position, "IdPosition", "Name", member.IdPosition1);
            ViewBag.IdRegion = new SelectList(db.Region, "IdRegion", "Name", member.IdRegion);
            return View(member);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Member.Find(id);
            db.Member.Remove(member);
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
