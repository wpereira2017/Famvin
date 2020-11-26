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
    public class MembersController : Controller
    {
        private FamVinEntities db = new FamVinEntities();

        // GET: Members
        public ActionResult Index()
        {
            var member = db.Member.Include(m => m.Branch).Include(m => m.Council).Include(m => m.Member1).Include(m => m.Member2).Include(m => m.Occupation).Include(m => m.Position).Include(m => m.Region);
            return View(member.ToList());
        }

        // GET: Members/Details/5
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

        // GET: Members/Create
        public ActionResult Create()
        {
            ViewBag.IdBranch = new SelectList(db.Branch, "IdBranch", "Code");
            ViewBag.IdCouncil = new SelectList(db.Council, "IdCouncil", "Name");
            ViewBag.IdMember = new SelectList(db.Member, "IdMember", "Name");
            ViewBag.IdMember = new SelectList(db.Member, "IdMember", "Name");
            ViewBag.IdOccupation = new SelectList(db.Occupation, "IdOccupation", "Name");
            ViewBag.IdPosition1 = new SelectList(db.Position, "IdPosition", "Name");
            ViewBag.IdRegion = new SelectList(db.Region, "IdRegion", "Name");
            return View();
        }

        // POST: Members/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
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
            ViewBag.IdMember = new SelectList(db.Member, "IdMember", "Name", member.IdMember);
            ViewBag.IdMember = new SelectList(db.Member, "IdMember", "Name", member.IdMember);
            ViewBag.IdOccupation = new SelectList(db.Occupation, "IdOccupation", "Name", member.IdOccupation);
            ViewBag.IdPosition1 = new SelectList(db.Position, "IdPosition", "Name", member.IdPosition1);
            ViewBag.IdRegion = new SelectList(db.Region, "IdRegion", "Name", member.IdRegion);
            return View(member);
        }

        // GET: Members/Edit/5
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
            ViewBag.IdMember = new SelectList(db.Member, "IdMember", "Name", member.IdMember);
            ViewBag.IdMember = new SelectList(db.Member, "IdMember", "Name", member.IdMember);
            ViewBag.IdOccupation = new SelectList(db.Occupation, "IdOccupation", "Name", member.IdOccupation);
            ViewBag.IdPosition1 = new SelectList(db.Position, "IdPosition", "Name", member.IdPosition1);
            ViewBag.IdRegion = new SelectList(db.Region, "IdRegion", "Name", member.IdRegion);
            return View(member);
        }

        // POST: Members/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
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
            ViewBag.IdMember = new SelectList(db.Member, "IdMember", "Name", member.IdMember);
            ViewBag.IdMember = new SelectList(db.Member, "IdMember", "Name", member.IdMember);
            ViewBag.IdOccupation = new SelectList(db.Occupation, "IdOccupation", "Name", member.IdOccupation);
            ViewBag.IdPosition1 = new SelectList(db.Position, "IdPosition", "Name", member.IdPosition1);
            ViewBag.IdRegion = new SelectList(db.Region, "IdRegion", "Name", member.IdRegion);
            return View(member);
        }

        // GET: Members/Delete/5
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

        // POST: Members/Delete/5
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
