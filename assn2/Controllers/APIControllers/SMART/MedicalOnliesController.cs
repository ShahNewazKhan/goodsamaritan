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
    public class MedicalOnliesController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/MedicalOnlies
        public IQueryable<MedicalOnly> GetMedicalOnly()
        {
            return db.MedicalOnly;
        }

        // GET: api/MedicalOnlies/5
        [ResponseType(typeof(MedicalOnly))]
        public async Task<IHttpActionResult> GetMedicalOnly(int id)
        {
            MedicalOnly medicalOnly = await db.MedicalOnly.FindAsync(id);
            if (medicalOnly == null)
            {
                return NotFound();
            }

            return Ok(medicalOnly);
        }

        // PUT: api/MedicalOnlies/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMedicalOnly(int id, MedicalOnly medicalOnly)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medicalOnly.Id)
            {
                return BadRequest();
            }

            db.Entry(medicalOnly).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalOnlyExists(id))
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

        // POST: api/MedicalOnlies
        [ResponseType(typeof(MedicalOnly))]
        public async Task<IHttpActionResult> PostMedicalOnly(MedicalOnly medicalOnly)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MedicalOnly.Add(medicalOnly);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = medicalOnly.Id }, medicalOnly);
        }

        // DELETE: api/MedicalOnlies/5
        [ResponseType(typeof(MedicalOnly))]
        public async Task<IHttpActionResult> DeleteMedicalOnly(int id)
        {
            MedicalOnly medicalOnly = await db.MedicalOnly.FindAsync(id);
            if (medicalOnly == null)
            {
                return NotFound();
            }

            db.MedicalOnly.Remove(medicalOnly);
            await db.SaveChangesAsync();

            return Ok(medicalOnly);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MedicalOnlyExists(int id)
        {
            return db.MedicalOnly.Count(e => e.Id == id) > 0;
        }
    }
}