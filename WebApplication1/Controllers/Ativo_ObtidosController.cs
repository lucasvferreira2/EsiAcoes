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
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Ativo_ObtidosController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Ativo_Obtidos
        public IQueryable<Ativo_Obtidos> GetAtivo_Obtidos()
        {
            return db.Ativo_Obtidos;
        }

        // GET: api/Ativo_Obtidos/5
        [ResponseType(typeof(Ativo_Obtidos))]
        public IHttpActionResult GetAtivo_Obtidos(int id)
        {
            Ativo_Obtidos ativo_Obtidos = db.Ativo_Obtidos.Find(id);
            if (ativo_Obtidos == null)
            {
                return NotFound();
            }

            return Ok(ativo_Obtidos);
        }

        // PUT: api/Ativo_Obtidos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAtivo_Obtidos(int id, Ativo_Obtidos ativo_Obtidos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ativo_Obtidos.Usuario_ID)
            {
                return BadRequest();
            }

            db.Entry(ativo_Obtidos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Ativo_ObtidosExists(id))
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

        // POST: api/Ativo_Obtidos
        [ResponseType(typeof(Ativo_Obtidos))]
        public IHttpActionResult PostAtivo_Obtidos(Ativo_Obtidos ativo_Obtidos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ativo_Obtidos.Add(ativo_Obtidos);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Ativo_ObtidosExists(ativo_Obtidos.Usuario_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ativo_Obtidos.Usuario_ID }, ativo_Obtidos);
        }

        // DELETE: api/Ativo_Obtidos/5
        [ResponseType(typeof(Ativo_Obtidos))]
        public IHttpActionResult DeleteAtivo_Obtidos(int id)
        {
            Ativo_Obtidos ativo_Obtidos = db.Ativo_Obtidos.Find(id);
            if (ativo_Obtidos == null)
            {
                return NotFound();
            }

            db.Ativo_Obtidos.Remove(ativo_Obtidos);
            db.SaveChanges();

            return Ok(ativo_Obtidos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Ativo_ObtidosExists(int id)
        {
            return db.Ativo_Obtidos.Count(e => e.Usuario_ID == id) > 0;
        }
    }
}