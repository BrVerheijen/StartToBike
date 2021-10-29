using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StartToBike.DAL;
using StartToBike.Models;

namespace StartToBike.Controllers
{
    [Authorize]
    public class InjuriesController : Controller
    {
        private StartToBikeContext db = new StartToBikeContext();
        
        // GET: Injuries
        public ActionResult Index()
        {
            
            return View(db.Injury.ToList());
        }

        // GET: Injuries/Details/5
        public ActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Injury injury = db.Injury.Find(id);
            if (injury == null)
            {
                return HttpNotFound();
            }
            return View(injury);
        }

        // GET: Injuries/Create
        [Authorize(Roles = "Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Injuries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Moderator")]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Picture,Prevention,Treatement")] Injury injury)
        {
            if (ModelState.IsValid)
            {
                
                db.Injury.Add(injury);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(injury);
        }

        // GET: Injuries/Edit/5
        [Authorize(Roles = "Moderator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Injury injury = db.Injury.Find(id);
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
        [Authorize(Roles = "Moderator")]
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
        [Authorize(Roles = "Moderator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Injury injury = db.Injury.Find(id);
            if (injury == null)
            {
                return HttpNotFound();
            }
            return View(injury);
        }

        // POST: Injuries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Moderator")]
        public ActionResult DeleteConfirmed(int id)
        {
            Injury injury = db.Injury.Find(id);
            db.Injury.Remove(injury);
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

        // Function to add Injury to User Collection
        [Authorize(Roles = "User")]
        public ActionResult Save(int? id)
        {
            //checks if id was given
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //gets Injury
            Injury injury = db.Injury.Find(id);
            //checks if Injury is valid
            if (injury == null)
            {
                return HttpNotFound();
            }
            //get current user
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = manager.FindById(User.Identity.GetUserId());
            //find user in db and set variable to it
            ApplicationUser UserToAddTo = user;
            //add injury to injurylist within user
            if (UserToAddTo == null)
            {
                return HttpNotFound();
            }


            //db.User.Include("Injuries").FirstOrDefault(x => x.Id == UserToAddTo.Id).Injury.Add(injury);
            //db.Injury.Include("AspNetUsers").FirstOrDefault(x => x.ID == injury.ID).ApplicationUser.Add(UserToAddTo);
            UserToAddTo.Injury.Add(injury);
            //add user to userlist within injury
            
            injury.ApplicationUser.Add(UserToAddTo);
            //confirm changes to user and injury
            
            if (ModelState.IsValid)
            {
                
                db.SaveChanges();
            }

            return View("Index", db.Injury.ToList());
        }
    }
}
