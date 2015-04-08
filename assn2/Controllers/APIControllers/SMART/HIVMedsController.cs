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
    public class HIVMedsController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/HIVMeds
        public IQueryable<HIVMeds> GetHIVMeds()
        {
            return db.HIVMeds;
        }

        // GET: api/HIVMeds/5
        [ResponseType(typeof(HIVMeds))]
        public async Task<IHttpActionResult> GetHIVMeds(int id)
        {
            HIVMeds hIVMeds = await db.HIVMeds.FindAsync(id);
            if (hIVMeds == null)
            {
                return NotFound();
            }

            return Ok(hIVMeds);
        }

        // PUT: api/HIVMeds/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHIVMeds(int id, HIVMeds hIVMeds)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hIVMeds.Id)
            {
                return BadRequest();
            }

            db.Entry(hIVMeds).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HIVMedsExists(id))
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

        // POST: api/HIVMeds
        [ResponseType(typeof(HIVMeds))]
        public async Task<IHttpActionResult> PostHIVMeds(HIVMeds hIVMeds)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HIVMeds.Add(hIVMeds);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = hIVMeds.Id }, hIVMeds);
        }

        // DELETE: api/HIVMeds/5
        [ResponseType(typeof(HIVMeds))]
        public async Task<IHttpActionResult> DeleteHIVMeds(int id)
        {
            HIVMeds hIVMeds = await db.HIVMeds.FindAsync(id);
            if (hIVMeds == null)
            {
                return NotFound();
            }

            db.HIVMeds.Remove(hIVMeds);
            await db.SaveChangesAsync();

            return Ok(hIVMeds);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HIVMedsExists(int id)
        {
            return db.HIVMeds.Count(e => e.Id == id) > 0;
        }
    }
}