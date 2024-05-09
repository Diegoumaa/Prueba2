using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Prueba2.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection") { }

        public DbSet<Negocio> Negocios { get; set; }
        public DbSet<TipoDeUsuario> TiposDeUsuarios { get; set; }
        public DbSet<Categoría> Categorías { get; set; }
        public DbSet<ÍtemDeMenú> ÍtemsDeMenú { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
