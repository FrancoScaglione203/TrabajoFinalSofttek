using TrabajoFinalSofttek.Entities;

namespace TrabajoFinalSofttek.DataAccess.Repositories.Interfaces
{
    public interface ICuentaCriptoRepository : IRepository<CuentaCripto>
    {
        public Task<CuentaCripto> GetByUUID(long UUID);
        public Task<decimal> GetSaldoByUUID(long UUID);
        public Task<List<CuentaCripto>> GetAllByCuil(long cuil);
        public Task<bool> DepositoByUUID(long UUID, decimal monto);
        public Task<bool> ExtraccionByUUID(long UUID, decimal monto);
        public Task<decimal> ConsultaCompraBTC(long UUID, decimal dolarCotiz);
        public Task<bool> CompraBTC(long UUID, decimal dolarCotiz, decimal monto, int NroCuenta);
        public Task<decimal> ConsultaVentaBTC(long UUID, decimal dolarCotiz);
        public  Task<bool> VentaBTC(long UUID, decimal dolarCotiz, decimal monto, int NroCuentaDestino);
        public  Task<bool> TransferenciaBTC(long OrigenUUID, long DestinoUUID, decimal monto);

    }
}
