using TrabajoFinalSofttek.DataAccess.Repositories;

namespace TrabajoFinalSofttek.Services
{
    public interface IUnitOfWork : IDisposable
    {
        public UsuarioRepository UsuarioRepository { get; }
        public CuentaFiduciariaRepository CuentaFiduciariaRepository { get; }
        public CuentaCriptoRepository CuentaCriptoRepository { get; }
        Task<int> Complete();
    }
}
