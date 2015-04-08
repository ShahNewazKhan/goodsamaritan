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
    public class DrugfacilitatedAssaultsController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/DrugfacilitatedAssaults
        public IQueryable<DrugfacilitatedAssault> GetDrugfacilitatedAssault()
        {
            return db.DrugfacilitatedAssault;
        }

        // GET: api/DrugfacilitatedAssaults/5
        [ResponseType(typeof(DrugfacilitatedAssault))]
        public async Task<IHttpActionResult> GetDrugfacilitatedAssault(int id)
        {
            DrugfacilitatedAssault drugfacilitatedAssault = await db.DrugfacilitatedAssault.FindAsync(id);
            if (drugfacilitatedAssault == null)
            {
                return NotFound();
            }

            return Ok(drugfacilitatedAssault);
        }

        // PUT: api/DrugfacilitatedAssaults/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDrugfacilitatedAssault(int id, DrugfacilitatedAssault drugfacilitatedAssault)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != drugfacilitatedAssault.Id)
            {
                return BadRequest();
            }

            db.Entry(drugfacilitatedAssault).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrugfacilitatedAssaultExists(id))
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

        // POST: api/DrugfacilitatedAssaults
        [ResponseType(typeof(DrugfacilitatedAssault))]
        public async Task<IHttpActionResult> PostDrugfacilitatedAssault(DrugfacilitatedAssault drugfacilitatedAssault)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DrugfacilitatedAssault.Add(drugfacilitatedAssault);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = drugfacilitatedAssault.Id }, drugfacilitatedAssault);
        }

        // DELETE: api/DrugfacilitatedAssaults/5
        [ResponseType(typeof(DrugfacilitatedAssault))]
        public async Task<IHttpActionResult> DeleteDrugfacilitatedAssault(int id)
        {
            DrugfacilitatedAssault drugfacilitatedAssault = await db.DrugfacilitatedAssault.FindAsync(id);
            if (drugfacilitatedAssault == null)
            {
                return NotFound();
            }

            db.DrugfacilitatedAssault.Remove(drugfacilitatedAssault);
            await db.SaveChangesAsync();

            return Ok(drugfacilitatedAssault);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DrugfacilitatedAssaultExists(int id)
        {
            return db.DrugfacilitatedAssault.Count(e => e.Id == id) > 0;
        }
    }
}