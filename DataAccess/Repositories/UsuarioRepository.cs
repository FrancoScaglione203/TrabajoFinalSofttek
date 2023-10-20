using TrabajoFinalSofttek.DataAccess.Repositories.Interfaces;
using TrabajoFinalSofttek.Entities;


namespace TrabajoFinalSofttek.DataAccess.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {
        }

        public virtual async Task<bool> Agregar(Usuario usuario)
        {

            await _context.Set<Usuario>().AddAsync(usuario);


            return true;
        }

        public virtual async Task<bool> AgregarTodo(Usuario usuario, CuentaFiduciaria cuentaFiduciaria, CuentaCripto cuentaCripto)
        {
            cuentaFiduciaria.Id = 0;
            cuentaCripto.Id = 0;

            await _context.Set<CuentaFiduciaria>().AddAsync(cuentaFiduciaria);
            await _context.Set<CuentaCripto>().AddAsync(cuentaCripto);

            await _context.SaveChangesAsync();

            usuario.CuentaFiduciariaId = cuentaFiduciaria.Id;
            usuario.CuentaCriptoId = cuentaCripto.Id;

            await _context.Set<Usuario>().AddAsync(usuario);


            return true;
        }
    }
}
