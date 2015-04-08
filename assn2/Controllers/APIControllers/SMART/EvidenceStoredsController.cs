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
    public class EvidenceStoredsController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/EvidenceStoreds
        public IQueryable<EvidenceStored> GetEvidenceStored()
        {
            return db.EvidenceStored;
        }

        // GET: api/EvidenceStoreds/5
        [ResponseType(typeof(EvidenceStored))]
        public async Task<IHttpActionResult> GetEvidenceStored(int id)
        {
            EvidenceStored evidenceStored = await db.EvidenceStored.FindAsync(id);
            if (evidenceStored == null)
            {
                return NotFound();
            }

            return Ok(evidenceStored);
        }

        // PUT: api/EvidenceStoreds/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEvidenceStored(int id, EvidenceStored evidenceStored)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != evidenceStored.Id)
            {
                return BadRequest();
            }

            db.Entry(evidenceStored).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvidenceStoredExists(id))
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

        // POST: api/EvidenceStoreds
        [ResponseType(typeof(EvidenceStored))]
        public async Task<IHttpActionResult> PostEvidenceStored(EvidenceStored evidenceStored)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EvidenceStored.Add(evidenceStored);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = evidenceStored.Id }, evidenceStored);
        }

        // DELETE: api/EvidenceStoreds/5
        [ResponseType(typeof(EvidenceStored))]
        public async Task<IHttpActionResult> DeleteEvidenceStored(int id)
        {
            EvidenceStored evidenceStored = await db.EvidenceStored.FindAsync(id);
            if (evidenceStored == null)
            {
                return NotFound();
            }

            db.EvidenceStored.Remove(evidenceStored);
            await db.SaveChangesAsync();

            return Ok(evidenceStored);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EvidenceStoredExists(int id)
        {
            return db.EvidenceStored.Count(e => e.Id == id) > 0;
        }
    }
}