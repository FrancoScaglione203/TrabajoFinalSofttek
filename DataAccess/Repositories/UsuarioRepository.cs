using Microsoft.EntityFrameworkCore;
using TrabajoFinalSofttek.DataAccess.Repositories.Interfaces;
using TrabajoFinalSofttek.DTOs;
using TrabajoFinalSofttek.Entities;


namespace TrabajoFinalSofttek.DataAccess.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {
        }


        public async Task<bool> UsuarioEx(long Cuil)
        {
            return await _context.Usuarios.AnyAsync(x => x.Cuil == Cuil);
        }

        public async Task<Usuario?> AuthenticateCredentials(AuthenticateDto dto)
        {
            return await _context.Usuarios.SingleOrDefaultAsync(x => x.Cuil == dto.Cuil && x.Clave == dto.Clave);
        }

    }
}
