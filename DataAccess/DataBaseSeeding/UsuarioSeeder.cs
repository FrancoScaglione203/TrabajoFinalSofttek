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
                    Cuil = 11111111,
                    Nombre = "Franco",
                    Apellido = "Scaglione",
                    Clave = "1234", //DESPUES ENCRIPTARLA
                    Activo = true
                });
        }
    }
}
