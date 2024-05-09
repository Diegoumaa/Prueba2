using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Prueba2.Models;

namespace Prueba2.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Usuario user, bool rememberMe = false)
        {
            using (var db = new ApplicationDbContext())
            {
                var usr = db.Usuarios.Include("TipoDeUsuario").FirstOrDefault(u => u.Correo == user.Correo && u.Contraseña == user.Contraseña);
                if (usr != null)
                {
                    string userData = usr.TipoDeUsuario.NombreTipo; // "Administrador" o "Cliente"

                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
       1, // Ticket version
       usr.Correo, // User identifier
       DateTime.Now, // Created
       DateTime.Now.AddMinutes(30), // Expires
       rememberMe, // Persistent?
       userData, // User data (the role in this case)
       FormsAuthentication.FormsCookiePath);

                    string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    Response.Cookies.Add(cookie);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "El nombre de usuario o la contraseña son incorrectos.");
                }
            }
            return View();
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}
