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
    public class AbuserRelationshipsController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/AbuserRelationships
        public IQueryable<AbuserRelationship> GetAbuserRelationship()
        {
            return db.AbuserRelationship;
        }

        // GET: api/AbuserRelationships/5
        [ResponseType(typeof(AbuserRelationship))]
        public async Task<IHttpActionResult> GetAbuserRelationship(int id)
        {
            AbuserRelationship abuserRelationship = await db.AbuserRelationship.FindAsync(id);
            if (abuserRelationship == null)
            {
                return NotFound();
            }

            return Ok(abuserRelationship);
        }

        // PUT: api/AbuserRelationships/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAbuserRelationship(int id, AbuserRelationship abuserRelationship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != abuserRelationship.Id)
            {
                return BadRequest();
            }

            db.Entry(abuserRelationship).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbuserRelationshipExists(id))
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

        // POST: api/AbuserRelationships
        [ResponseType(typeof(AbuserRelationship))]
        public async Task<IHttpActionResult> PostAbuserRelationship(AbuserRelationship abuserRelationship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AbuserRelationship.Add(abuserRelationship);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = abuserRelationship.Id }, abuserRelationship);
        }

        // DELETE: api/AbuserRelationships/5
        [ResponseType(typeof(AbuserRelationship))]
        public async Task<IHttpActionResult> DeleteAbuserRelationship(int id)
        {
            AbuserRelationship abuserRelationship = await db.AbuserRelationship.FindAsync(id);
            if (abuserRelationship == null)
            {
                return NotFound();
            }

            db.AbuserRelationship.Remove(abuserRelationship);
            await db.SaveChangesAsync();

            return Ok(abuserRelationship);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AbuserRelationshipExists(int id)
        {
            return db.AbuserRelationship.Count(e => e.Id == id) > 0;
        }
    }
}