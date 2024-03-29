﻿using System;
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
    public class EthnicitiesController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/Ethnicities
        public IQueryable<Ethnicity> GetEthnicity()
        {
            return db.Ethnicity;
        }

        // GET: api/Ethnicities/5
        [ResponseType(typeof(Ethnicity))]
        public async Task<IHttpActionResult> GetEthnicity(int id)
        {
            Ethnicity ethnicity = await db.Ethnicity.FindAsync(id);
            if (ethnicity == null)
            {
                return NotFound();
            }

            return Ok(ethnicity);
        }

        // PUT: api/Ethnicities/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEthnicity(int id, Ethnicity ethnicity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ethnicity.Id)
            {
                return BadRequest();
            }

            db.Entry(ethnicity).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EthnicityExists(id))
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

        // POST: api/Ethnicities
        [ResponseType(typeof(Ethnicity))]
        public async Task<IHttpActionResult> PostEthnicity(Ethnicity ethnicity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ethnicity.Add(ethnicity);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = ethnicity.Id }, ethnicity);
        }

        // DELETE: api/Ethnicities/5
        [ResponseType(typeof(Ethnicity))]
        public async Task<IHttpActionResult> DeleteEthnicity(int id)
        {
            Ethnicity ethnicity = await db.Ethnicity.FindAsync(id);
            if (ethnicity == null)
            {
                return NotFound();
            }

            db.Ethnicity.Remove(ethnicity);
            await db.SaveChangesAsync();

            return Ok(ethnicity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EthnicityExists(int id)
        {
            return db.Ethnicity.Count(e => e.Id == id) > 0;
        }
    }
}