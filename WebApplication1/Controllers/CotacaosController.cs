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
    public class CotacaosController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Cotacaos
        public IQueryable<Cotacao> GetCotacao()
        {
            return db.Cotacao;
        }

        // GET: api/Cotacaos/5
        [ResponseType(typeof(Cotacao))]
        public IHttpActionResult GetCotacao(string id)
        {
            Cotacao cotacao = db.Cotacao.Find(id);
            if (cotacao == null)
            {
                return NotFound();
            }

            return Ok(cotacao);
        }

        // PUT: api/Cotacaos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCotacao(string id, Cotacao cotacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cotacao.SIGLA)
            {
                return BadRequest();
            }

            db.Entry(cotacao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CotacaoExists(id))
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

        // POST: api/Cotacaos
        [ResponseType(typeof(Cotacao))]
        public IHttpActionResult PostCotacao(Cotacao cotacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cotacao.Add(cotacao);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CotacaoExists(cotacao.SIGLA))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cotacao.SIGLA }, cotacao);
        }

        // DELETE: api/Cotacaos/5
        [ResponseType(typeof(Cotacao))]
        public IHttpActionResult DeleteCotacao(string id)
        {
            Cotacao cotacao = db.Cotacao.Find(id);
            if (cotacao == null)
            {
                return NotFound();
            }

            db.Cotacao.Remove(cotacao);
            db.SaveChanges();

            return Ok(cotacao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CotacaoExists(string id)
        {
            return db.Cotacao.Count(e => e.SIGLA == id) > 0;
        }
    }
}