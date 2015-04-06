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
    public class DuplicateFileController : Controller
    {
        private GSContext db = new GSContext();

        // GET: DuplicateFile
        public ActionResult Index()
        {
            return View(db.DuplicateFile.ToList());
        }

        // GET: DuplicateFile/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DuplicateFile duplicateFile = db.DuplicateFile.Find(id);
            if (duplicateFile == null)
            {
                return HttpNotFound();
            }
            return View(duplicateFile);
        }

        // GET: DuplicateFile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DuplicateFile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value")] DuplicateFile duplicateFile)
        {
            if (ModelState.IsValid)
            {
                db.DuplicateFile.Add(duplicateFile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(duplicateFile);
        }

        // GET: DuplicateFile/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DuplicateFile duplicateFile = db.DuplicateFile.Find(id);
            if (duplicateFile == null)
            {
                return HttpNotFound();
            }
            return View(duplicateFile);
        }

        // POST: DuplicateFile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value")] DuplicateFile duplicateFile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(duplicateFile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(duplicateFile);
        }

        // GET: DuplicateFile/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DuplicateFile duplicateFile = db.DuplicateFile.Find(id);
            if (duplicateFile == null)
            {
                return HttpNotFound();
            }
            return View(duplicateFile);
        }

        // POST: DuplicateFile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DuplicateFile duplicateFile = db.DuplicateFile.Find(id);
            db.DuplicateFile.Remove(duplicateFile);
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
