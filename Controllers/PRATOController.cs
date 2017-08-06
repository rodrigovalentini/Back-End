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
using System.Web.Http.OData;
using System.Web.Http.Description;
using ClassesDAO;

namespace Back_End.Controllers
{
    public class PRATOController : ApiController
    {
        private DADOS_MODEL db = new DADOS_MODEL();

        // GET: api/PRATO
        [EnableQuery]
        public IQueryable<PRATO> GetPRATOS()
        {
            return db.PRATOS;
        }

        // GET: api/PRATO/5
        [ResponseType(typeof(PRATO))]
        public async Task<IHttpActionResult> GetPRATO(int id)
        {
            PRATO pRATO = await db.PRATOS.FindAsync(id);
            if (pRATO == null)
            {
                return NotFound();
            }

            return Ok(pRATO);
        }

        // PUT: api/PRATO/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPRATO(int id, PRATO pRATO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pRATO.CODIGO)
            {
                return BadRequest();
            }

            db.Entry(pRATO).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PRATOExists(id))
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

        // POST: api/PRATO
        [ResponseType(typeof(PRATO))]
        public async Task<IHttpActionResult> PostPRATO(PRATO pRATO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PRATOS.Add(pRATO);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pRATO.CODIGO }, pRATO);
        }

        // DELETE: api/PRATO/5
        [ResponseType(typeof(PRATO))]
        public async Task<IHttpActionResult> DeletePRATO(int id)
        {
            PRATO pRATO = await db.PRATOS.FindAsync(id);
            if (pRATO == null)
            {
                return NotFound();
            }

            db.PRATOS.Remove(pRATO);
            await db.SaveChangesAsync();

            return Ok(pRATO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PRATOExists(int id)
        {
            return db.PRATOS.Count(e => e.CODIGO == id) > 0;
        }
    }
}