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
    public class ReferredtoCBVSController : Controller
    {
        private GSContext db = new GSContext();

        // GET: ReferredtoCBVS
        public ActionResult Index()
        {
            return View(db.ReferredtoCBVS.ToList());
        }

        // GET: ReferredtoCBVS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferredtoCBVS referredtoCBVS = db.ReferredtoCBVS.Find(id);
            if (referredtoCBVS == null)
            {
                return HttpNotFound();
            }
            return View(referredtoCBVS);
        }

        // GET: ReferredtoCBVS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReferredtoCBVS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value")] ReferredtoCBVS referredtoCBVS)
        {
            if (ModelState.IsValid)
            {
                db.ReferredtoCBVS.Add(referredtoCBVS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(referredtoCBVS);
        }

        // GET: ReferredtoCBVS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferredtoCBVS referredtoCBVS = db.ReferredtoCBVS.Find(id);
            if (referredtoCBVS == null)
            {
                return HttpNotFound();
            }
            return View(referredtoCBVS);
        }

        // POST: ReferredtoCBVS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value")] ReferredtoCBVS referredtoCBVS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(referredtoCBVS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(referredtoCBVS);
        }

        // GET: ReferredtoCBVS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferredtoCBVS referredtoCBVS = db.ReferredtoCBVS.Find(id);
            if (referredtoCBVS == null)
            {
                return HttpNotFound();
            }
            return View(referredtoCBVS);
        }

        // POST: ReferredtoCBVS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReferredtoCBVS referredtoCBVS = db.ReferredtoCBVS.Find(id);
            db.ReferredtoCBVS.Remove(referredtoCBVS);
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
