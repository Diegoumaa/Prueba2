using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba2.Models
{
    public class Negocio
    {
        [Key]
        public int IdNegocio { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreNegocio { get; set; }

        [StringLength(255)]
        public string Descripción { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaCreación { get; set; }
    }
}
