using Microsoft.EntityFrameworkCore;
using TrabajoFinalSofttek.Entities;

namespace TrabajoFinalSofttek.DataAccess.DataBaseSeeding
{
    public class UsuarioSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Cuil = 20424465306,
                    Clave = "1234", //DESPUES ENCRIPTARLA
                    CuentaFiduciariaId = 1,
                    CuentaCriptoId = 1,
                    Activo = true
                });
        }
    }
}
