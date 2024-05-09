using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web.Mvc;
using Prueba2.Models;
using Prueba2.Filters;

namespace Prueba2.Controllers
{
    [AuthorizeAdmin]
    public class BusinessController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public async Task<ActionResult> Index(string search)
        {
            var negocios = await db.Negocios
                                   .Where(n => string.IsNullOrEmpty(search) || n.NombreNegocio.Contains(search))
                                   .ToListAsync();
            return View(negocios);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Negocio negocio)
        {
            if (ModelState.IsValid)
            {
                db.Negocios.Add(negocio);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(negocio);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var negocio = await db.Negocios.FindAsync(id);
            if (negocio == null)
            {
                return HttpNotFound();
            }
            return View(negocio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Negocio negocio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(negocio).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(negocio);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var negocio = await db.Negocios.FindAsync(id);
            if (negocio != null)
            {
                db.Negocios.Remove(negocio);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
    }
}
