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
    public class CityofResidenceController : Controller
    {
        private GSContext db = new GSContext();

        // GET: CityofResidence
        public ActionResult Index()
        {
            return View(db.CityOfResidence.ToList());
        }

        // GET: CityofResidence/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityofResidence cityofResidence = db.CityOfResidence.Find(id);
            if (cityofResidence == null)
            {
                return HttpNotFound();
            }
            return View(cityofResidence);
        }

        // GET: CityofResidence/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CityofResidence/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value")] CityofResidence cityofResidence)
        {
            if (ModelState.IsValid)
            {
                db.CityOfResidence.Add(cityofResidence);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cityofResidence);
        }

        // GET: CityofResidence/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityofResidence cityofResidence = db.CityOfResidence.Find(id);
            if (cityofResidence == null)
            {
                return HttpNotFound();
            }
            return View(cityofResidence);
        }

        // POST: CityofResidence/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value")] CityofResidence cityofResidence)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cityofResidence).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cityofResidence);
        }

        // GET: CityofResidence/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityofResidence cityofResidence = db.CityOfResidence.Find(id);
            if (cityofResidence == null)
            {
                return HttpNotFound();
            }
            return View(cityofResidence);
        }

        // POST: CityofResidence/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CityofResidence cityofResidence = db.CityOfResidence.Find(id);
            db.CityOfResidence.Remove(cityofResidence);
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
