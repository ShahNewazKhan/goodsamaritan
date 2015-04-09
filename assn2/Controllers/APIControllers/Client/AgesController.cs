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
    public class AgesController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/Ages
        public IQueryable<Age> GetAge()
        {
            return db.Age;
        }

        // GET: api/Ages/5
        [ResponseType(typeof(Age))]
        public async Task<IHttpActionResult> GetAge(int id)
        {
            Age age = await db.Age.FindAsync(id);
            if (age == null)
            {
                return NotFound();
            }

            return Ok(age);
        }

        // PUT: api/Ages/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAge(int id, Age age)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != age.Id)
            {
                return BadRequest();
            }

            db.Entry(age).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgeExists(id))
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

        // POST: api/Ages
        [ResponseType(typeof(Age))]
        public async Task<IHttpActionResult> PostAge(Age age)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Age.Add(age);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = age.Id }, age);
        }

        // DELETE: api/Ages/5
        [ResponseType(typeof(Age))]
        public async Task<IHttpActionResult> DeleteAge(int id)
        {
            Age age = await db.Age.FindAsync(id);
            if (age == null)
            {
                return NotFound();
            }

            db.Age.Remove(age);
            await db.SaveChangesAsync();

            return Ok(age);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AgeExists(int id)
        {
            return db.Age.Count(e => e.Id == id) > 0;
        }
    }
}