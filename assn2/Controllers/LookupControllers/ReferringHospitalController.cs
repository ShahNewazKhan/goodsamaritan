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
    public class ReferringHospitalController : Controller
    {
        private GSContext db = new GSContext();

        // GET: ReferringHospital
        public ActionResult Index()
        {
            return View(db.ReferringHospital.ToList());
        }

        // GET: ReferringHospital/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferringHospital referringHospital = db.ReferringHospital.Find(id);
            if (referringHospital == null)
            {
                return HttpNotFound();
            }
            return View(referringHospital);
        }

        // GET: ReferringHospital/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReferringHospital/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value")] ReferringHospital referringHospital)
        {
            if (ModelState.IsValid)
            {
                db.ReferringHospital.Add(referringHospital);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(referringHospital);
        }

        // GET: ReferringHospital/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferringHospital referringHospital = db.ReferringHospital.Find(id);
            if (referringHospital == null)
            {
                return HttpNotFound();
            }
            return View(referringHospital);
        }

        // POST: ReferringHospital/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value")] ReferringHospital referringHospital)
        {
            if (ModelState.IsValid)
            {
                db.Entry(referringHospital).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(referringHospital);
        }

        // GET: ReferringHospital/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferringHospital referringHospital = db.ReferringHospital.Find(id);
            if (referringHospital == null)
            {
                return HttpNotFound();
            }
            return View(referringHospital);
        }

        // POST: ReferringHospital/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReferringHospital referringHospital = db.ReferringHospital.Find(id);
            db.ReferringHospital.Remove(referringHospital);
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
