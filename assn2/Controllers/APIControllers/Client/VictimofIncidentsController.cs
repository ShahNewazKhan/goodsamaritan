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
    public class VictimofIncidentsController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/VictimofIncidents
        public IQueryable<VictimofIncident> GetIncidentVictim()
        {
            return db.IncidentVictim;
        }

        // GET: api/VictimofIncidents/5
        [ResponseType(typeof(VictimofIncident))]
        public async Task<IHttpActionResult> GetVictimofIncident(int id)
        {
            VictimofIncident victimofIncident = await db.IncidentVictim.FindAsync(id);
            if (victimofIncident == null)
            {
                return NotFound();
            }

            return Ok(victimofIncident);
        }

        // PUT: api/VictimofIncidents/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVictimofIncident(int id, VictimofIncident victimofIncident)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != victimofIncident.Id)
            {
                return BadRequest();
            }

            db.Entry(victimofIncident).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VictimofIncidentExists(id))
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

        // POST: api/VictimofIncidents
        [ResponseType(typeof(VictimofIncident))]
        public async Task<IHttpActionResult> PostVictimofIncident(VictimofIncident victimofIncident)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IncidentVictim.Add(victimofIncident);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = victimofIncident.Id }, victimofIncident);
        }

        // DELETE: api/VictimofIncidents/5
        [ResponseType(typeof(VictimofIncident))]
        public async Task<IHttpActionResult> DeleteVictimofIncident(int id)
        {
            VictimofIncident victimofIncident = await db.IncidentVictim.FindAsync(id);
            if (victimofIncident == null)
            {
                return NotFound();
            }

            db.IncidentVictim.Remove(victimofIncident);
            await db.SaveChangesAsync();

            return Ok(victimofIncident);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VictimofIncidentExists(int id)
        {
            return db.IncidentVictim.Count(e => e.Id == id) > 0;
        }
    }
}