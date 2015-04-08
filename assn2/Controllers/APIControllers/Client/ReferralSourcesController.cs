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
    public class ReferralSourcesController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/ReferralSources
        public IQueryable<ReferralSource> GetReferralSource()
        {
            return db.ReferralSource;
        }

        // GET: api/ReferralSources/5
        [ResponseType(typeof(ReferralSource))]
        public async Task<IHttpActionResult> GetReferralSource(int id)
        {
            ReferralSource referralSource = await db.ReferralSource.FindAsync(id);
            if (referralSource == null)
            {
                return NotFound();
            }

            return Ok(referralSource);
        }

        // PUT: api/ReferralSources/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutReferralSource(int id, ReferralSource referralSource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != referralSource.Id)
            {
                return BadRequest();
            }

            db.Entry(referralSource).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReferralSourceExists(id))
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

        // POST: api/ReferralSources
        [ResponseType(typeof(ReferralSource))]
        public async Task<IHttpActionResult> PostReferralSource(ReferralSource referralSource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ReferralSource.Add(referralSource);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = referralSource.Id }, referralSource);
        }

        // DELETE: api/ReferralSources/5
        [ResponseType(typeof(ReferralSource))]
        public async Task<IHttpActionResult> DeleteReferralSource(int id)
        {
            ReferralSource referralSource = await db.ReferralSource.FindAsync(id);
            if (referralSource == null)
            {
                return NotFound();
            }

            db.ReferralSource.Remove(referralSource);
            await db.SaveChangesAsync();

            return Ok(referralSource);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReferralSourceExists(int id)
        {
            return db.ReferralSource.Count(e => e.Id == id) > 0;
        }
    }
}