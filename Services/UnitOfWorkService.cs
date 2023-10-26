using TrabajoFinalSofttek.DataAccess;
using TrabajoFinalSofttek.DataAccess.Repositories;

namespace TrabajoFinalSofttek.Services
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UsuarioRepository UsuarioRepository { get; private set; }
        public CuentaFiduciariaRepository CuentaFiduciariaRepository { get; private set; }
        public CuentaCriptoRepository CuentaCriptoRepository { get; private set; }
        public HistorialRepository HistorialRepository { get; private set; }

        public UnitOfWorkService(ApplicationDbContext context)
        {
            _context = context;
            UsuarioRepository = new UsuarioRepository(_context);
            CuentaFiduciariaRepository = new CuentaFiduciariaRepository(_context);
            CuentaCriptoRepository = new CuentaCriptoRepository(_context);
            HistorialRepository = new HistorialRepository(_context);
        }

        public Task<int> Complete()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
