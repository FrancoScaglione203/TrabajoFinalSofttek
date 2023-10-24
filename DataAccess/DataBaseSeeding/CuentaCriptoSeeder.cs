using Microsoft.EntityFrameworkCore;
using TrabajoFinalSofttek.Entities;

namespace TrabajoFinalSofttek.DataAccess.DataBaseSeeding
{
    public class CuentaCriptoSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<CuentaCripto>().HasData(
            //    new CuentaCripto
            //    {
            //        Id = 1,
            //        UUID = 2222333,
            //        Saldo = 10,
            //        Activo = true
            //    });
        }
    }
}
