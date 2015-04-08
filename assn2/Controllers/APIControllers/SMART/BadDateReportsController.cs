using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using assn2.DAL;
using assn2.Models;

namespace assn2.Controllers.APIControllers.SMART
{
    public class BadDateReportsController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/BadDateReports
        public List<BadDateReport> GetBadDateReport()
        {
            return db.BadDateReport.ToList();
        }

        // GET: api/BadDateReports/5
        [ResponseType(typeof(BadDateReport))]
        public async Task<IHttpActionResult> GetBadDateReport(int id)
        {
            BadDateReport badDateReport = await db.BadDateReport.FindAsync(id);
            if (badDateReport == null)
            {
                return NotFound();
            }

            return Ok(badDateReport);
        }

        // PUT: api/BadDateReports/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBadDateReport(int id, BadDateReport badDateReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != badDateReport.Id)
            {
                return BadRequest();
            }

            db.Entry(badDateReport).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BadDateReportExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BadDateReports
        [ResponseType(typeof(BadDateReport))]
        public async Task<IHttpActionResult> PostBadDateReport(BadDateReport badDateReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BadDateReport.Add(badDateReport);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = badDateReport.Id }, badDateReport);
        }

        // DELETE: api/BadDateReports/5
        [ResponseType(typeof(BadDateReport))]
        public async Task<IHttpActionResult> DeleteBadDateReport(int id)
        {
            BadDateReport badDateReport = await db.BadDateReport.FindAsync(id);
            if (badDateReport == null)
            {
                return NotFound();
            }

            db.BadDateReport.Remove(badDateReport);
            await db.SaveChangesAsync();

            return Ok(badDateReport);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BadDateReportExists(int id)
        {
            return db.BadDateReport.Count(e => e.Id == id) > 0;
        }
    }
}