using Microsoft.EntityFrameworkCore;

namespace Inventario.Models
{
    public class Inventario_DB : DbContext
    {
        public Inventario_DB(DbContextOptions<Inventario_DB> options) : base(options)
        {

        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Equipo> Equipo { get; set; }
        public DbSet<Imagenes> Imagenes { get; set; }
    }
}
