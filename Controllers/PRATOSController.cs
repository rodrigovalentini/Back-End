using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClassesDAO;

namespace Back_End.Controllers
{
    public class PRATOSController : Controller
    {
        private DADOS_MODEL db = new DADOS_MODEL();

        // GET: PRATOS
        public async Task<ActionResult> Index()
        {
            var pRATOS = db.PRATOS.Include(p => p.RESTAURANTE);
            return View(await pRATOS.ToListAsync());
        }

        // GET: PRATOS/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRATO pRATO = await db.PRATOS.FindAsync(id);
            if (pRATO == null)
            {
                return HttpNotFound();
            }
            return View(pRATO);
        }

        // GET: PRATOS/Create
        public ActionResult Create()
        {
            ViewBag.CODIGO_RESTAURANTE = new SelectList(db.RESTAURANTES, "CODIGO", "NOME");
            return View();
        }

        // POST: PRATOS/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CODIGO,CODIGO_RESTAURANTE,DESCRICAO,VALOR,IMAGENS")] PRATO pRATO)
        {
            if (ModelState.IsValid)
            {
                db.PRATOS.Add(pRATO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CODIGO_RESTAURANTE = new SelectList(db.RESTAURANTES, "CODIGO", "NOME", pRATO.CODIGO_RESTAURANTE);
            return View(pRATO);
        }

        // GET: PRATOS/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRATO pRATO = await db.PRATOS.FindAsync(id);
            if (pRATO == null)
            {
                return HttpNotFound();
            }
            ViewBag.CODIGO_RESTAURANTE = new SelectList(db.RESTAURANTES, "CODIGO", "NOME", pRATO.CODIGO_RESTAURANTE);
            return View(pRATO);
        }

        // POST: PRATOS/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CODIGO,CODIGO_RESTAURANTE,DESCRICAO,VALOR,IMAGENS")] PRATO pRATO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRATO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CODIGO_RESTAURANTE = new SelectList(db.RESTAURANTES, "CODIGO", "NOME", pRATO.CODIGO_RESTAURANTE);
            return View(pRATO);
        }

        // GET: PRATOS/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRATO pRATO = await db.PRATOS.FindAsync(id);
            if (pRATO == null)
            {
                return HttpNotFound();
            }
            return View(pRATO);
        }

        // POST: PRATOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PRATO pRATO = await db.PRATOS.FindAsync(id);
            db.PRATOS.Remove(pRATO);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
