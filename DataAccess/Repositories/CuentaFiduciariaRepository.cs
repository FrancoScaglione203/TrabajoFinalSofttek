using Microsoft.EntityFrameworkCore;
using System.Threading;
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


        public async Task<bool> DepositoByCuil(long cuil, decimal monto, int idMoneda)
        {
            var cuentaFiduciaria = await GetByCuil(cuil);
            if (cuentaFiduciaria == null || monto <= 0 || idMoneda < 1 || idMoneda > 2) { return false; }        

            if(idMoneda == 1)
            {
                cuentaFiduciaria.SaldoPesos += monto;
            }
            if (idMoneda == 2)
            {
                cuentaFiduciaria.SaldoDolares += monto;
            }

            _context.CuentasFiduciarias.Update(cuentaFiduciaria);
            return true;
        }

        public async Task<bool> ExtraccionByCuil(long cuil, decimal monto, int idMoneda)
        {
            var cuentaFiduciaria = await GetByCuil(cuil);
            if (cuentaFiduciaria == null || monto <= 0 || idMoneda < 1 || idMoneda > 2) { return false; }

            if (idMoneda == 1 && monto <= cuentaFiduciaria.SaldoPesos)
            {
                cuentaFiduciaria.SaldoPesos -= monto;
                _context.CuentasFiduciarias.Update(cuentaFiduciaria);
                return true;
            }
            else { return false; }
            if (idMoneda == 2 && monto <= cuentaFiduciaria.SaldoDolares)
            {
                cuentaFiduciaria.SaldoDolares -= monto;
                _context.CuentasFiduciarias.Update(cuentaFiduciaria);
                return true;
            }
            else { return false; }
        }

        //public async Task<bool> TransferenciaByCuil(long cuil, decimal monto, int tipoTransfer)
        //{
        //    var cuentaFiduciaria = await GetByCuil(cuil);
        //    if (cuentaFiduciaria == null) { return false; }
        //    //FALTAN VALIDACIONES DEL MONTO Y SALDO

        //    if (tipoTransfer == 1)  //Pesos a dolares
        //    {
        //        cuentaFiduciaria.SaldoPesos -= monto;
        //    }
        //    if (tipoTransfer == 2) //Pesos a BTC
        //    {
        //        cuentaFiduciaria.SaldoDolares -= monto;
        //    }
        //    if (tipoTransfer == 3) //Dolares a Pesos
        //    {
        //        cuentaFiduciaria.SaldoDolares -= monto;
        //    }
        //    if (tipoTransfer == 4) //Dolares a BTC
        //    {
        //        cuentaFiduciaria.SaldoDolares -= monto;
        //    }


        //    _context.CuentasFiduciarias.Update(cuentaFiduciaria);
        //    return true;
        //}
    }
}
