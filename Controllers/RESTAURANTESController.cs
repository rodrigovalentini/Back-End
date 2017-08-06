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
    public class RESTAURANTESController : Controller
    {
        private DADOS_MODEL db = new DADOS_MODEL();

        // GET: RESTAURANTES
        public async Task<ActionResult> Index()
        {
            return View(await db.RESTAURANTES.ToListAsync());
        }

        // GET: RESTAURANTES/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESTAURANTE rESTAURANTE = await db.RESTAURANTES.FindAsync(id);
            if (rESTAURANTE == null)
            {
                return HttpNotFound();
            }
            return View(rESTAURANTE);
        }

        // GET: RESTAURANTES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RESTAURANTES/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CODIGO,NOME")] RESTAURANTE rESTAURANTE)
        {
            if (ModelState.IsValid)
            {
                db.RESTAURANTES.Add(rESTAURANTE);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(rESTAURANTE);
        }

        // GET: RESTAURANTES/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESTAURANTE rESTAURANTE = await db.RESTAURANTES.FindAsync(id);
            if (rESTAURANTE == null)
            {
                return HttpNotFound();
            }
            return View(rESTAURANTE);
        }

        // POST: RESTAURANTES/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CODIGO,NOME")] RESTAURANTE rESTAURANTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rESTAURANTE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(rESTAURANTE);
        }

        // GET: RESTAURANTES/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESTAURANTE rESTAURANTE = await db.RESTAURANTES.FindAsync(id);
            if (rESTAURANTE == null)
            {
                return HttpNotFound();
            }
            return View(rESTAURANTE);
        }

        // POST: RESTAURANTES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RESTAURANTE rESTAURANTE = await db.RESTAURANTES.FindAsync(id);
            db.RESTAURANTES.Remove(rESTAURANTE);
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
