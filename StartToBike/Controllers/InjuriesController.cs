using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StartToBike.DAL;
using StartToBike.Models;

namespace StartToBike.Controllers
{
    public class InjuriesController : Controller
    {
        private StartToBikeContext db = new StartToBikeContext();

        // GET: Injuries
        public ActionResult Index()
        {
            return View(db.Injuries.ToList());
        }

        // GET: Injuries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Injury injury = db.Injuries.Find(id);
            if (injury == null)
            {
                return HttpNotFound();
            }
            return View(injury);
        }

        // GET: Injuries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Injuries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Picture,Prevention,Treatement")] Injury injury)
        {
            if (ModelState.IsValid)
            {
                db.Injuries.Add(injury);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(injury);
        }

        // GET: Injuries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Injury injury = db.Injuries.Find(id);
            if (injury == null)
            {
                return HttpNotFound();
            }
            return View(injury);
        }

        // POST: Injuries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Picture,Prevention,Treatement")] Injury injury)
        {
            if (ModelState.IsValid)
            {
                db.Entry(injury).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(injury);
        }

        // GET: Injuries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Injury injury = db.Injuries.Find(id);
            if (injury == null)
            {
                return HttpNotFound();
            }
            return View(injury);
        }

        // POST: Injuries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Injury injury = db.Injuries.Find(id);
            db.Injuries.Remove(injury);
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
