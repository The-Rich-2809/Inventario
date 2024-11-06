using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Inventario.Models
{
    public class Equipo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Tipo_Activo { get; set; } = string.Empty;
        public string Detalle { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string IMEI { get; set; } = string.Empty;
        public string No_Serie { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public double Costo {get; set;}
        public string Ubicacion_Actual { get; set; } = string.Empty;
        public int Id_Responsable {get; set;}
    }
}
