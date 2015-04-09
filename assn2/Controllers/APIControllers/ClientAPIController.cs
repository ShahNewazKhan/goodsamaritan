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
    public class ClientAPIController : ApiController
    {
        private GSContext db = new GSContext();

        // GET: api/ClientAPI
        public List<Client> GetClients()
        {
            return db.Clients.ToList();
        }

        // GET: api/ClientAPI/5
        [ResponseType(typeof(Client))]
        public async Task<IHttpActionResult> GetClient(int id)
        {
            Client client = await db.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // PUT: api/ClientAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClient(int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.Id)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/ClientAPI
        [ResponseType(typeof(Client))]
        public async Task<IHttpActionResult> PostClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clients.Add(client);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = client.Id }, client);
        }

        // DELETE: api/ClientAPI/5
        [ResponseType(typeof(Client))]
        public async Task<IHttpActionResult> DeleteClient(int id)
        {
            Client client = await db.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            db.Clients.Remove(client);
            await db.SaveChangesAsync();

            return Ok(client);
        }
        
        // GET:
        [HttpGet]
        [Route("ClientAPI/getClients/{year}/{month}")]
        public List<Client> getClientsForReport( string year, int month )
        {
            List<Client> clients = new List<Client>();
            
            // Initial DB query to get all clients for given year / month
            var qry = from c in db.Clients
                      where c.fisYear.Value == year
                      where c.month == month
                      select c;

            foreach( Client c in qry )
            {
                clients.Add(c);
            }

            // Get counts for open / closed / reopened files
            var open = (from o in clients
                        where o.StatusofFile.Value == "Open"
                        select o).Count();

            var closed = (from o in clients
                          where o.StatusofFile.Value == "Closed"
                          select o).Count();

            var reopened = (from o in clients
                            where o.StatusofFile.Value == "Reopened"
                            select o).Count();

            // Get count of program type for report.
            var crisis = (from o in clients
                          where o.Program.Value == "Crisis"
                          select o).Count();

            var court = (from o in clients
                         where o.Program.Value == "Court"
                         select o).Count();

            var smart = (from o in clients
                         where o.Program.Value == "SMART"
                         select o).Count();

            var DVU = (from o in clients
                         where o.Program.Value == "DVU"
                         select o).Count();

            var MCFD = (from o in clients
                       where o.Program.Value == "MCFD"
                       select o).Count();

            // Get count of gender statistics for report.
            var female = (from o in clients
                          where o.gender == 'f'
                          select o).Count();

            var male = (from o in clients
                          where o.gender == 'm'
                          select o).Count();

            var trans = (from o in clients
                          where o.gender == 't'
                          select o).Count();

            // Get age range statistics for report.
            var adult = (from o in clients
                         where o.Age.Value == "Adult>24<65"
                         select o).Count();

            var youthA = (from o in clients
                         where o.Age.Value == "Youth>12<19"
                         select o).Count();

            var youthB = (from o in clients
                         where o.Age.Value == "Youth>18<25"
                         select o).Count();

            var child = (from o in clients
                         where o.Age.Value == "Child<13"
                         select o).Count();

            var senior = (from o in clients
                          where o.Age.Value == "Senior>64"
                          select o).Count();

            return clients;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(int id)
        {
            return db.Clients.Count(e => e.Id == id) > 0;
        }
    }
}