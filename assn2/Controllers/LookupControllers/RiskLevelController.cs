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
    public class RiskLevelController : Controller
    {
        private GSContext db = new GSContext();

        // GET: RiskLevel
        public ActionResult Index()
        {
            return View(db.RiskLevel.ToList());
        }

        // GET: RiskLevel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskLevel riskLevel = db.RiskLevel.Find(id);
            if (riskLevel == null)
            {
                return HttpNotFound();
            }
            return View(riskLevel);
        }

        // GET: RiskLevel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RiskLevel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value")] RiskLevel riskLevel)
        {
            if (ModelState.IsValid)
            {
                db.RiskLevel.Add(riskLevel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(riskLevel);
        }

        // GET: RiskLevel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskLevel riskLevel = db.RiskLevel.Find(id);
            if (riskLevel == null)
            {
                return HttpNotFound();
            }
            return View(riskLevel);
        }

        // POST: RiskLevel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value")] RiskLevel riskLevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(riskLevel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(riskLevel);
        }

        // GET: RiskLevel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskLevel riskLevel = db.RiskLevel.Find(id);
            if (riskLevel == null)
            {
                return HttpNotFound();
            }
            return View(riskLevel);
        }

        // POST: RiskLevel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RiskLevel riskLevel = db.RiskLevel.Find(id);
            db.RiskLevel.Remove(riskLevel);
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
