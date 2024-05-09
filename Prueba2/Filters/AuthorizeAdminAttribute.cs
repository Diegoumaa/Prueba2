using System.Web;
using System.Web.Mvc;

namespace Prueba2.Filters
{
    public class AuthorizeAdminAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorized = base.AuthorizeCore(httpContext);
            if (!authorized)
            {
                return false;
            }

            // Comprobar si el usuario es administrador
            return httpContext.User.IsInRole("Administrador");
        }
    }
}
