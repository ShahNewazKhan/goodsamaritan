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
    public class RepeatClientController : Controller
    {
        private GSContext db = new GSContext();

        // GET: RepeatClient
        public ActionResult Index()
        {
            return View(db.RepeatClient.ToList());
        }

        // GET: RepeatClient/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepeatClient repeatClient = db.RepeatClient.Find(id);
            if (repeatClient == null)
            {
                return HttpNotFound();
            }
            return View(repeatClient);
        }

        // GET: RepeatClient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RepeatClient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value")] RepeatClient repeatClient)
        {
            if (ModelState.IsValid)
            {
                db.RepeatClient.Add(repeatClient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(repeatClient);
        }

        // GET: RepeatClient/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepeatClient repeatClient = db.RepeatClient.Find(id);
            if (repeatClient == null)
            {
                return HttpNotFound();
            }
            return View(repeatClient);
        }

        // POST: RepeatClient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value")] RepeatClient repeatClient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repeatClient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(repeatClient);
        }

        // GET: RepeatClient/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepeatClient repeatClient = db.RepeatClient.Find(id);
            if (repeatClient == null)
            {
                return HttpNotFound();
            }
            return View(repeatClient);
        }

        // POST: RepeatClient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RepeatClient repeatClient = db.RepeatClient.Find(id);
            db.RepeatClient.Remove(repeatClient);
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
