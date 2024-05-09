using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba2.Models
{
    [Table("ÍtemsDeMenú")]
    public class ÍtemDeMenú
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdItem { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreItem { get; set; }

        [StringLength(255)]
        public string DescripciónItem { get; set; }

        [ForeignKey("Categoría")]
        public int CategoríaId { get; set; }
        public virtual Categoría Categoría { get; set; }

        [ForeignKey("Negocio")]
        public int NegocioId { get; set; }
        public virtual Negocio Negocio { get; set; }

        // Cambia el tipo de columna a "decimal" con precisión y escala especificadas en el contexto mediante Fluent API.
        public decimal Precio { get; set; }
    }
}
