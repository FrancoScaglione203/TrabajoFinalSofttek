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

        /// <summary>
        /// Validacion si ya existe usuario con cuil ingresado
        /// </summary>
        /// <param name="Cuil"></param>
        /// <returns></returns>
        public async Task<bool> UsuarioEx(long Cuil)
        {
            return await _context.Usuarios.AnyAsync(x => x.Cuil == Cuil);
        }

        /// <summary>
        /// Funcion para verificar que cuil y clave sean correctos
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<Usuario?> AuthenticateCredentials(AuthenticateDto dto)
        {
            return await _context.Usuarios.SingleOrDefaultAsync(x => x.Cuil == dto.Cuil && x.Clave == dto.Clave);
        }

    }
}
