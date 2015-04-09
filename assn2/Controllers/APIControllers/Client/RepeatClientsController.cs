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
    public class RepeatClientsController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/RepeatClients
        public IQueryable<RepeatClient> GetRepeatClient()
        {
            return db.RepeatClient;
        }

        // GET: api/RepeatClients/5
        [ResponseType(typeof(RepeatClient))]
        public async Task<IHttpActionResult> GetRepeatClient(int id)
        {
            RepeatClient repeatClient = await db.RepeatClient.FindAsync(id);
            if (repeatClient == null)
            {
                return NotFound();
            }

            return Ok(repeatClient);
        }

        // PUT: api/RepeatClients/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRepeatClient(int id, RepeatClient repeatClient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != repeatClient.Id)
            {
                return BadRequest();
            }

            db.Entry(repeatClient).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepeatClientExists(id))
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

        // POST: api/RepeatClients
        [ResponseType(typeof(RepeatClient))]
        public async Task<IHttpActionResult> PostRepeatClient(RepeatClient repeatClient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RepeatClient.Add(repeatClient);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = repeatClient.Id }, repeatClient);
        }

        // DELETE: api/RepeatClients/5
        [ResponseType(typeof(RepeatClient))]
        public async Task<IHttpActionResult> DeleteRepeatClient(int id)
        {
            RepeatClient repeatClient = await db.RepeatClient.FindAsync(id);
            if (repeatClient == null)
            {
                return NotFound();
            }

            db.RepeatClient.Remove(repeatClient);
            await db.SaveChangesAsync();

            return Ok(repeatClient);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RepeatClientExists(int id)
        {
            return db.RepeatClient.Count(e => e.Id == id) > 0;
        }
    }
}