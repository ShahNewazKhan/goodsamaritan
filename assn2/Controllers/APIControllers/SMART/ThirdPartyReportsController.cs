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
    public class ThirdPartyReportsController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/ThirdPartyReports
        public IQueryable<ThirdPartyReport> GetThirdPartyReport()
        {
            return db.ThirdPartyReport;
        }

        // GET: api/ThirdPartyReports/5
        [ResponseType(typeof(ThirdPartyReport))]
        public async Task<IHttpActionResult> GetThirdPartyReport(int id)
        {
            ThirdPartyReport thirdPartyReport = await db.ThirdPartyReport.FindAsync(id);
            if (thirdPartyReport == null)
            {
                return NotFound();
            }

            return Ok(thirdPartyReport);
        }

        // PUT: api/ThirdPartyReports/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutThirdPartyReport(int id, ThirdPartyReport thirdPartyReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != thirdPartyReport.Id)
            {
                return BadRequest();
            }

            db.Entry(thirdPartyReport).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThirdPartyReportExists(id))
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

        // POST: api/ThirdPartyReports
        [ResponseType(typeof(ThirdPartyReport))]
        public async Task<IHttpActionResult> PostThirdPartyReport(ThirdPartyReport thirdPartyReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ThirdPartyReport.Add(thirdPartyReport);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = thirdPartyReport.Id }, thirdPartyReport);
        }

        // DELETE: api/ThirdPartyReports/5
        [ResponseType(typeof(ThirdPartyReport))]
        public async Task<IHttpActionResult> DeleteThirdPartyReport(int id)
        {
            ThirdPartyReport thirdPartyReport = await db.ThirdPartyReport.FindAsync(id);
            if (thirdPartyReport == null)
            {
                return NotFound();
            }

            db.ThirdPartyReport.Remove(thirdPartyReport);
            await db.SaveChangesAsync();

            return Ok(thirdPartyReport);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ThirdPartyReportExists(int id)
        {
            return db.ThirdPartyReport.Count(e => e.Id == id) > 0;
        }
    }
}