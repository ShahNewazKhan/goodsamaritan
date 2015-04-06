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
    public class AssignedWorkerController : Controller
    {
        private GSContext db = new GSContext();

        // GET: AssignedWorker
        public ActionResult Index()
        {
            return View(db.AssignedWorker.ToList());
        }

        // GET: AssignedWorker/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedWorker assignedWorker = db.AssignedWorker.Find(id);
            if (assignedWorker == null)
            {
                return HttpNotFound();
            }
            return View(assignedWorker);
        }

        // GET: AssignedWorker/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssignedWorker/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value")] AssignedWorker assignedWorker)
        {
            if (ModelState.IsValid)
            {
                db.AssignedWorker.Add(assignedWorker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assignedWorker);
        }

        // GET: AssignedWorker/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedWorker assignedWorker = db.AssignedWorker.Find(id);
            if (assignedWorker == null)
            {
                return HttpNotFound();
            }
            return View(assignedWorker);
        }

        // POST: AssignedWorker/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value")] AssignedWorker assignedWorker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignedWorker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assignedWorker);
        }

        // GET: AssignedWorker/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedWorker assignedWorker = db.AssignedWorker.Find(id);
            if (assignedWorker == null)
            {
                return HttpNotFound();
            }
            return View(assignedWorker);
        }

        // POST: AssignedWorker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssignedWorker assignedWorker = db.AssignedWorker.Find(id);
            db.AssignedWorker.Remove(assignedWorker);
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
