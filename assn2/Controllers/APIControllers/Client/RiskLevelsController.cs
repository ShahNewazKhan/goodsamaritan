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
    public class RiskLevelsController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/RiskLevels
        public IQueryable<RiskLevel> GetRiskLevel()
        {
            return db.RiskLevel;
        }

        // GET: api/RiskLevels/5
        [ResponseType(typeof(RiskLevel))]
        public async Task<IHttpActionResult> GetRiskLevel(int id)
        {
            RiskLevel riskLevel = await db.RiskLevel.FindAsync(id);
            if (riskLevel == null)
            {
                return NotFound();
            }

            return Ok(riskLevel);
        }

        // PUT: api/RiskLevels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRiskLevel(int id, RiskLevel riskLevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != riskLevel.Id)
            {
                return BadRequest();
            }

            db.Entry(riskLevel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RiskLevelExists(id))
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

        // POST: api/RiskLevels
        [ResponseType(typeof(RiskLevel))]
        public async Task<IHttpActionResult> PostRiskLevel(RiskLevel riskLevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RiskLevel.Add(riskLevel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = riskLevel.Id }, riskLevel);
        }

        // DELETE: api/RiskLevels/5
        [ResponseType(typeof(RiskLevel))]
        public async Task<IHttpActionResult> DeleteRiskLevel(int id)
        {
            RiskLevel riskLevel = await db.RiskLevel.FindAsync(id);
            if (riskLevel == null)
            {
                return NotFound();
            }

            db.RiskLevel.Remove(riskLevel);
            await db.SaveChangesAsync();

            return Ok(riskLevel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RiskLevelExists(int id)
        {
            return db.RiskLevel.Count(e => e.Id == id) > 0;
        }
    }
}