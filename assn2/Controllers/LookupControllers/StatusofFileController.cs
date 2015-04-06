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
    public class StatusofFileController : Controller
    {
        private GSContext db = new GSContext();

        // GET: StatusofFile
        public ActionResult Index()
        {
            return View(db.StatusOfFile.ToList());
        }

        // GET: StatusofFile/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusofFile statusofFile = db.StatusOfFile.Find(id);
            if (statusofFile == null)
            {
                return HttpNotFound();
            }
            return View(statusofFile);
        }

        // GET: StatusofFile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusofFile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value")] StatusofFile statusofFile)
        {
            if (ModelState.IsValid)
            {
                db.StatusOfFile.Add(statusofFile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statusofFile);
        }

        // GET: StatusofFile/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusofFile statusofFile = db.StatusOfFile.Find(id);
            if (statusofFile == null)
            {
                return HttpNotFound();
            }
            return View(statusofFile);
        }

        // POST: StatusofFile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value")] StatusofFile statusofFile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statusofFile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statusofFile);
        }

        // GET: StatusofFile/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusofFile statusofFile = db.StatusOfFile.Find(id);
            if (statusofFile == null)
            {
                return HttpNotFound();
            }
            return View(statusofFile);
        }

        // POST: StatusofFile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatusofFile statusofFile = db.StatusOfFile.Find(id);
            db.StatusOfFile.Remove(statusofFile);
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
