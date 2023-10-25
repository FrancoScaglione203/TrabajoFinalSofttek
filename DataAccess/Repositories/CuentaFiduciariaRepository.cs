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

        public async Task<CuentaFiduciaria> GetByNroCuenta(int NroCuenta)
        {
            var cuentaFiduciaria = await _context.CuentasFiduciarias.SingleOrDefaultAsync(u => u.NumeroCuenta == NroCuenta);
            return cuentaFiduciaria;
        }

        public async Task<decimal> GetSaldoPesosByNroCuenta(int NroCuenta)
        {
            var cuentaFiduciaria = await _context.CuentasFiduciarias.SingleOrDefaultAsync(u => u.NumeroCuenta == NroCuenta);
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Id == cuentaFiduciaria.UsuarioId);
            decimal saldo = cuentaFiduciaria.SaldoPesos;
            Historial historial = new Historial(cuentaFiduciaria.UsuarioId, usuario.Cuil, 6, 1, saldo);

            _context.Historiales.Add(historial);
            return saldo;
        }

        public async Task<decimal> GetSaldoDolaresByNroCuenta(int NroCuenta)
        {
            var cuentaFiduciaria = await _context.CuentasFiduciarias.SingleOrDefaultAsync(u => u.NumeroCuenta == NroCuenta);
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Id == cuentaFiduciaria.UsuarioId);
            decimal saldo = cuentaFiduciaria.SaldoDolares;
            Historial historial = new Historial(cuentaFiduciaria.UsuarioId, usuario.Cuil, 6, 2, saldo);

            _context.Historiales.Add(historial);
            return saldo;
        }



        public async Task<CuentaFiduciaria> GetByCuil(long cuil)
        {
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Cuil == cuil);
            var cuentaFiduciaria = await _context.CuentasFiduciarias.SingleOrDefaultAsync(u => u.UsuarioId == usuario.Id);
            return cuentaFiduciaria;
        }

        public async Task<List<CuentaFiduciaria>> GetAllByCuil(long cuil)
        {
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Cuil == cuil);
            var cuentasFiduciaria = await _context.CuentasFiduciarias.Where(x => x.UsuarioId == usuario.Id).ToListAsync();

            return cuentasFiduciaria;
        }


        public async Task<bool> DepositoPesosByNroCuenta(int NroCuenta, decimal monto)
        {
            var cuentaFiduciaria = await GetByNroCuenta(NroCuenta);
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Id == cuentaFiduciaria.UsuarioId);
            if (cuentaFiduciaria == null || monto <= 0) { return false; }

            cuentaFiduciaria.SaldoPesos += monto;
            Historial historial = new Historial(cuentaFiduciaria.UsuarioId, usuario.Cuil, 1, 1, monto);

            _context.Historiales.Add(historial);
            _context.CuentasFiduciarias.Update(cuentaFiduciaria);
            return true;
        }

        public async Task<bool> DepositoDolaresByNroCuenta(int NroCuenta, decimal monto)
        {
            var cuentaFiduciaria = await GetByNroCuenta(NroCuenta);
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Id == cuentaFiduciaria.UsuarioId);
            if (cuentaFiduciaria == null || monto <= 0) { return false; }

            cuentaFiduciaria.SaldoDolares += monto;
            Historial historial = new Historial(cuentaFiduciaria.UsuarioId, usuario.Cuil, 1, 2, monto);

            _context.Historiales.Add(historial);
            _context.CuentasFiduciarias.Update(cuentaFiduciaria);
            return true;
        }

        public async Task<bool> ExtraccionPesosByNroCuenta(int NroCuenta, decimal monto)
        {
            var cuentaFiduciaria = await GetByNroCuenta(NroCuenta);
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Id == cuentaFiduciaria.UsuarioId);
            if (cuentaFiduciaria == null || monto <= 0) { return false; }

            if (monto <= cuentaFiduciaria.SaldoPesos)
            {
                cuentaFiduciaria.SaldoPesos -= monto;
                Historial historial = new Historial(cuentaFiduciaria.UsuarioId, usuario.Cuil, 2, 1, monto);

                _context.Historiales.Add(historial);
                _context.CuentasFiduciarias.Update(cuentaFiduciaria);
                return true;
            }
            else { return false; }
        }

        public async Task<bool> ExtraccionDolaresByNroCuenta(int NroCuenta, decimal monto)
        {
            var cuentaFiduciaria = await GetByNroCuenta(NroCuenta);
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Id == cuentaFiduciaria.UsuarioId);
            if (cuentaFiduciaria == null || monto <= 0) { return false; }

            if (monto <= cuentaFiduciaria.SaldoDolares)
            {
                cuentaFiduciaria.SaldoDolares -= monto;
                Historial historial = new Historial(cuentaFiduciaria.UsuarioId, usuario.Cuil, 2, 2, monto);

                _context.Historiales.Add(historial);
                _context.CuentasFiduciarias.Update(cuentaFiduciaria);
                return true;
            }
            else { return false; }
        }


        public async Task<decimal> ConsultaVentaDolaresByNroCuenta(int NroCuenta, decimal dolarCotiz)
        {
            var cuentaFiduciaria = await GetByNroCuenta(NroCuenta);

            decimal consulta = cuentaFiduciaria.SaldoDolares * dolarCotiz;            //1500 representa el valor de BTC en dolares, la idea es obtener ese valor 
            return consulta;                                                        //por medio de una API externa
        }


        public async Task<bool> VentaDolares(int NroCuenta, decimal dolarCotiz, decimal monto)
        {
            var cuentaFiduciaria = await GetByNroCuenta(NroCuenta);
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Id == cuentaFiduciaria.UsuarioId);
            decimal pesos = monto * dolarCotiz;

            if (cuentaFiduciaria == null || monto <= 0 || monto > cuentaFiduciaria.SaldoDolares) { return false; }

            cuentaFiduciaria.SaldoPesos += pesos;
            cuentaFiduciaria.SaldoDolares -= monto;
            Historial historial = new Historial(cuentaFiduciaria.UsuarioId, usuario.Cuil, 3, 2, monto);

            _context.Historiales.Add(historial);
            _context.CuentasFiduciarias.Update(cuentaFiduciaria);
            return true;
        }

        public async Task<bool> TransferenciaPesos(int OrigenNroCuenta, int DestinoNroCuenta, decimal monto)
        {
            var cuentaOrigen = await GetByNroCuenta(OrigenNroCuenta);
            var cuentaDestino = await GetByNroCuenta(DestinoNroCuenta);
            var usuarioDestino = await _context.Usuarios.SingleOrDefaultAsync(u => u.Id == cuentaDestino.UsuarioId);
            if (cuentaOrigen == null || cuentaDestino == null || monto <= 0 || monto > cuentaOrigen.SaldoPesos || OrigenNroCuenta == DestinoNroCuenta) { return false; }

            cuentaOrigen.SaldoPesos -= monto;
            cuentaDestino.SaldoPesos += monto;
            Historial historial = new Historial(cuentaOrigen.UsuarioId, usuarioDestino.Cuil, 5, 1, monto);

            _context.Historiales.Add(historial);
            _context.CuentasFiduciarias.Update(cuentaOrigen);
            _context.CuentasFiduciarias.Update(cuentaDestino);
            return true;
        }

        public async Task<bool> TransferenciaDolares(int OrigenNroCuenta, int DestinoNroCuenta, decimal monto)
        {
            var cuentaOrigen = await GetByNroCuenta(OrigenNroCuenta);
            var cuentaDestino = await GetByNroCuenta(DestinoNroCuenta);
            var usuarioDestino = await _context.Usuarios.SingleOrDefaultAsync(u => u.Id == cuentaDestino.UsuarioId);

            if (cuentaOrigen == null || cuentaDestino == null || monto <= 0 || monto > cuentaOrigen.SaldoDolares || OrigenNroCuenta == DestinoNroCuenta) { return false; }

            Historial historial = new Historial(cuentaOrigen.UsuarioId, usuarioDestino.Cuil, 5, 2, monto);

            _context.Historiales.Add(historial);
            cuentaOrigen.SaldoDolares -= monto;
            cuentaDestino.SaldoDolares += monto;

            _context.CuentasFiduciarias.Update(cuentaOrigen);
            _context.CuentasFiduciarias.Update(cuentaDestino);
            return true;
        }

    }
}
