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
    public class VictimofIncidentController : Controller
    {
        private GSContext db = new GSContext();

        // GET: VictimofIncident
        public ActionResult Index()
        {
            return View(db.IncidentVictim.ToList());
        }

        // GET: VictimofIncident/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VictimofIncident victimofIncident = db.IncidentVictim.Find(id);
            if (victimofIncident == null)
            {
                return HttpNotFound();
            }
            return View(victimofIncident);
        }

        // GET: VictimofIncident/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VictimofIncident/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value")] VictimofIncident victimofIncident)
        {
            if (ModelState.IsValid)
            {
                db.IncidentVictim.Add(victimofIncident);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(victimofIncident);
        }

        // GET: VictimofIncident/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VictimofIncident victimofIncident = db.IncidentVictim.Find(id);
            if (victimofIncident == null)
            {
                return HttpNotFound();
            }
            return View(victimofIncident);
        }

        // POST: VictimofIncident/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value")] VictimofIncident victimofIncident)
        {
            if (ModelState.IsValid)
            {
                db.Entry(victimofIncident).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(victimofIncident);
        }

        // GET: VictimofIncident/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VictimofIncident victimofIncident = db.IncidentVictim.Find(id);
            if (victimofIncident == null)
            {
                return HttpNotFound();
            }
            return View(victimofIncident);
        }

        // POST: VictimofIncident/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VictimofIncident victimofIncident = db.IncidentVictim.Find(id);
            db.IncidentVictim.Remove(victimofIncident);
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
