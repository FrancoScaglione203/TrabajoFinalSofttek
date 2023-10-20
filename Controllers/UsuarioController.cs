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
        [Route("Usuarios")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()
        {
            var usuarios = await _unitOfWork.UsuarioRepository.GetAll();

            return usuarios;
        }




        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar(UsuarioDto dto)
        {
            var usuario = new Usuario(dto);

            var cuentaFiduciaria = new CuentaFiduciaria(dto.CuentaFiduciariaDto);
            await _unitOfWork.CuentaFiduciariaRepository.Insert(cuentaFiduciaria);


            var cuentaCripto = new CuentaCripto(dto.CuentaCriptoDto);
            await _unitOfWork.CuentaCriptoRepository.Insert(cuentaCripto);


            await _unitOfWork.Complete();

            usuario.CuentaFiduciariaId = cuentaFiduciaria.Id;
            usuario.CuentaCriptoId = cuentaCripto.Id;

            await _unitOfWork.UsuarioRepository.Agregar(usuario);
            await _unitOfWork.Complete();


            return Ok("Usuario registrado con éxito!");
        }
    }
}
