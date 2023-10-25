using Microsoft.EntityFrameworkCore;
using TrabajoFinalSofttek.DataAccess.Repositories.Interfaces;
using TrabajoFinalSofttek.Entities;

namespace TrabajoFinalSofttek.DataAccess.Repositories
{
    public class HistorialRepository : Repository<Historial>, IHistorialRepository
    {
        public HistorialRepository(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Devuelve lista de historiales correspondientes al cuil ingresado
        /// </summary>
        /// <param name="cuil"></param>
        /// <returns></returns>
        public async Task<List<Historial>> GetAllByCuil(long cuil)
        {
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Cuil == cuil);
            var historial = await _context.Historiales.Where(x => x.UsuarioId == usuario.Id).ToListAsync();
            return historial;
        }
    }
}
