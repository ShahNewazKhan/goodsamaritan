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
    public class SocialWorkAttendancesController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/SocialWorkAttendances
        public IQueryable<SocialWorkAttendance> GetSocialWorkAttendance()
        {
            return db.SocialWorkAttendance;
        }

        // GET: api/SocialWorkAttendances/5
        [ResponseType(typeof(SocialWorkAttendance))]
        public async Task<IHttpActionResult> GetSocialWorkAttendance(int id)
        {
            SocialWorkAttendance socialWorkAttendance = await db.SocialWorkAttendance.FindAsync(id);
            if (socialWorkAttendance == null)
            {
                return NotFound();
            }

            return Ok(socialWorkAttendance);
        }

        // PUT: api/SocialWorkAttendances/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSocialWorkAttendance(int id, SocialWorkAttendance socialWorkAttendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != socialWorkAttendance.Id)
            {
                return BadRequest();
            }

            db.Entry(socialWorkAttendance).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SocialWorkAttendanceExists(id))
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

        // POST: api/SocialWorkAttendances
        [ResponseType(typeof(SocialWorkAttendance))]
        public async Task<IHttpActionResult> PostSocialWorkAttendance(SocialWorkAttendance socialWorkAttendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SocialWorkAttendance.Add(socialWorkAttendance);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = socialWorkAttendance.Id }, socialWorkAttendance);
        }

        // DELETE: api/SocialWorkAttendances/5
        [ResponseType(typeof(SocialWorkAttendance))]
        public async Task<IHttpActionResult> DeleteSocialWorkAttendance(int id)
        {
            SocialWorkAttendance socialWorkAttendance = await db.SocialWorkAttendance.FindAsync(id);
            if (socialWorkAttendance == null)
            {
                return NotFound();
            }

            db.SocialWorkAttendance.Remove(socialWorkAttendance);
            await db.SaveChangesAsync();

            return Ok(socialWorkAttendance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SocialWorkAttendanceExists(int id)
        {
            return db.SocialWorkAttendance.Count(e => e.Id == id) > 0;
        }
    }
}