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
    public class ProgramsController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/Programs
        public IQueryable<Program> GetProgram()
        {
            return db.Program;
        }

        // GET: api/Programs/5
        [ResponseType(typeof(Program))]
        public async Task<IHttpActionResult> GetProgram(int id)
        {
            Program program = await db.Program.FindAsync(id);
            if (program == null)
            {
                return NotFound();
            }

            return Ok(program);
        }

        // PUT: api/Programs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProgram(int id, Program program)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != program.Id)
            {
                return BadRequest();
            }

            db.Entry(program).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramExists(id))
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

        // POST: api/Programs
        [ResponseType(typeof(Program))]
        public async Task<IHttpActionResult> PostProgram(Program program)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Program.Add(program);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = program.Id }, program);
        }

        // DELETE: api/Programs/5
        [ResponseType(typeof(Program))]
        public async Task<IHttpActionResult> DeleteProgram(int id)
        {
            Program program = await db.Program.FindAsync(id);
            if (program == null)
            {
                return NotFound();
            }

            db.Program.Remove(program);
            await db.SaveChangesAsync();

            return Ok(program);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProgramExists(int id)
        {
            return db.Program.Count(e => e.Id == id) > 0;
        }
    }
}