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
            var cuentaFiduciaria = await _context.CuentasFiduciarias.SingleOrDefaultAsync(u => u.UsuarioId == usuario.Id);
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

        public async Task<decimal> ConsultaCompraDolares(long cuil, decimal dolarCotiz)
        {

            var cuentaFiduciaria = await GetByCuil(cuil);

            decimal consulta = (cuentaFiduciaria.SaldoPesos / dolarCotiz);
            return consulta;
        }

        public async Task<bool> CompraDolares(long cuil, decimal dolarCotiz, decimal monto)
        {

            var cuentaFiduciaria = await GetByCuil(cuil);
            decimal maximo = await ConsultaCompraDolares(cuil, dolarCotiz);
            decimal pesos = monto * dolarCotiz;

            if (cuentaFiduciaria == null || monto <= 0 || monto > maximo) { return false; }
            
            cuentaFiduciaria.SaldoPesos -= pesos;
            cuentaFiduciaria.SaldoDolares += monto;
            _context.CuentasFiduciarias.Update(cuentaFiduciaria);
            return true;   
        }

        public async Task<decimal> ConsultaVentaDolares(long cuil, decimal dolarCotiz)
        {

            var cuentaFiduciaria = await GetByCuil(cuil);

            decimal consulta = (cuentaFiduciaria.SaldoDolares * dolarCotiz);
            return consulta;
        }

        public async Task<bool> VentaDolares(long cuil, decimal dolarCotiz, decimal monto)
        {
            var cuentaFiduciaria = await GetByCuil(cuil);
            decimal pesos = monto * dolarCotiz;

            if (cuentaFiduciaria == null || monto <= 0 || monto > cuentaFiduciaria.SaldoDolares) { return false; }

            cuentaFiduciaria.SaldoPesos += pesos;
            cuentaFiduciaria.SaldoDolares -= monto;
            _context.CuentasFiduciarias.Update(cuentaFiduciaria);
            return true;
        }

    }
}
