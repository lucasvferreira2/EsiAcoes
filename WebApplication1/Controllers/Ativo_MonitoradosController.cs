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
    public class Ativo_MonitoradosController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Ativo_Monitorados
        public IQueryable<Ativo_Monitorados> GetAtivo_Monitorados()
        {
            return db.Ativo_Monitorados;
        }

        // GET: api/Ativo_Monitorados/5
        [ResponseType(typeof(Ativo_Monitorados))]
        public IHttpActionResult GetAtivo_Monitorados(int id)
        {
            Ativo_Monitorados ativo_Monitorados = db.Ativo_Monitorados.Find(id);
            if (ativo_Monitorados == null)
            {
                return NotFound();
            }

            return Ok(ativo_Monitorados);
        }

        // PUT: api/Ativo_Monitorados/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAtivo_Monitorados(int id, Ativo_Monitorados ativo_Monitorados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ativo_Monitorados.Usuario_ID)
            {
                return BadRequest();
            }

            db.Entry(ativo_Monitorados).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Ativo_MonitoradosExists(id))
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

        // POST: api/Ativo_Monitorados
        [ResponseType(typeof(Ativo_Monitorados))]
        public IHttpActionResult PostAtivo_Monitorados(Ativo_Monitorados ativo_Monitorados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ativo_Monitorados.Add(ativo_Monitorados);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Ativo_MonitoradosExists(ativo_Monitorados.Usuario_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ativo_Monitorados.Usuario_ID }, ativo_Monitorados);
        }

        // DELETE: api/Ativo_Monitorados/5
        [ResponseType(typeof(Ativo_Monitorados))]
        public IHttpActionResult DeleteAtivo_Monitorados(int id)
        {
            Ativo_Monitorados ativo_Monitorados = db.Ativo_Monitorados.Find(id);
            if (ativo_Monitorados == null)
            {
                return NotFound();
            }

            db.Ativo_Monitorados.Remove(ativo_Monitorados);
            db.SaveChanges();

            return Ok(ativo_Monitorados);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Ativo_MonitoradosExists(int id)
        {
            return db.Ativo_Monitorados.Count(e => e.Usuario_ID == id) > 0;
        }
    }
}