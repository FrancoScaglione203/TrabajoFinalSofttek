using Microsoft.EntityFrameworkCore;
using TrabajoFinalSofttek.Entities;

namespace TrabajoFinalSofttek.DataAccess.DataBaseSeeding
{
    public class MonedaSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Moneda>().HasData(
                new Moneda
                {
                    Id = 1,
                    Descripcion = "Peso"
                },
                new Moneda
                {
                    Id = 2,
                    Descripcion = "Dolar"
                },
                new Moneda
                {
                    Id = 3,
                    Descripcion = "BTC"
                });
        }
    }
}
