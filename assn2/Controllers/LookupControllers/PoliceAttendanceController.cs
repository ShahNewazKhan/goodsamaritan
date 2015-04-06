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
    public class PoliceAttendanceController : Controller
    {
        private GSContext db = new GSContext();

        // GET: PoliceAttendance
        public ActionResult Index()
        {
            return View(db.PoliceAttendance.ToList());
        }

        // GET: PoliceAttendance/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoliceAttendance policeAttendance = db.PoliceAttendance.Find(id);
            if (policeAttendance == null)
            {
                return HttpNotFound();
            }
            return View(policeAttendance);
        }

        // GET: PoliceAttendance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PoliceAttendance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value")] PoliceAttendance policeAttendance)
        {
            if (ModelState.IsValid)
            {
                db.PoliceAttendance.Add(policeAttendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(policeAttendance);
        }

        // GET: PoliceAttendance/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoliceAttendance policeAttendance = db.PoliceAttendance.Find(id);
            if (policeAttendance == null)
            {
                return HttpNotFound();
            }
            return View(policeAttendance);
        }

        // POST: PoliceAttendance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value")] PoliceAttendance policeAttendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(policeAttendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(policeAttendance);
        }

        // GET: PoliceAttendance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoliceAttendance policeAttendance = db.PoliceAttendance.Find(id);
            if (policeAttendance == null)
            {
                return HttpNotFound();
            }
            return View(policeAttendance);
        }

        // POST: PoliceAttendance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PoliceAttendance policeAttendance = db.PoliceAttendance.Find(id);
            db.PoliceAttendance.Remove(policeAttendance);
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
