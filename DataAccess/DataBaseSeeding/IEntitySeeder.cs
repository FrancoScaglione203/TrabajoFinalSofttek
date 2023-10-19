using Microsoft.EntityFrameworkCore;

namespace TrabajoFinalSofttek.DataAccess.DataBaseSeeding
{
    public interface IEntitySeeder
    {
        void SeedDataBase(ModelBuilder modelBuilder);
    }
}
