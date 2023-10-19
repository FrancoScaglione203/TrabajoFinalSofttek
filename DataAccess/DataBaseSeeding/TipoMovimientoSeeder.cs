using Microsoft.EntityFrameworkCore;
using TrabajoFinalSofttek.Entities;

namespace TrabajoFinalSofttek.DataAccess.DataBaseSeeding
{
    public class TipoMovimientoSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoMovimiento>().HasData(
                new TipoMovimiento
                {
                    Id = 1,
                    Descripcion = "Consulta"
                },
                new TipoMovimiento
                {
                    Id = 2,
                    Descripcion = "Deposito"
                },
                new TipoMovimiento
                {
                    Id = 3,
                    Descripcion = "Extraccion"
                },
                new TipoMovimiento
                {
                    Id = 4,
                    Descripcion = "Transferencia"
                });
        }
    }
}
