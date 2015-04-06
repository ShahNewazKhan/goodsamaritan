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
    public class MedicalOnlyController : Controller
    {
        private GSContext db = new GSContext();

        // GET: MedicalOnly
        public ActionResult Index()
        {
            return View(db.MedicalOnly.ToList());
        }

        // GET: MedicalOnly/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalOnly medicalOnly = db.MedicalOnly.Find(id);
            if (medicalOnly == null)
            {
                return HttpNotFound();
            }
            return View(medicalOnly);
        }

        // GET: MedicalOnly/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicalOnly/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value")] MedicalOnly medicalOnly)
        {
            if (ModelState.IsValid)
            {
                db.MedicalOnly.Add(medicalOnly);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicalOnly);
        }

        // GET: MedicalOnly/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalOnly medicalOnly = db.MedicalOnly.Find(id);
            if (medicalOnly == null)
            {
                return HttpNotFound();
            }
            return View(medicalOnly);
        }

        // POST: MedicalOnly/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value")] MedicalOnly medicalOnly)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicalOnly).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicalOnly);
        }

        // GET: MedicalOnly/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalOnly medicalOnly = db.MedicalOnly.Find(id);
            if (medicalOnly == null)
            {
                return HttpNotFound();
            }
            return View(medicalOnly);
        }

        // POST: MedicalOnly/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicalOnly medicalOnly = db.MedicalOnly.Find(id);
            db.MedicalOnly.Remove(medicalOnly);
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
