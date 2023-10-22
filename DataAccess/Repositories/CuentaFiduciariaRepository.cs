using Microsoft.EntityFrameworkCore;
using TrabajoFinalSofttek.DataAccess.Repositories.Interfaces;
using TrabajoFinalSofttek.Entities;

namespace TrabajoFinalSofttek.DataAccess.Repositories
{
    public class CuentaFiduciariaRepository : Repository<CuentaFiduciaria>, ICuentaFiduciariaRepository
    {
        public CuentaFiduciariaRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<CuentaFiduciaria> GetByCuil(long cuil)
        {
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Cuil == cuil);
            var cuentaFiduciaria = await _context.CuentasFiduciarias.SingleOrDefaultAsync(u => u.Id == usuario.CuentaFiduciariaId);
            return cuentaFiduciaria;
        }

        //public async Task<decimal> SaldoPesos(long cuil)
        //{
        //    var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Cuil == cuil);
        //    if (usuario == null) { return 0; }

        //    var cuentaFiduciaria = await _context.CuentasFiduciarias.FirstOrDefaultAsync(x => x.Id == usuario.CuentaFiduciariaId);
        //    decimal saldo = cuentaFiduciaria.SaldoPesos;

        //    return saldo;
        //}

    }
}
