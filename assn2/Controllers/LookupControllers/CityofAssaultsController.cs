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
    public class CityofAssaultsController : Controller
    {
        private GSContext db = new GSContext();

        // GET: CityofAssaults
        public ActionResult Index()
        {
            return View(db.CityOfAssault.ToList());
        }

        // GET: CityofAssaults/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityofAssault cityofAssault = db.CityOfAssault.Find(id);
            if (cityofAssault == null)
            {
                return HttpNotFound();
            }
            return View(cityofAssault);
        }

        // GET: CityofAssaults/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CityofAssaults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value")] CityofAssault cityofAssault)
        {
            if (ModelState.IsValid)
            {
                db.CityOfAssault.Add(cityofAssault);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cityofAssault);
        }

        // GET: CityofAssaults/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityofAssault cityofAssault = db.CityOfAssault.Find(id);
            if (cityofAssault == null)
            {
                return HttpNotFound();
            }
            return View(cityofAssault);
        }

        // POST: CityofAssaults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value")] CityofAssault cityofAssault)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cityofAssault).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cityofAssault);
        }

        // GET: CityofAssaults/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityofAssault cityofAssault = db.CityOfAssault.Find(id);
            if (cityofAssault == null)
            {
                return HttpNotFound();
            }
            return View(cityofAssault);
        }

        // POST: CityofAssaults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CityofAssault cityofAssault = db.CityOfAssault.Find(id);
            db.CityOfAssault.Remove(cityofAssault);
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
