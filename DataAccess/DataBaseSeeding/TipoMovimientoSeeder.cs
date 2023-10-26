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
                    Descripcion = "Deposito"
                },
                new TipoMovimiento
                {
                    Id = 2,
                    Descripcion = "Extraccion"
                },
                new TipoMovimiento
                {
                    Id = 3,
                    Descripcion = "Venta"
                },
                new TipoMovimiento
                {
                    Id = 4,
                    Descripcion = "Compra"
                },
                new TipoMovimiento
                {
                    Id = 5,
                    Descripcion = "Transferencia"
                },
                new TipoMovimiento
                {
                    Id = 6,
                    Descripcion = "Consulta"
                });
        }
    }
}
