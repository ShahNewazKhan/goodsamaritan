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
    public class SocialWorkAttendanceController : Controller
    {
        private GSContext db = new GSContext();

        // GET: SocialWorkAttendance
        public ActionResult Index()
        {
            return View(db.SocialWorkAttendance.ToList());
        }

        // GET: SocialWorkAttendance/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialWorkAttendance socialWorkAttendance = db.SocialWorkAttendance.Find(id);
            if (socialWorkAttendance == null)
            {
                return HttpNotFound();
            }
            return View(socialWorkAttendance);
        }

        // GET: SocialWorkAttendance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SocialWorkAttendance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value")] SocialWorkAttendance socialWorkAttendance)
        {
            if (ModelState.IsValid)
            {
                db.SocialWorkAttendance.Add(socialWorkAttendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(socialWorkAttendance);
        }

        // GET: SocialWorkAttendance/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialWorkAttendance socialWorkAttendance = db.SocialWorkAttendance.Find(id);
            if (socialWorkAttendance == null)
            {
                return HttpNotFound();
            }
            return View(socialWorkAttendance);
        }

        // POST: SocialWorkAttendance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value")] SocialWorkAttendance socialWorkAttendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socialWorkAttendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(socialWorkAttendance);
        }

        // GET: SocialWorkAttendance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialWorkAttendance socialWorkAttendance = db.SocialWorkAttendance.Find(id);
            if (socialWorkAttendance == null)
            {
                return HttpNotFound();
            }
            return View(socialWorkAttendance);
        }

        // POST: SocialWorkAttendance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SocialWorkAttendance socialWorkAttendance = db.SocialWorkAttendance.Find(id);
            db.SocialWorkAttendance.Remove(socialWorkAttendance);
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
