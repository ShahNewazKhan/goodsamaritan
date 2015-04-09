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

namespace assn2.Controllers.APIControllers.Client
{
    public class IncidentsController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/Incidents
        public IQueryable<Incident> GetIncident()
        {
            return db.Incident;
        }

        // GET: api/Incidents/5
        [ResponseType(typeof(Incident))]
        public async Task<IHttpActionResult> GetIncident(int id)
        {
            Incident incident = await db.Incident.FindAsync(id);
            if (incident == null)
            {
                return NotFound();
            }

            return Ok(incident);
        }

        // PUT: api/Incidents/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutIncident(int id, Incident incident)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != incident.Id)
            {
                return BadRequest();
            }

            db.Entry(incident).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidentExists(id))
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

        // POST: api/Incidents
        [ResponseType(typeof(Incident))]
        public async Task<IHttpActionResult> PostIncident(Incident incident)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Incident.Add(incident);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = incident.Id }, incident);
        }

        // DELETE: api/Incidents/5
        [ResponseType(typeof(Incident))]
        public async Task<IHttpActionResult> DeleteIncident(int id)
        {
            Incident incident = await db.Incident.FindAsync(id);
            if (incident == null)
            {
                return NotFound();
            }

            db.Incident.Remove(incident);
            await db.SaveChangesAsync();

            return Ok(incident);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IncidentExists(int id)
        {
            return db.Incident.Count(e => e.Id == id) > 0;
        }
    }
}