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
    public class ReferralSourceController : Controller
    {
        private GSContext db = new GSContext();

        // GET: ReferralSource
        public ActionResult Index()
        {
            return View(db.ReferralSource.ToList());
        }

        // GET: ReferralSource/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferralSource referralSource = db.ReferralSource.Find(id);
            if (referralSource == null)
            {
                return HttpNotFound();
            }
            return View(referralSource);
        }

        // GET: ReferralSource/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReferralSource/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value")] ReferralSource referralSource)
        {
            if (ModelState.IsValid)
            {
                db.ReferralSource.Add(referralSource);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(referralSource);
        }

        // GET: ReferralSource/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferralSource referralSource = db.ReferralSource.Find(id);
            if (referralSource == null)
            {
                return HttpNotFound();
            }
            return View(referralSource);
        }

        // POST: ReferralSource/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value")] ReferralSource referralSource)
        {
            if (ModelState.IsValid)
            {
                db.Entry(referralSource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(referralSource);
        }

        // GET: ReferralSource/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferralSource referralSource = db.ReferralSource.Find(id);
            if (referralSource == null)
            {
                return HttpNotFound();
            }
            return View(referralSource);
        }

        // POST: ReferralSource/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReferralSource referralSource = db.ReferralSource.Find(id);
            db.ReferralSource.Remove(referralSource);
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
