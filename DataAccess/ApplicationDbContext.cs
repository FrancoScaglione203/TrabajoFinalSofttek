using Microsoft.EntityFrameworkCore;
using System.Data;
using TrabajoFinalSofttek.DataAccess.DataBaseSeeding;
using TrabajoFinalSofttek.Entities;

namespace TrabajoFinalSofttek.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoMovimiento> TipoMovimientos { get; set; }
        public DbSet<Moneda> Monedas { get; set; }
        public DbSet<Historial> Historiales { get; set; }
        public DbSet<CuentaFiduciaria> CuentasFiduciarias { get; set; }
        public DbSet<CuentaCripto> CuentasCriptos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var seeders = new List<IEntitySeeder>
            {
                new UsuarioSeeder(),
                new TipoMovimientoSeeder(),
                new MonedaSeeder(),
                new HistorialSeeder(),
                new CuentaFiduciariaSeeder(),
                new CuentaCriptoSeeder(),
            };

            foreach (var seeder in seeders)
            {

                seeder.SeedDataBase(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
