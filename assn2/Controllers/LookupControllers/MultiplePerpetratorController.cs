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
    public class MultiplePerpetratorController : Controller
    {
        private GSContext db = new GSContext();

        // GET: MultiplePerpetrator
        public ActionResult Index()
        {
            return View(db.MultiplePerpetrators.ToList());
        }

        // GET: MultiplePerpetrator/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultiplePerpetrators multiplePerpetrators = db.MultiplePerpetrators.Find(id);
            if (multiplePerpetrators == null)
            {
                return HttpNotFound();
            }
            return View(multiplePerpetrators);
        }

        // GET: MultiplePerpetrator/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MultiplePerpetrator/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value")] MultiplePerpetrators multiplePerpetrators)
        {
            if (ModelState.IsValid)
            {
                db.MultiplePerpetrators.Add(multiplePerpetrators);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(multiplePerpetrators);
        }

        // GET: MultiplePerpetrator/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultiplePerpetrators multiplePerpetrators = db.MultiplePerpetrators.Find(id);
            if (multiplePerpetrators == null)
            {
                return HttpNotFound();
            }
            return View(multiplePerpetrators);
        }

        // POST: MultiplePerpetrator/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value")] MultiplePerpetrators multiplePerpetrators)
        {
            if (ModelState.IsValid)
            {
                db.Entry(multiplePerpetrators).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(multiplePerpetrators);
        }

        // GET: MultiplePerpetrator/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultiplePerpetrators multiplePerpetrators = db.MultiplePerpetrators.Find(id);
            if (multiplePerpetrators == null)
            {
                return HttpNotFound();
            }
            return View(multiplePerpetrators);
        }

        // POST: MultiplePerpetrator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MultiplePerpetrators multiplePerpetrators = db.MultiplePerpetrators.Find(id);
            db.MultiplePerpetrators.Remove(multiplePerpetrators);
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
