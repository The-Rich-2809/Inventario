using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Inventario.Models
{
    public class Imagenes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Id_Equipo { get; set; }
        public string Ruta {  get; set; }
    }
}
