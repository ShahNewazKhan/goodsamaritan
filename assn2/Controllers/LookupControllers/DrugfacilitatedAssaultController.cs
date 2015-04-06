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
    public class DrugfacilitatedAssaultController : Controller
    {
        private GSContext db = new GSContext();

        // GET: DrugfacilitatedAssault
        public ActionResult Index()
        {
            return View(db.DrugfacilitatedAssault.ToList());
        }

        // GET: DrugfacilitatedAssault/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrugfacilitatedAssault drugfacilitatedAssault = db.DrugfacilitatedAssault.Find(id);
            if (drugfacilitatedAssault == null)
            {
                return HttpNotFound();
            }
            return View(drugfacilitatedAssault);
        }

        // GET: DrugfacilitatedAssault/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DrugfacilitatedAssault/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value")] DrugfacilitatedAssault drugfacilitatedAssault)
        {
            if (ModelState.IsValid)
            {
                db.DrugfacilitatedAssault.Add(drugfacilitatedAssault);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drugfacilitatedAssault);
        }

        // GET: DrugfacilitatedAssault/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrugfacilitatedAssault drugfacilitatedAssault = db.DrugfacilitatedAssault.Find(id);
            if (drugfacilitatedAssault == null)
            {
                return HttpNotFound();
            }
            return View(drugfacilitatedAssault);
        }

        // POST: DrugfacilitatedAssault/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value")] DrugfacilitatedAssault drugfacilitatedAssault)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drugfacilitatedAssault).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drugfacilitatedAssault);
        }

        // GET: DrugfacilitatedAssault/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrugfacilitatedAssault drugfacilitatedAssault = db.DrugfacilitatedAssault.Find(id);
            if (drugfacilitatedAssault == null)
            {
                return HttpNotFound();
            }
            return View(drugfacilitatedAssault);
        }

        // POST: DrugfacilitatedAssault/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DrugfacilitatedAssault drugfacilitatedAssault = db.DrugfacilitatedAssault.Find(id);
            db.DrugfacilitatedAssault.Remove(drugfacilitatedAssault);
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
