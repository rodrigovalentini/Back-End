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
using System.Web.Http.OData;
using ClassesDAO;

namespace Back_End.Controllers
{
    public class RESTAURANTEController : ApiController
    {
        private DADOS_MODEL db = new DADOS_MODEL();

        // GET: api/RESTAURANTE
        [EnableQuery]
        public IQueryable<RESTAURANTE> GetRESTAURANTES()
        {
            return db.RESTAURANTES;
        }

        // GET: api/RESTAURANTE/5
        [ResponseType(typeof(RESTAURANTE))]
        public async Task<IHttpActionResult> GetRESTAURANTE(int id)
        {
            RESTAURANTE rESTAURANTE = await db.RESTAURANTES.FindAsync(id);
            if (rESTAURANTE == null)
            {
                return NotFound();
            }

            return Ok(rESTAURANTE);
        }

        // PUT: api/RESTAURANTE/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRESTAURANTE(int id, RESTAURANTE rESTAURANTE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rESTAURANTE.CODIGO)
            {
                return BadRequest();
            }

            db.Entry(rESTAURANTE).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RESTAURANTEExists(id))
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

        // POST: api/RESTAURANTE
        [ResponseType(typeof(RESTAURANTE))]
        public async Task<IHttpActionResult> PostRESTAURANTE(RESTAURANTE rESTAURANTE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RESTAURANTES.Add(rESTAURANTE);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = rESTAURANTE.CODIGO }, rESTAURANTE);
        }

        // DELETE: api/RESTAURANTE/5
        [ResponseType(typeof(RESTAURANTE))]
        public async Task<IHttpActionResult> DeleteRESTAURANTE(int id)
        {
            RESTAURANTE rESTAURANTE = await db.RESTAURANTES.FindAsync(id);
            if (rESTAURANTE == null)
            {
                return NotFound();
            }

            db.RESTAURANTES.Remove(rESTAURANTE);
            await db.SaveChangesAsync();

            return Ok(rESTAURANTE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RESTAURANTEExists(int id)
        {
            return db.RESTAURANTES.Count(e => e.CODIGO == id) > 0;
        }
    }
}