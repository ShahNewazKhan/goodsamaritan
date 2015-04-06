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
    public class EthnicityController : Controller
    {
        private GSContext db = new GSContext();

        // GET: Ethnicity
        public ActionResult Index()
        {
            return View(db.Ethnicity.ToList());
        }

        // GET: Ethnicity/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ethnicity ethnicity = db.Ethnicity.Find(id);
            if (ethnicity == null)
            {
                return HttpNotFound();
            }
            return View(ethnicity);
        }

        // GET: Ethnicity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ethnicity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value")] Ethnicity ethnicity)
        {
            if (ModelState.IsValid)
            {
                db.Ethnicity.Add(ethnicity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ethnicity);
        }

        // GET: Ethnicity/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ethnicity ethnicity = db.Ethnicity.Find(id);
            if (ethnicity == null)
            {
                return HttpNotFound();
            }
            return View(ethnicity);
        }

        // POST: Ethnicity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value")] Ethnicity ethnicity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ethnicity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ethnicity);
        }

        // GET: Ethnicity/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ethnicity ethnicity = db.Ethnicity.Find(id);
            if (ethnicity == null)
            {
                return HttpNotFound();
            }
            return View(ethnicity);
        }

        // POST: Ethnicity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ethnicity ethnicity = db.Ethnicity.Find(id);
            db.Ethnicity.Remove(ethnicity);
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
