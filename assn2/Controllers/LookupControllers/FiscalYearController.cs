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
    public class FiscalYearController : Controller
    {
        private GSContext db = new GSContext();

        // GET: FiscalYear
        public ActionResult Index()
        {
            return View(db.FiscalYear.ToList());
        }

        // GET: FiscalYear/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FiscalYear fiscalYear = db.FiscalYear.Find(id);
            if (fiscalYear == null)
            {
                return HttpNotFound();
            }
            return View(fiscalYear);
        }

        // GET: FiscalYear/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FiscalYear/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value")] FiscalYear fiscalYear)
        {
            if (ModelState.IsValid)
            {
                db.FiscalYear.Add(fiscalYear);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fiscalYear);
        }

        // GET: FiscalYear/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FiscalYear fiscalYear = db.FiscalYear.Find(id);
            if (fiscalYear == null)
            {
                return HttpNotFound();
            }
            return View(fiscalYear);
        }

        // POST: FiscalYear/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value")] FiscalYear fiscalYear)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fiscalYear).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fiscalYear);
        }

        // GET: FiscalYear/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FiscalYear fiscalYear = db.FiscalYear.Find(id);
            if (fiscalYear == null)
            {
                return HttpNotFound();
            }
            return View(fiscalYear);
        }

        // POST: FiscalYear/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FiscalYear fiscalYear = db.FiscalYear.Find(id);
            db.FiscalYear.Remove(fiscalYear);
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
