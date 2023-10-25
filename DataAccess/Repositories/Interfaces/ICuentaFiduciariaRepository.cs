using TrabajoFinalSofttek.Entities;

namespace TrabajoFinalSofttek.DataAccess.Repositories.Interfaces
{
    public interface ICuentaFiduciariaRepository : IRepository<CuentaFiduciaria>
    {
        public Task<CuentaFiduciaria> GetByCuil(long cuil);
        public Task<CuentaFiduciaria> GetByNroCuenta(int NroCuenta);
        public Task<decimal> GetSaldoPesosByNroCuenta(int NroCuenta);
        public Task<decimal> GetSaldoDolaresByNroCuenta(int NroCuenta);
        public Task<List<CuentaFiduciaria>> GetAllByCuil(long cuil);
        public Task<bool> DepositoPesosByNroCuenta(int NroCuenta, decimal monto);
        public Task<bool> DepositoDolaresByNroCuenta(int NroCuenta, decimal monto);
        public  Task<bool> ExtraccionPesosByNroCuenta(int NroCuenta, decimal monto);
        public  Task<bool> ExtraccionDolaresByNroCuenta(int NroCuenta, decimal monto);
        public  Task<decimal> ConsultaVentaDolaresByNroCuenta(int NroCuenta, decimal dolarCotiz);
        public  Task<bool> VentaDolares(int NroCuenta, decimal dolarCotiz, decimal monto);
        public  Task<bool> TransferenciaPesos(int OrigenNroCuenta, int DestinoNroCuenta, decimal monto);
        public  Task<bool> TransferenciaDolares(int OrigenNroCuenta, int DestinoNroCuenta, decimal monto);
    }
}
