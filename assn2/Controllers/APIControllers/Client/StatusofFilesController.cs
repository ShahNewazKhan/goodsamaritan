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
    public class StatusofFilesController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/StatusofFiles
        public IQueryable<StatusofFile> GetStatusOfFile()
        {
            return db.StatusOfFile;
        }

        // GET: api/StatusofFiles/5
        [ResponseType(typeof(StatusofFile))]
        public async Task<IHttpActionResult> GetStatusofFile(int id)
        {
            StatusofFile statusofFile = await db.StatusOfFile.FindAsync(id);
            if (statusofFile == null)
            {
                return NotFound();
            }

            return Ok(statusofFile);
        }

        // PUT: api/StatusofFiles/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStatusofFile(int id, StatusofFile statusofFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statusofFile.Id)
            {
                return BadRequest();
            }

            db.Entry(statusofFile).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusofFileExists(id))
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

        // POST: api/StatusofFiles
        [ResponseType(typeof(StatusofFile))]
        public async Task<IHttpActionResult> PostStatusofFile(StatusofFile statusofFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StatusOfFile.Add(statusofFile);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = statusofFile.Id }, statusofFile);
        }

        // DELETE: api/StatusofFiles/5
        [ResponseType(typeof(StatusofFile))]
        public async Task<IHttpActionResult> DeleteStatusofFile(int id)
        {
            StatusofFile statusofFile = await db.StatusOfFile.FindAsync(id);
            if (statusofFile == null)
            {
                return NotFound();
            }

            db.StatusOfFile.Remove(statusofFile);
            await db.SaveChangesAsync();

            return Ok(statusofFile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatusofFileExists(int id)
        {
            return db.StatusOfFile.Count(e => e.Id == id) > 0;
        }
    }
}