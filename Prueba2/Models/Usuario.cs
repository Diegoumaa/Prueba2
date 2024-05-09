using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba2.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        [ForeignKey("TipoDeUsuario")]
        public int TipoUsuarioId { get; set; }
        public TipoDeUsuario TipoDeUsuario { get; set; }  // Agregar esta línea

        public string Correo { get; set; }
        public string Contraseña { get; set; }
    }


}