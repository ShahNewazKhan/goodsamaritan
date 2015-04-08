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
    public class DuplicateFilesController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/DuplicateFiles
        public IQueryable<DuplicateFile> GetDuplicateFile()
        {
            return db.DuplicateFile;
        }

        // GET: api/DuplicateFiles/5
        [ResponseType(typeof(DuplicateFile))]
        public async Task<IHttpActionResult> GetDuplicateFile(int id)
        {
            DuplicateFile duplicateFile = await db.DuplicateFile.FindAsync(id);
            if (duplicateFile == null)
            {
                return NotFound();
            }

            return Ok(duplicateFile);
        }

        // PUT: api/DuplicateFiles/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDuplicateFile(int id, DuplicateFile duplicateFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != duplicateFile.Id)
            {
                return BadRequest();
            }

            db.Entry(duplicateFile).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DuplicateFileExists(id))
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

        // POST: api/DuplicateFiles
        [ResponseType(typeof(DuplicateFile))]
        public async Task<IHttpActionResult> PostDuplicateFile(DuplicateFile duplicateFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DuplicateFile.Add(duplicateFile);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = duplicateFile.Id }, duplicateFile);
        }

        // DELETE: api/DuplicateFiles/5
        [ResponseType(typeof(DuplicateFile))]
        public async Task<IHttpActionResult> DeleteDuplicateFile(int id)
        {
            DuplicateFile duplicateFile = await db.DuplicateFile.FindAsync(id);
            if (duplicateFile == null)
            {
                return NotFound();
            }

            db.DuplicateFile.Remove(duplicateFile);
            await db.SaveChangesAsync();

            return Ok(duplicateFile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DuplicateFileExists(int id)
        {
            return db.DuplicateFile.Count(e => e.Id == id) > 0;
        }
    }
}