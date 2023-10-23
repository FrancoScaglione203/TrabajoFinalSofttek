using Microsoft.EntityFrameworkCore;
using TrabajoFinalSofttek.DataAccess.Repositories.Interfaces;
using TrabajoFinalSofttek.Entities;

namespace TrabajoFinalSofttek.DataAccess.Repositories
{
    public class CuentaCriptoRepository : Repository<CuentaCripto>, ICuentaCriptoRepository
    {
        public CuentaCriptoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<CuentaCripto> GetByCuil(long cuil)
        {
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Cuil == cuil);
            var cuentaCripto = await _context.CuentasCriptos.SingleOrDefaultAsync(u => u.Id == usuario.CuentaCriptoId);
            return cuentaCripto;
        }


        public async Task<bool> DepositoByCuil(long cuil, decimal monto)
        {
            var cuentaCripto = await GetByCuil(cuil);
            if (cuentaCripto == null || monto <= 0) { return false; }

                cuentaCripto.Saldo += monto;
            
            _context.CuentasCriptos.Update(cuentaCripto);
            return true;
        }


        public async Task<bool> ExtraccionByCuil(long cuil, decimal monto)
        {
            var cuentaCripto = await GetByCuil(cuil);
            if (cuentaCripto == null || monto <= 0) { return false; }

            if (monto <= cuentaCripto.Saldo)
            {
                cuentaCripto.Saldo -= monto;
                _context.CuentasCriptos.Update(cuentaCripto);
                return true;
            }
            else { return false; }
        }
    }
}
