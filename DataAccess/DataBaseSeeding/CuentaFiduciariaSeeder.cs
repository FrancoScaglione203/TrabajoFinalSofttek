using Microsoft.EntityFrameworkCore;
using TrabajoFinalSofttek.Entities;

namespace TrabajoFinalSofttek.DataAccess.DataBaseSeeding
{
    public class CuentaFiduciariaSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<CuentaFiduciaria>().HasData(
            //    new CuentaFiduciaria
            //    {
            //        Id = 1,
            //        CBU = 111111111111111,
            //        Alias = "alias",
            //        NumeroCuenta = 1,
            //        SaldoPesos = 10000,
            //        SaldoDolares = 100,
            //        Activo = true
            //    });
        }
    }
}
