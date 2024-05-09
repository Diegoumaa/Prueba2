using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prueba2.Models;

namespace Prueba2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
            {
                var usuarios = db.Usuarios.ToList();
                if (!usuarios.Any())
                {
                    System.Diagnostics.Debug.WriteLine("No se encontraron usuarios.");
                }
                else
                {
                    foreach (var usuario in usuarios)
                    {
                        System.Diagnostics.Debug.WriteLine("Usuario: " + usuario.Nombres + " - " + usuario.Correo);
                    }
                }
                return View(usuarios); // Asegúrate de que la vista está configurada para mostrar los datos
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
