using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Prueba2.Models;

namespace Prueba2.Controllers
{
    public class MenuItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MenuItems
        public async Task<ActionResult> Index(string search)
        {
            var menuItems = from item in db.ÍtemsDeMenú
                            .Include(i => i.Categoría)
                            .Include(i => i.Negocio)
                            select item;

            if (!string.IsNullOrEmpty(search))
            {
                menuItems = menuItems.Where(i => i.NombreItem.Contains(search)
                                         || i.Categoría.NombreCategoría.Contains(search));
            }

            return View(await menuItems.ToListAsync());
        }

        // GET: MenuItems/Create
        public ActionResult Create()
        {
            ViewBag.CategoríaId = new SelectList(db.Categorías, "IdCategoría", "NombreCategoría");
            ViewBag.NegocioId = new SelectList(db.Negocios, "IdNegocio", "NombreNegocio");
            return View();
        }

        // POST: MenuItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NombreItem,DescripciónItem,CategoríaId,NegocioId,Precio")] ÍtemDeMenú ítemDeMenú)
        {
            if (ModelState.IsValid)
            {
                db.ÍtemsDeMenú.Add(ítemDeMenú);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoríaId = new SelectList(db.Categorías, "IdCategoría", "NombreCategoría", ítemDeMenú.CategoríaId);
            ViewBag.NegocioId = new SelectList(db.Negocios, "IdNegocio", "NombreNegocio", ítemDeMenú.NegocioId);
            return View(ítemDeMenú);
        }

        // GET: MenuItems/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ÍtemDeMenú ítemDeMenú = await db.ÍtemsDeMenú.FindAsync(id);
            if (ítemDeMenú == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoríaId = new SelectList(db.Categorías, "IdCategoría", "NombreCategoría", ítemDeMenú.CategoríaId);
            ViewBag.NegocioId = new SelectList(db.Negocios, "IdNegocio", "NombreNegocio", ítemDeMenú.NegocioId);
            return View(ítemDeMenú);
        }

        // POST: MenuItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdItem,NombreItem,DescripciónItem,CategoríaId,NegocioId,Precio")] ÍtemDeMenú ítemDeMenú)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ítemDeMenú).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoríaId = new SelectList(db.Categorías, "IdCategoría", "NombreCategoría", ítemDeMenú.CategoríaId);
            ViewBag.NegocioId = new SelectList(db.Negocios, "IdNegocio", "NombreNegocio", ítemDeMenú.NegocioId);
            return View(ítemDeMenú);
        }

        // GET: MenuItems/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ÍtemDeMenú ítemDeMenú = await db.ÍtemsDeMenú.FindAsync(id);
            if (ítemDeMenú == null)
            {
                return HttpNotFound();
            }
            return View(ítemDeMenú);
        }

        // POST: MenuItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ÍtemDeMenú ítemDeMenú = await db.ÍtemsDeMenú.FindAsync(id);
            db.ÍtemsDeMenú.Remove(ítemDeMenú);
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
