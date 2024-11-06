using System.ComponentModel.DataAnnotations;
using Inventario.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Models
{
    public class InventarioViewModel
    {
        public IEnumerable<Usuario> Usuarios { get; set; }
        public IEnumerable<Equipo> Equipos { get; set; }
        public IEnumerable<Imagenes> Imagenes { get; set; }

    }
}