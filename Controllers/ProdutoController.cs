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
using CrudAngularApi.Models;
using System.Web.Http.Cors;

namespace CrudAngularApi.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ProdutoController : ApiController
    {
        private SQL_AzureEntities db = new SQL_AzureEntities();

        // GET: api/Produto
        public IQueryable<COR_Produto> GetCOR_Produto()
        {
            return db.COR_Produto;
        }

        // GET: api/Produto/5
        [ResponseType(typeof(COR_Produto))]
        public IHttpActionResult GetCOR_Produto(int id)
        {
            COR_Produto cOR_Produto = db.COR_Produto.Find(id);
            if (cOR_Produto == null)
            {
                return NotFound();
            }

            return Ok(cOR_Produto);
        }

        // PUT: api/Produto/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCOR_Produto(int id, COR_Produto cOR_Produto)
        {
            if (id != cOR_Produto.cod_Produto)
            {
                return BadRequest();
            }

            db.Entry(cOR_Produto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!COR_ProdutoExists(id))
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

        // POST: api/Produto
        [ResponseType(typeof(COR_Produto))]
        public IHttpActionResult PostCOR_Produto(COR_Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.COR_Produto.Add(produto);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = produto.cod_Produto }, produto);
        }

        // DELETE: api/Produto/5
        [ResponseType(typeof(COR_Produto))]
        public IHttpActionResult DeleteCOR_Produto(int id)
        {
            COR_Produto cOR_Produto = db.COR_Produto.Find(id);
            if (cOR_Produto == null)
            {
                return NotFound();
            }

            db.COR_Produto.Remove(cOR_Produto);
            db.SaveChanges();

            return Ok(cOR_Produto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool COR_ProdutoExists(int id)
        {
            return db.COR_Produto.Count(e => e.cod_Produto == id) > 0;
        }
    }
}