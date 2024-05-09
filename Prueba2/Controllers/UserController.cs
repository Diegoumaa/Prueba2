using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web.Mvc;
using Prueba2.Models;
using Prueba2.Filters;

namespace Prueba2.Controllers
{
    [AuthorizeAdmin]
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public async Task<ActionResult> Index()
        {
            var usuarios = await db.Usuarios.Include("TipoDeUsuario").ToListAsync();
            return View(usuarios);
        }

        public ActionResult Create()
        {
            ViewBag.TipoUsuarioId = new SelectList(db.TiposDeUsuarios, "IdTipoUsuario", "NombreTipo");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Nombres,Apellidos,TipoUsuarioId,Correo,Contraseña")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TipoUsuarioId = new SelectList(db.TiposDeUsuarios, "IdTipoUsuario", "NombreTipo", usuario.TipoUsuarioId);
            return View(usuario);
        }

        public async Task<ActionResult> Edit(int id)
        {
            Usuario usuario = await db.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoUsuarioId = new SelectList(db.TiposDeUsuarios, "IdTipoUsuario", "NombreTipo", usuario.TipoUsuarioId);
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdUsuario,Nombres,Apellidos,TipoUsuarioId,Correo,Contraseña")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TipoUsuarioId = new SelectList(db.TiposDeUsuarios, "IdTipoUsuario", "NombreTipo", usuario.TipoUsuarioId);
            return View(usuario);
        }

        public async Task<ActionResult> Delete(int id)
        {
            Usuario usuario = await db.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                db.Usuarios.Remove(usuario);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
    }
}
