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
    public class EvidenceStoredController : Controller
    {
        private GSContext db = new GSContext();

        // GET: EvidenceStored
        public ActionResult Index()
        {
            return View(db.EvidenceStored.ToList());
        }

        // GET: EvidenceStored/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EvidenceStored evidenceStored = db.EvidenceStored.Find(id);
            if (evidenceStored == null)
            {
                return HttpNotFound();
            }
            return View(evidenceStored);
        }

        // GET: EvidenceStored/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EvidenceStored/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value")] EvidenceStored evidenceStored)
        {
            if (ModelState.IsValid)
            {
                db.EvidenceStored.Add(evidenceStored);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(evidenceStored);
        }

        // GET: EvidenceStored/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EvidenceStored evidenceStored = db.EvidenceStored.Find(id);
            if (evidenceStored == null)
            {
                return HttpNotFound();
            }
            return View(evidenceStored);
        }

        // POST: EvidenceStored/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value")] EvidenceStored evidenceStored)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evidenceStored).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(evidenceStored);
        }

        // GET: EvidenceStored/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EvidenceStored evidenceStored = db.EvidenceStored.Find(id);
            if (evidenceStored == null)
            {
                return HttpNotFound();
            }
            return View(evidenceStored);
        }

        // POST: EvidenceStored/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EvidenceStored evidenceStored = db.EvidenceStored.Find(id);
            db.EvidenceStored.Remove(evidenceStored);
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
