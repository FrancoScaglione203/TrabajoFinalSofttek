using TrabajoFinalSofttek.Entities;

namespace TrabajoFinalSofttek.DataAccess.Repositories.Interfaces
{
    public interface ICuentaCriptoRepository : IRepository<CuentaCripto>
    {
        public Task<CuentaCripto> GetByUUID(long UUID);
    }
}
