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
    public class ServicesController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/Services
        public IQueryable<Service> GetService()
        {
            return db.Service;
        }

        // GET: api/Services/5
        [ResponseType(typeof(Service))]
        public async Task<IHttpActionResult> GetService(int id)
        {
            Service service = await db.Service.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            return Ok(service);
        }

        // PUT: api/Services/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutService(int id, Service service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != service.Id)
            {
                return BadRequest();
            }

            db.Entry(service).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(id))
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

        // POST: api/Services
        [ResponseType(typeof(Service))]
        public async Task<IHttpActionResult> PostService(Service service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Service.Add(service);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = service.Id }, service);
        }

        // DELETE: api/Services/5
        [ResponseType(typeof(Service))]
        public async Task<IHttpActionResult> DeleteService(int id)
        {
            Service service = await db.Service.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            db.Service.Remove(service);
            await db.SaveChangesAsync();

            return Ok(service);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceExists(int id)
        {
            return db.Service.Count(e => e.Id == id) > 0;
        }
    }
}