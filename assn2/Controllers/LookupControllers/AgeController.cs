using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using assn2.DAL;
using assn2.Models;

namespace assn2.Controllers.LookupControllers
{
    [Authorize(Roles = "Administrator")]
    public class AgeController : Controller
    {
        private GSContext db = new GSContext();

        // GET: Age
        public ActionResult Index()
        {
            return View(db.Age.ToList());
        }

        // GET: Age/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Age age = db.Age.Find(id);
            if (age == null)
            {
                return HttpNotFound();
            }
            return View(age);
        }

        // GET: Age/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Age/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value")] Age age)
        {
            if (ModelState.IsValid)
            {
                db.Age.Add(age);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(age);
        }

        // GET: Age/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Age age = db.Age.Find(id);
            if (age == null)
            {
                return HttpNotFound();
            }
            return View(age);
        }

        // POST: Age/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value")] Age age)
        {
            if (ModelState.IsValid)
            {
                db.Entry(age).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(age);
        }

        // GET: Age/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Age age = db.Age.Find(id);
            if (age == null)
            {
                return HttpNotFound();
            }
            return View(age);
        }

        // POST: Age/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Age age = db.Age.Find(id);
            db.Age.Remove(age);
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
