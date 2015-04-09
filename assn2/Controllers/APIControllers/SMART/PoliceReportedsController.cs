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
    public class PoliceReportedsController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/PoliceReporteds
        public IQueryable<PoliceReported> GetPoliceReported()
        {
            return db.PoliceReported;
        }

        // GET: api/PoliceReporteds/5
        [ResponseType(typeof(PoliceReported))]
        public async Task<IHttpActionResult> GetPoliceReported(int id)
        {
            PoliceReported policeReported = await db.PoliceReported.FindAsync(id);
            if (policeReported == null)
            {
                return NotFound();
            }

            return Ok(policeReported);
        }

        // PUT: api/PoliceReporteds/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPoliceReported(int id, PoliceReported policeReported)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != policeReported.Id)
            {
                return BadRequest();
            }

            db.Entry(policeReported).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoliceReportedExists(id))
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

        // POST: api/PoliceReporteds
        [ResponseType(typeof(PoliceReported))]
        public async Task<IHttpActionResult> PostPoliceReported(PoliceReported policeReported)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PoliceReported.Add(policeReported);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = policeReported.Id }, policeReported);
        }

        // DELETE: api/PoliceReporteds/5
        [ResponseType(typeof(PoliceReported))]
        public async Task<IHttpActionResult> DeletePoliceReported(int id)
        {
            PoliceReported policeReported = await db.PoliceReported.FindAsync(id);
            if (policeReported == null)
            {
                return NotFound();
            }

            db.PoliceReported.Remove(policeReported);
            await db.SaveChangesAsync();

            return Ok(policeReported);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PoliceReportedExists(int id)
        {
            return db.PoliceReported.Count(e => e.Id == id) > 0;
        }
    }
}