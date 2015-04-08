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
    public class FamilyViolenceFilesController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/FamilyViolenceFiles
        public IQueryable<FamilyViolenceFile> GetFamilyViolenceFile()
        {
            return db.FamilyViolenceFile;
        }

        // GET: api/FamilyViolenceFiles/5
        [ResponseType(typeof(FamilyViolenceFile))]
        public async Task<IHttpActionResult> GetFamilyViolenceFile(int id)
        {
            FamilyViolenceFile familyViolenceFile = await db.FamilyViolenceFile.FindAsync(id);
            if (familyViolenceFile == null)
            {
                return NotFound();
            }

            return Ok(familyViolenceFile);
        }

        // PUT: api/FamilyViolenceFiles/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFamilyViolenceFile(int id, FamilyViolenceFile familyViolenceFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != familyViolenceFile.Id)
            {
                return BadRequest();
            }

            db.Entry(familyViolenceFile).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FamilyViolenceFileExists(id))
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

        // POST: api/FamilyViolenceFiles
        [ResponseType(typeof(FamilyViolenceFile))]
        public async Task<IHttpActionResult> PostFamilyViolenceFile(FamilyViolenceFile familyViolenceFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FamilyViolenceFile.Add(familyViolenceFile);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = familyViolenceFile.Id }, familyViolenceFile);
        }

        // DELETE: api/FamilyViolenceFiles/5
        [ResponseType(typeof(FamilyViolenceFile))]
        public async Task<IHttpActionResult> DeleteFamilyViolenceFile(int id)
        {
            FamilyViolenceFile familyViolenceFile = await db.FamilyViolenceFile.FindAsync(id);
            if (familyViolenceFile == null)
            {
                return NotFound();
            }

            db.FamilyViolenceFile.Remove(familyViolenceFile);
            await db.SaveChangesAsync();

            return Ok(familyViolenceFile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FamilyViolenceFileExists(int id)
        {
            return db.FamilyViolenceFile.Count(e => e.Id == id) > 0;
        }
    }
}