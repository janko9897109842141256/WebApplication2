using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class IspitsController : Controller
    {
        private FakultetEntities db = new FakultetEntities();

        // GET: Ispits
        public ActionResult Index()
        {
            var ispits = db.Ispits.Include(i => i.Predmet).Include(i => i.Student);
            return View(ispits.ToList());
        }

        // GET: Ispits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ispit ispit = db.Ispits.Find(id);
            if (ispit == null)
            {
                return HttpNotFound();
            }
            return View(ispit);
        }

        // GET: Ispits/Create
        public ActionResult Create()
        {
            ViewBag.Predmet_ID = new SelectList(db.Predmets, "Predmet_ID", "Naziv_Predmeta");
            ViewBag.BI = new SelectList(db.Students, "BI", "Ime_Prezime");
            return View();
        }

        // POST: Ispits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BI,Predmet_ID,Ocena")] Ispit ispit)
        {
            if (ModelState.IsValid)
            {
                db.Ispits.Add(ispit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Predmet_ID = new SelectList(db.Predmets, "Predmet_ID", "Naziv_Predmeta", ispit.Predmet_ID);
            ViewBag.BI = new SelectList(db.Students, "BI", "Ime_Prezime", ispit.BI);
            return View(ispit);
        }

        // GET: Ispits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ispit ispit = db.Ispits.Find(id);
            if (ispit == null)
            {
                return HttpNotFound();
            }
            ViewBag.Predmet_ID = new SelectList(db.Predmets, "Predmet_ID", "Naziv_Predmeta", ispit.Predmet_ID);
            ViewBag.BI = new SelectList(db.Students, "BI", "Ime_Prezime", ispit.BI);
            return View(ispit);
        }

        // POST: Ispits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BI,Predmet_ID,Ocena")] Ispit ispit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ispit).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Predmet_ID = new SelectList(db.Predmets, "Predmet_ID", "Naziv_Predmeta", ispit.Predmet_ID);
            ViewBag.BI = new SelectList(db.Students, "BI", "Ime_Prezime", ispit.BI);
            return View(ispit);
        }

        // GET: Ispits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ispit ispit = db.Ispits.Find(id);
            if (ispit == null)
            {
                return HttpNotFound();
            }
            return View(ispit);
        }

        // POST: Ispits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ispit ispit = db.Ispits.Find(id);
            db.Ispits.Remove(ispit);
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
