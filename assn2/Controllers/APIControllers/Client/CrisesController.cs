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
    public class CrisesController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/Crises
        public IQueryable<Crisis> GetCrisis()
        {
            return db.Crisis;
        }

        // GET: api/Crises/5
        [ResponseType(typeof(Crisis))]
        public async Task<IHttpActionResult> GetCrisis(int id)
        {
            Crisis crisis = await db.Crisis.FindAsync(id);
            if (crisis == null)
            {
                return NotFound();
            }

            return Ok(crisis);
        }

        // PUT: api/Crises/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCrisis(int id, Crisis crisis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != crisis.Id)
            {
                return BadRequest();
            }

            db.Entry(crisis).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CrisisExists(id))
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

        // POST: api/Crises
        [ResponseType(typeof(Crisis))]
        public async Task<IHttpActionResult> PostCrisis(Crisis crisis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Crisis.Add(crisis);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = crisis.Id }, crisis);
        }

        // DELETE: api/Crises/5
        [ResponseType(typeof(Crisis))]
        public async Task<IHttpActionResult> DeleteCrisis(int id)
        {
            Crisis crisis = await db.Crisis.FindAsync(id);
            if (crisis == null)
            {
                return NotFound();
            }

            db.Crisis.Remove(crisis);
            await db.SaveChangesAsync();

            return Ok(crisis);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CrisisExists(int id)
        {
            return db.Crisis.Count(e => e.Id == id) > 0;
        }
    }
}