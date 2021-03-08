using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Ident2.Models;

namespace Ident2.Controllers
{
    public class Persona2Controller : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Persona2
        public IQueryable<Persona2> GetPersona2()
        {
            return db.Persona2;
        }

        // GET: api/Persona2/5
        [ResponseType(typeof(Persona2))]
        public IHttpActionResult GetPersona2(int id)
        {
            Persona2 persona2 = db.Persona2.Find(id);
            if (persona2 == null)
            {
                return NotFound();
            }

            return Ok(persona2);
        }

        // PUT: api/Persona2/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersona2(int id, Persona2 persona2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != persona2.Persona2Id)
            {
                return BadRequest();
            }

            db.Entry(persona2).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Persona2Exists(id))
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

        // POST: api/Persona2
        [ResponseType(typeof(Persona2))]
        public IHttpActionResult PostPersona2(Persona2 persona2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Persona2.Add(persona2);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = persona2.Persona2Id }, persona2);
        }

        // DELETE: api/Persona2/5
        [ResponseType(typeof(Persona2))]
        public IHttpActionResult DeletePersona2(int id)
        {
            Persona2 persona2 = db.Persona2.Find(id);
            if (persona2 == null)
            {
                return NotFound();
            }

            db.Persona2.Remove(persona2);
            db.SaveChanges();

            return Ok(persona2);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Persona2Exists(int id)
        {
            return db.Persona2.Count(e => e.Persona2Id == id) > 0;
        }
    }
}