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
    public class PoliceAttendancesController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/PoliceAttendances
        public IQueryable<PoliceAttendance> GetPoliceAttendance()
        {
            return db.PoliceAttendance;
        }

        // GET: api/PoliceAttendances/5
        [ResponseType(typeof(PoliceAttendance))]
        public async Task<IHttpActionResult> GetPoliceAttendance(int id)
        {
            PoliceAttendance policeAttendance = await db.PoliceAttendance.FindAsync(id);
            if (policeAttendance == null)
            {
                return NotFound();
            }

            return Ok(policeAttendance);
        }

        // PUT: api/PoliceAttendances/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPoliceAttendance(int id, PoliceAttendance policeAttendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != policeAttendance.Id)
            {
                return BadRequest();
            }

            db.Entry(policeAttendance).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoliceAttendanceExists(id))
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

        // POST: api/PoliceAttendances
        [ResponseType(typeof(PoliceAttendance))]
        public async Task<IHttpActionResult> PostPoliceAttendance(PoliceAttendance policeAttendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PoliceAttendance.Add(policeAttendance);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = policeAttendance.Id }, policeAttendance);
        }

        // DELETE: api/PoliceAttendances/5
        [ResponseType(typeof(PoliceAttendance))]
        public async Task<IHttpActionResult> DeletePoliceAttendance(int id)
        {
            PoliceAttendance policeAttendance = await db.PoliceAttendance.FindAsync(id);
            if (policeAttendance == null)
            {
                return NotFound();
            }

            db.PoliceAttendance.Remove(policeAttendance);
            await db.SaveChangesAsync();

            return Ok(policeAttendance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PoliceAttendanceExists(int id)
        {
            return db.PoliceAttendance.Count(e => e.Id == id) > 0;
        }
    }
}