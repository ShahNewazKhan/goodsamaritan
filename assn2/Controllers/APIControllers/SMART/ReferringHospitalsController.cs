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
    public class ReferringHospitalsController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/ReferringHospitals
        public IQueryable<ReferringHospital> GetReferringHospital()
        {
            return db.ReferringHospital;
        }

        // GET: api/ReferringHospitals/5
        [ResponseType(typeof(ReferringHospital))]
        public async Task<IHttpActionResult> GetReferringHospital(int id)
        {
            ReferringHospital referringHospital = await db.ReferringHospital.FindAsync(id);
            if (referringHospital == null)
            {
                return NotFound();
            }

            return Ok(referringHospital);
        }

        // PUT: api/ReferringHospitals/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutReferringHospital(int id, ReferringHospital referringHospital)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != referringHospital.Id)
            {
                return BadRequest();
            }

            db.Entry(referringHospital).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReferringHospitalExists(id))
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

        // POST: api/ReferringHospitals
        [ResponseType(typeof(ReferringHospital))]
        public async Task<IHttpActionResult> PostReferringHospital(ReferringHospital referringHospital)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ReferringHospital.Add(referringHospital);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = referringHospital.Id }, referringHospital);
        }

        // DELETE: api/ReferringHospitals/5
        [ResponseType(typeof(ReferringHospital))]
        public async Task<IHttpActionResult> DeleteReferringHospital(int id)
        {
            ReferringHospital referringHospital = await db.ReferringHospital.FindAsync(id);
            if (referringHospital == null)
            {
                return NotFound();
            }

            db.ReferringHospital.Remove(referringHospital);
            await db.SaveChangesAsync();

            return Ok(referringHospital);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReferringHospitalExists(int id)
        {
            return db.ReferringHospital.Count(e => e.Id == id) > 0;
        }
    }
}