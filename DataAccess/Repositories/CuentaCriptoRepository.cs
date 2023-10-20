using TrabajoFinalSofttek.DataAccess.Repositories.Interfaces;
using TrabajoFinalSofttek.Entities;

namespace TrabajoFinalSofttek.DataAccess.Repositories
{
    public class CuentaCriptoRepository : Repository<CuentaCripto>, ICuentaCriptoRepository
    {
        public CuentaCriptoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
