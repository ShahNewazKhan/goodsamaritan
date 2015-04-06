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
    public class PoliceReportedController : Controller
    {
        private GSContext db = new GSContext();

        // GET: PoliceReported
        public ActionResult Index()
        {
            return View(db.PoliceReported.ToList());
        }

        // GET: PoliceReported/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoliceReported policeReported = db.PoliceReported.Find(id);
            if (policeReported == null)
            {
                return HttpNotFound();
            }
            return View(policeReported);
        }

        // GET: PoliceReported/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PoliceReported/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value")] PoliceReported policeReported)
        {
            if (ModelState.IsValid)
            {
                db.PoliceReported.Add(policeReported);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(policeReported);
        }

        // GET: PoliceReported/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoliceReported policeReported = db.PoliceReported.Find(id);
            if (policeReported == null)
            {
                return HttpNotFound();
            }
            return View(policeReported);
        }

        // POST: PoliceReported/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value")] PoliceReported policeReported)
        {
            if (ModelState.IsValid)
            {
                db.Entry(policeReported).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(policeReported);
        }

        // GET: PoliceReported/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoliceReported policeReported = db.PoliceReported.Find(id);
            if (policeReported == null)
            {
                return HttpNotFound();
            }
            return View(policeReported);
        }

        // POST: PoliceReported/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PoliceReported policeReported = db.PoliceReported.Find(id);
            db.PoliceReported.Remove(policeReported);
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
