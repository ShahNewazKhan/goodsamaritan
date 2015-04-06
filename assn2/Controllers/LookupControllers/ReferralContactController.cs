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
    public class ReferralContactController : Controller
    {
        private GSContext db = new GSContext();

        // GET: ReferralContact
        public ActionResult Index()
        {
            return View(db.ReferralContact.ToList());
        }

        // GET: ReferralContact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferralContact referralContact = db.ReferralContact.Find(id);
            if (referralContact == null)
            {
                return HttpNotFound();
            }
            return View(referralContact);
        }

        // GET: ReferralContact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReferralContact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value")] ReferralContact referralContact)
        {
            if (ModelState.IsValid)
            {
                db.ReferralContact.Add(referralContact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(referralContact);
        }

        // GET: ReferralContact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferralContact referralContact = db.ReferralContact.Find(id);
            if (referralContact == null)
            {
                return HttpNotFound();
            }
            return View(referralContact);
        }

        // POST: ReferralContact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value")] ReferralContact referralContact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(referralContact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(referralContact);
        }

        // GET: ReferralContact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferralContact referralContact = db.ReferralContact.Find(id);
            if (referralContact == null)
            {
                return HttpNotFound();
            }
            return View(referralContact);
        }

        // POST: ReferralContact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReferralContact referralContact = db.ReferralContact.Find(id);
            db.ReferralContact.Remove(referralContact);
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
