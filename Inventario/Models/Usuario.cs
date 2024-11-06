using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Inventario.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Correo { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public string Telefono {get; set; } = string.Empty;
        public string DireccionImagen { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string TipoUsuario { get; set; } = string.Empty;
        public string Cargo {get; set;} = string.Empty;
        public string Ubicacion_Actual { get; set; } = string.Empty;
    }
}
