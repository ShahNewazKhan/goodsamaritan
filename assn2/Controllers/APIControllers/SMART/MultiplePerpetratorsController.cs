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
    public class MultiplePerpetratorsController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/MultiplePerpetrators
        public IQueryable<MultiplePerpetrators> GetMultiplePerpetrators()
        {
            return db.MultiplePerpetrators;
        }

        // GET: api/MultiplePerpetrators/5
        [ResponseType(typeof(MultiplePerpetrators))]
        public async Task<IHttpActionResult> GetMultiplePerpetrators(int id)
        {
            MultiplePerpetrators multiplePerpetrators = await db.MultiplePerpetrators.FindAsync(id);
            if (multiplePerpetrators == null)
            {
                return NotFound();
            }

            return Ok(multiplePerpetrators);
        }

        // PUT: api/MultiplePerpetrators/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMultiplePerpetrators(int id, MultiplePerpetrators multiplePerpetrators)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != multiplePerpetrators.Id)
            {
                return BadRequest();
            }

            db.Entry(multiplePerpetrators).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MultiplePerpetratorsExists(id))
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

        // POST: api/MultiplePerpetrators
        [ResponseType(typeof(MultiplePerpetrators))]
        public async Task<IHttpActionResult> PostMultiplePerpetrators(MultiplePerpetrators multiplePerpetrators)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MultiplePerpetrators.Add(multiplePerpetrators);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = multiplePerpetrators.Id }, multiplePerpetrators);
        }

        // DELETE: api/MultiplePerpetrators/5
        [ResponseType(typeof(MultiplePerpetrators))]
        public async Task<IHttpActionResult> DeleteMultiplePerpetrators(int id)
        {
            MultiplePerpetrators multiplePerpetrators = await db.MultiplePerpetrators.FindAsync(id);
            if (multiplePerpetrators == null)
            {
                return NotFound();
            }

            db.MultiplePerpetrators.Remove(multiplePerpetrators);
            await db.SaveChangesAsync();

            return Ok(multiplePerpetrators);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MultiplePerpetratorsExists(int id)
        {
            return db.MultiplePerpetrators.Count(e => e.Id == id) > 0;
        }
    }
}