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
    public class VictimServicesAttendanceController : Controller
    {
        private GSContext db = new GSContext();

        // GET: VictimServicesAttendance
        public ActionResult Index()
        {
            return View(db.VictimServicesAttendance.ToList());
        }

        // GET: VictimServicesAttendance/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VictimServicesAttendance victimServicesAttendance = db.VictimServicesAttendance.Find(id);
            if (victimServicesAttendance == null)
            {
                return HttpNotFound();
            }
            return View(victimServicesAttendance);
        }

        // GET: VictimServicesAttendance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VictimServicesAttendance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value")] VictimServicesAttendance victimServicesAttendance)
        {
            if (ModelState.IsValid)
            {
                db.VictimServicesAttendance.Add(victimServicesAttendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(victimServicesAttendance);
        }

        // GET: VictimServicesAttendance/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VictimServicesAttendance victimServicesAttendance = db.VictimServicesAttendance.Find(id);
            if (victimServicesAttendance == null)
            {
                return HttpNotFound();
            }
            return View(victimServicesAttendance);
        }

        // POST: VictimServicesAttendance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value")] VictimServicesAttendance victimServicesAttendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(victimServicesAttendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(victimServicesAttendance);
        }

        // GET: VictimServicesAttendance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VictimServicesAttendance victimServicesAttendance = db.VictimServicesAttendance.Find(id);
            if (victimServicesAttendance == null)
            {
                return HttpNotFound();
            }
            return View(victimServicesAttendance);
        }

        // POST: VictimServicesAttendance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VictimServicesAttendance victimServicesAttendance = db.VictimServicesAttendance.Find(id);
            db.VictimServicesAttendance.Remove(victimServicesAttendance);
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
