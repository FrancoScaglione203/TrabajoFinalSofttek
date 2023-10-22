using TrabajoFinalSofttek.Entities;

namespace TrabajoFinalSofttek.DataAccess.Repositories.Interfaces
{
    public interface ICuentaFiduciariaRepository : IRepository<CuentaFiduciaria>
    {
        public Task<CuentaFiduciaria> GetByCuil(long cuil);
    }
}
