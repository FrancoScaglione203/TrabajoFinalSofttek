using TrabajoFinalSofttek.DTOs;
using TrabajoFinalSofttek.Entities;

namespace TrabajoFinalSofttek.DataAccess.Repositories.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        public Task<bool> UsuarioEx(long Cuil);
        public Task<Usuario?> AuthenticateCredentials(AuthenticateDto dto);
    }
}
