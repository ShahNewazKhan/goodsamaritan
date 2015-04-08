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
    public class FiscalYearsController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/FiscalYears
        public IQueryable<FiscalYear> GetFiscalYear()
        {
            return db.FiscalYear;
        }

        // GET: api/FiscalYears/5
        [ResponseType(typeof(FiscalYear))]
        public async Task<IHttpActionResult> GetFiscalYear(int id)
        {
            FiscalYear fiscalYear = await db.FiscalYear.FindAsync(id);
            if (fiscalYear == null)
            {
                return NotFound();
            }

            return Ok(fiscalYear);
        }

        // PUT: api/FiscalYears/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFiscalYear(int id, FiscalYear fiscalYear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fiscalYear.Id)
            {
                return BadRequest();
            }

            db.Entry(fiscalYear).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FiscalYearExists(id))
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

        // POST: api/FiscalYears
        [ResponseType(typeof(FiscalYear))]
        public async Task<IHttpActionResult> PostFiscalYear(FiscalYear fiscalYear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FiscalYear.Add(fiscalYear);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = fiscalYear.Id }, fiscalYear);
        }

        // DELETE: api/FiscalYears/5
        [ResponseType(typeof(FiscalYear))]
        public async Task<IHttpActionResult> DeleteFiscalYear(int id)
        {
            FiscalYear fiscalYear = await db.FiscalYear.FindAsync(id);
            if (fiscalYear == null)
            {
                return NotFound();
            }

            db.FiscalYear.Remove(fiscalYear);
            await db.SaveChangesAsync();

            return Ok(fiscalYear);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FiscalYearExists(int id)
        {
            return db.FiscalYear.Count(e => e.Id == id) > 0;
        }
    }
}