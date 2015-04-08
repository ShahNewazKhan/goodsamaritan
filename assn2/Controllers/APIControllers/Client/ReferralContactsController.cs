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
    public class ReferralContactsController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/ReferralContacts
        public IQueryable<ReferralContact> GetReferralContact()
        {
            return db.ReferralContact;
        }

        // GET: api/ReferralContacts/5
        [ResponseType(typeof(ReferralContact))]
        public async Task<IHttpActionResult> GetReferralContact(int id)
        {
            ReferralContact referralContact = await db.ReferralContact.FindAsync(id);
            if (referralContact == null)
            {
                return NotFound();
            }

            return Ok(referralContact);
        }

        // PUT: api/ReferralContacts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutReferralContact(int id, ReferralContact referralContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != referralContact.Id)
            {
                return BadRequest();
            }

            db.Entry(referralContact).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReferralContactExists(id))
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

        // POST: api/ReferralContacts
        [ResponseType(typeof(ReferralContact))]
        public async Task<IHttpActionResult> PostReferralContact(ReferralContact referralContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ReferralContact.Add(referralContact);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = referralContact.Id }, referralContact);
        }

        // DELETE: api/ReferralContacts/5
        [ResponseType(typeof(ReferralContact))]
        public async Task<IHttpActionResult> DeleteReferralContact(int id)
        {
            ReferralContact referralContact = await db.ReferralContact.FindAsync(id);
            if (referralContact == null)
            {
                return NotFound();
            }

            db.ReferralContact.Remove(referralContact);
            await db.SaveChangesAsync();

            return Ok(referralContact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReferralContactExists(int id)
        {
            return db.ReferralContact.Count(e => e.Id == id) > 0;
        }
    }
}