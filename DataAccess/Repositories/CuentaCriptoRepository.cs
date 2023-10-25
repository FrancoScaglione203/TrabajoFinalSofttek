using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using TrabajoFinalSofttek.DataAccess.Repositories.Interfaces;
using TrabajoFinalSofttek.Entities;
using TrabajoFinalSofttek.Services;

namespace TrabajoFinalSofttek.DataAccess.Repositories
{
    public class CuentaCriptoRepository : Repository<CuentaCripto>, ICuentaCriptoRepository
    {
        private DolarCotizacion _dolarCotizacion;

        public CuentaCriptoRepository(ApplicationDbContext context) : base(context)
        {
            
        }


        public async Task<CuentaCripto> GetByUUID(long UUID)
        {
            var cuentaCripto = await _context.CuentasCriptos.SingleOrDefaultAsync(u => u.UUID == UUID);
            return cuentaCripto;
        }

        public async Task<decimal> GetSaldoByUUID(long UUID)
        {
            var cuentaCripto = await _context.CuentasCriptos.SingleOrDefaultAsync(u => u.UUID == UUID);
            decimal saldo = cuentaCripto.Saldo;
            return saldo;
        }

        public async Task<List<CuentaCripto>> GetAllByCuil(long cuil)
        {
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Cuil == cuil);
            var cuentasCripto = await _context.CuentasCriptos.Where(x => x.UsuarioId == usuario.Id).ToListAsync();
            return cuentasCripto;
        }


        public async Task<bool> DepositoByUUID(long UUID, decimal monto)
        {
            var cuentaCripto = await GetByUUID(UUID);
            if (cuentaCripto == null || monto <= 0) { return false; }

                cuentaCripto.Saldo += monto;
            
            _context.CuentasCriptos.Update(cuentaCripto);
            return true;
        }


        public async Task<bool> ExtraccionByUUID(long UUID, decimal monto)
        {
            var cuentaCripto = await GetByUUID(UUID);
            if (cuentaCripto == null || monto <= 0) { return false; }

            if (monto <= cuentaCripto.Saldo)
            {
                cuentaCripto.Saldo -= monto;
                _context.CuentasCriptos.Update(cuentaCripto);
                return true;
            }
            else { return false; }
        }


        public async Task<decimal> ConsultaCompraBTC(long UUID, decimal dolarCotiz)
        {
            var cuentaCripto = await GetByUUID(UUID);
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Id == cuentaCripto.UsuarioId);
            var cuentaFiduciaria = await _context.CuentasFiduciarias.SingleOrDefaultAsync(u => u.UsuarioId == usuario.Id);

            decimal consulta = ((cuentaFiduciaria.SaldoPesos / dolarCotiz) / 1500);   //1500 representa el valor de BTC en dolares, la idea es obtener ese valor 
            return consulta;                                                        //por medio de una API externa
        }


        public async Task<bool> CompraBTC(long UUID, decimal dolarCotiz, decimal monto, int NroCuenta)
        {
            var cuentaFiduciaria = await _context.CuentasFiduciarias.SingleOrDefaultAsync(u => u.NumeroCuenta == NroCuenta);
            var cuentaCripto = await GetByUUID(UUID);
            decimal maximo = await ConsultaCompraBTC(UUID, dolarCotiz);
            decimal pesos = ((monto * 1500) * dolarCotiz);

            if (cuentaFiduciaria == null || cuentaCripto == null || monto <= 0 || monto > maximo) { return false; }

            cuentaFiduciaria.SaldoPesos -= pesos;
            cuentaCripto.Saldo += monto;
            _context.CuentasFiduciarias.Update(cuentaFiduciaria);
            _context.CuentasCriptos.Update(cuentaCripto);
            return true;
        }

        public async Task<decimal> ConsultaVentaBTC(long UUID, decimal dolarCotiz)
        {
            var cuentaCripto = await GetByUUID(UUID);

            decimal consulta = (cuentaCripto.Saldo * 1500) * dolarCotiz;            //1500 representa el valor de BTC en dolares, la idea es obtener ese valor 
            return consulta;                                                        //por medio de una API externa
        }

        public async Task<bool> VentaBTC(long UUID, decimal dolarCotiz, decimal monto, int NroCuentaDestino)
        {
            var cuentaCripto = await GetByUUID(UUID);
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Id == cuentaCripto.UsuarioId);
            var cuentaFiduciaria = await _context.CuentasFiduciarias.SingleOrDefaultAsync(u => u.UsuarioId == usuario.Id && u.NumeroCuenta == NroCuentaDestino);

            decimal maximo = await ConsultaVentaBTC(UUID, dolarCotiz);
            decimal pesos = ((monto * 1500) * dolarCotiz);

            if (cuentaFiduciaria == null || cuentaCripto == null || monto <= 0 || monto > cuentaCripto.Saldo) { return false; }


            cuentaFiduciaria.SaldoPesos += pesos;
            cuentaCripto.Saldo -= monto;
            _context.CuentasFiduciarias.Update(cuentaFiduciaria);
            _context.CuentasCriptos.Update(cuentaCripto);
            return true;
        }

        public async Task<bool> TransferenciaBTC(long OrigenUUID, long DestinoUUID, decimal monto)
        {
            var cuentaOrigen = await GetByUUID(OrigenUUID);
            var cuentaDestino = await GetByUUID(DestinoUUID);

            if (cuentaOrigen == null || cuentaDestino == null || monto <= 0 || monto > cuentaOrigen.Saldo || OrigenUUID == DestinoUUID) { return false; }

            cuentaOrigen.Saldo -= monto;
            cuentaDestino.Saldo += monto;

            _context.CuentasCriptos.Update(cuentaOrigen);
            _context.CuentasCriptos.Update(cuentaDestino);
            return true;
        }

    }
}
