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
    public class VictimServicesAttendancesController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/VictimServicesAttendances
        public IQueryable<VictimServicesAttendance> GetVictimServicesAttendance()
        {
            return db.VictimServicesAttendance;
        }

        // GET: api/VictimServicesAttendances/5
        [ResponseType(typeof(VictimServicesAttendance))]
        public async Task<IHttpActionResult> GetVictimServicesAttendance(int id)
        {
            VictimServicesAttendance victimServicesAttendance = await db.VictimServicesAttendance.FindAsync(id);
            if (victimServicesAttendance == null)
            {
                return NotFound();
            }

            return Ok(victimServicesAttendance);
        }

        // PUT: api/VictimServicesAttendances/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVictimServicesAttendance(int id, VictimServicesAttendance victimServicesAttendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != victimServicesAttendance.Id)
            {
                return BadRequest();
            }

            db.Entry(victimServicesAttendance).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VictimServicesAttendanceExists(id))
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

        // POST: api/VictimServicesAttendances
        [ResponseType(typeof(VictimServicesAttendance))]
        public async Task<IHttpActionResult> PostVictimServicesAttendance(VictimServicesAttendance victimServicesAttendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VictimServicesAttendance.Add(victimServicesAttendance);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = victimServicesAttendance.Id }, victimServicesAttendance);
        }

        // DELETE: api/VictimServicesAttendances/5
        [ResponseType(typeof(VictimServicesAttendance))]
        public async Task<IHttpActionResult> DeleteVictimServicesAttendance(int id)
        {
            VictimServicesAttendance victimServicesAttendance = await db.VictimServicesAttendance.FindAsync(id);
            if (victimServicesAttendance == null)
            {
                return NotFound();
            }

            db.VictimServicesAttendance.Remove(victimServicesAttendance);
            await db.SaveChangesAsync();

            return Ok(victimServicesAttendance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VictimServicesAttendanceExists(int id)
        {
            return db.VictimServicesAttendance.Count(e => e.Id == id) > 0;
        }
    }
}