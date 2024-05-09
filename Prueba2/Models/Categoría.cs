using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba2.Models
{
    [Table("Categorías")]
    public class Categoría
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCategoría { get; set; }
        public string NombreCategoría { get; set; }
    }

   
}
