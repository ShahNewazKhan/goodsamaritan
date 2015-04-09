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
    public class CityofResidencesController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/CityofResidences
        public IQueryable<CityofResidence> GetCityOfResidence()
        {
            return db.CityOfResidence;
        }

        // GET: api/CityofResidences/5
        [ResponseType(typeof(CityofResidence))]
        public async Task<IHttpActionResult> GetCityofResidence(int id)
        {
            CityofResidence cityofResidence = await db.CityOfResidence.FindAsync(id);
            if (cityofResidence == null)
            {
                return NotFound();
            }

            return Ok(cityofResidence);
        }

        // PUT: api/CityofResidences/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCityofResidence(int id, CityofResidence cityofResidence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cityofResidence.Id)
            {
                return BadRequest();
            }

            db.Entry(cityofResidence).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityofResidenceExists(id))
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

        // POST: api/CityofResidences
        [ResponseType(typeof(CityofResidence))]
        public async Task<IHttpActionResult> PostCityofResidence(CityofResidence cityofResidence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CityOfResidence.Add(cityofResidence);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cityofResidence.Id }, cityofResidence);
        }

        // DELETE: api/CityofResidences/5
        [ResponseType(typeof(CityofResidence))]
        public async Task<IHttpActionResult> DeleteCityofResidence(int id)
        {
            CityofResidence cityofResidence = await db.CityOfResidence.FindAsync(id);
            if (cityofResidence == null)
            {
                return NotFound();
            }

            db.CityOfResidence.Remove(cityofResidence);
            await db.SaveChangesAsync();

            return Ok(cityofResidence);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CityofResidenceExists(int id)
        {
            return db.CityOfResidence.Count(e => e.Id == id) > 0;
        }
    }
}