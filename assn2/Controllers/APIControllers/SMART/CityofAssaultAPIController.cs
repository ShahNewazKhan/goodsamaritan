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

namespace assn2.Controllers
{
    public class CityofAssaultAPIController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/CityofAssaultAPI
        public IQueryable<CityofAssault> GetCityOfAssault()
        {
            return db.CityOfAssault;
        }

        // GET: api/CityofAssaultAPI/5
        [ResponseType(typeof(CityofAssault))]
        public async Task<IHttpActionResult> GetCityofAssault(int id)
        {
            CityofAssault cityofAssault = await db.CityOfAssault.FindAsync(id);
            if (cityofAssault == null)
            {
                return NotFound();
            }

            return Ok(cityofAssault);
        }

        // PUT: api/CityofAssaultAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCityofAssault(int id, CityofAssault cityofAssault)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cityofAssault.Id)
            {
                return BadRequest();
            }

            db.Entry(cityofAssault).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityofAssaultExists(id))
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

        // POST: api/CityofAssaultAPI
        [ResponseType(typeof(CityofAssault))]
        public async Task<IHttpActionResult> PostCityofAssault(CityofAssault cityofAssault)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CityOfAssault.Add(cityofAssault);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cityofAssault.Id }, cityofAssault);
        }

        // DELETE: api/CityofAssaultAPI/5
        [ResponseType(typeof(CityofAssault))]
        public async Task<IHttpActionResult> DeleteCityofAssault(int id)
        {
            CityofAssault cityofAssault = await db.CityOfAssault.FindAsync(id);
            if (cityofAssault == null)
            {
                return NotFound();
            }

            db.CityOfAssault.Remove(cityofAssault);
            await db.SaveChangesAsync();

            return Ok(cityofAssault);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CityofAssaultExists(int id)
        {
            return db.CityOfAssault.Count(e => e.Id == id) > 0;
        }
    }
}