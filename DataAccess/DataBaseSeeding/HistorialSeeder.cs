using Microsoft.EntityFrameworkCore;
using TrabajoFinalSofttek.Entities;

namespace TrabajoFinalSofttek.DataAccess.DataBaseSeeding
{
    public class HistorialSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Historial>().HasData(
                new Historial
                {
                    Id = 1,
                    UsuarioId = 1,
                    TipoMovimientoId = 1,
                    MonedaId = 1,
                    Monto = 10000,
                });
        }
    }
}
