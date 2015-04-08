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
    public class RiskStatusesController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/RiskStatuses
        public IQueryable<RiskStatus> GetRiskStatus()
        {
            return db.RiskStatus;
        }

        // GET: api/RiskStatuses/5
        [ResponseType(typeof(RiskStatus))]
        public async Task<IHttpActionResult> GetRiskStatus(int id)
        {
            RiskStatus riskStatus = await db.RiskStatus.FindAsync(id);
            if (riskStatus == null)
            {
                return NotFound();
            }

            return Ok(riskStatus);
        }

        // PUT: api/RiskStatuses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRiskStatus(int id, RiskStatus riskStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != riskStatus.Id)
            {
                return BadRequest();
            }

            db.Entry(riskStatus).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RiskStatusExists(id))
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

        // POST: api/RiskStatuses
        [ResponseType(typeof(RiskStatus))]
        public async Task<IHttpActionResult> PostRiskStatus(RiskStatus riskStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RiskStatus.Add(riskStatus);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = riskStatus.Id }, riskStatus);
        }

        // DELETE: api/RiskStatuses/5
        [ResponseType(typeof(RiskStatus))]
        public async Task<IHttpActionResult> DeleteRiskStatus(int id)
        {
            RiskStatus riskStatus = await db.RiskStatus.FindAsync(id);
            if (riskStatus == null)
            {
                return NotFound();
            }

            db.RiskStatus.Remove(riskStatus);
            await db.SaveChangesAsync();

            return Ok(riskStatus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RiskStatusExists(int id)
        {
            return db.RiskStatus.Count(e => e.Id == id) > 0;
        }
    }
}