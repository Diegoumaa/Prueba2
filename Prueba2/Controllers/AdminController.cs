using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prueba2.Filters; // Asegúrate de importar el namespace correcto donde está tu filtro

namespace Prueba2.Controllers
{
    [AuthorizeAdmin]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManageBusinesses()
        {
            // Acción para manejar negocios
            return View();
        }

        public ActionResult ManageUsers()
        {
            // Acción para manejar usuarios
            return View();
        }
    }
}