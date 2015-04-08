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
    public class AssignedWorkersController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/AssignedWorkers
        public IQueryable<AssignedWorker> GetAssignedWorker()
        {
            return db.AssignedWorker;
        }

        // GET: api/AssignedWorkers/5
        [ResponseType(typeof(AssignedWorker))]
        public async Task<IHttpActionResult> GetAssignedWorker(int id)
        {
            AssignedWorker assignedWorker = await db.AssignedWorker.FindAsync(id);
            if (assignedWorker == null)
            {
                return NotFound();
            }

            return Ok(assignedWorker);
        }

        // PUT: api/AssignedWorkers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAssignedWorker(int id, AssignedWorker assignedWorker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assignedWorker.Id)
            {
                return BadRequest();
            }

            db.Entry(assignedWorker).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignedWorkerExists(id))
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

        // POST: api/AssignedWorkers
        [ResponseType(typeof(AssignedWorker))]
        public async Task<IHttpActionResult> PostAssignedWorker(AssignedWorker assignedWorker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AssignedWorker.Add(assignedWorker);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = assignedWorker.Id }, assignedWorker);
        }

        // DELETE: api/AssignedWorkers/5
        [ResponseType(typeof(AssignedWorker))]
        public async Task<IHttpActionResult> DeleteAssignedWorker(int id)
        {
            AssignedWorker assignedWorker = await db.AssignedWorker.FindAsync(id);
            if (assignedWorker == null)
            {
                return NotFound();
            }

            db.AssignedWorker.Remove(assignedWorker);
            await db.SaveChangesAsync();

            return Ok(assignedWorker);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssignedWorkerExists(int id)
        {
            return db.AssignedWorker.Count(e => e.Id == id) > 0;
        }
    }
}