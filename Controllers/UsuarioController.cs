using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrabajoFinalSofttek.DTOs;
using TrabajoFinalSofttek.Entities;
using TrabajoFinalSofttek.Services;

namespace TrabajoFinalSofttek.Controllers
{
    [Route("api/Usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsuarioController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Devuelve todos los usuarios
        /// </summary>
        /// <returns>Retorna lista de clase Usuario</returns>
        [HttpGet]
        [Authorize]
        [Route("Usuarios")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()
        {
            var usuarios = await _unitOfWork.UsuarioRepository.GetAll();

            return usuarios;
        }



        /// <summary>
        /// Agrega un Usuario a la DB
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Ok(200) si se agrego bien o Error si hubo un error</returns>
        [HttpPost]
        [Authorize]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar(UsuarioDto dto)
        {
            if (await _unitOfWork.UsuarioRepository.UsuarioEx(dto.Cuil)) return Conflict($"Ya existe un usuario registrado con la descripcion:{dto.Cuil}");
            var usuario = new Usuario(dto);

            await _unitOfWork.UsuarioRepository.Agregar(usuario);
            await _unitOfWork.Complete();

            return Ok("Usuario registrado con éxito!");
        }
    }
}
