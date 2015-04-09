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
    public class ReferredtoCBVSController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/ReferredtoCBVS
        public IQueryable<ReferredtoCBVS> GetReferredtoCBVS()
        {
            return db.ReferredtoCBVS;
        }

        // GET: api/ReferredtoCBVS/5
        [ResponseType(typeof(ReferredtoCBVS))]
        public async Task<IHttpActionResult> GetReferredtoCBVS(int id)
        {
            ReferredtoCBVS referredtoCBVS = await db.ReferredtoCBVS.FindAsync(id);
            if (referredtoCBVS == null)
            {
                return NotFound();
            }

            return Ok(referredtoCBVS);
        }

        // PUT: api/ReferredtoCBVS/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutReferredtoCBVS(int id, ReferredtoCBVS referredtoCBVS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != referredtoCBVS.Id)
            {
                return BadRequest();
            }

            db.Entry(referredtoCBVS).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReferredtoCBVSExists(id))
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

        // POST: api/ReferredtoCBVS
        [ResponseType(typeof(ReferredtoCBVS))]
        public async Task<IHttpActionResult> PostReferredtoCBVS(ReferredtoCBVS referredtoCBVS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ReferredtoCBVS.Add(referredtoCBVS);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = referredtoCBVS.Id }, referredtoCBVS);
        }

        // DELETE: api/ReferredtoCBVS/5
        [ResponseType(typeof(ReferredtoCBVS))]
        public async Task<IHttpActionResult> DeleteReferredtoCBVS(int id)
        {
            ReferredtoCBVS referredtoCBVS = await db.ReferredtoCBVS.FindAsync(id);
            if (referredtoCBVS == null)
            {
                return NotFound();
            }

            db.ReferredtoCBVS.Remove(referredtoCBVS);
            await db.SaveChangesAsync();

            return Ok(referredtoCBVS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReferredtoCBVSExists(int id)
        {
            return db.ReferredtoCBVS.Count(e => e.Id == id) > 0;
        }
    }
}