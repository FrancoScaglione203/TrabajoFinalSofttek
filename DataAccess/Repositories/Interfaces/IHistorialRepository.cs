using TrabajoFinalSofttek.Entities;

namespace TrabajoFinalSofttek.DataAccess.Repositories.Interfaces
{
    public interface IHistorialRepository : IRepository<Historial>
    {
        public Task<List<Historial>> GetAllByCuil(long cuil);
    }
}
