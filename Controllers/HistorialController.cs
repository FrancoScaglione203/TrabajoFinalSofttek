using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrabajoFinalSofttek.DTOs;
using TrabajoFinalSofttek.Entities;
using TrabajoFinalSofttek.Services;

namespace TrabajoFinalSofttek.Controllers
{
    [ApiController]
    [Route("api/Historial")]
    public class HistorialController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        public HistorialController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// Muestra todos los historiales que pertenecen al cuil enviado
        /// </summary>
        /// <param name="cuil"></param>
        /// <returns>Retorna lista de CuentaCripto que tiene el idUsuario que coincide con el cuil</returns>
        [HttpGet]
        [Authorize]
        [Route("HistorialByCuil/{cuil}")]
        public async Task<IActionResult> GetAllByCuil([FromRoute] long cuil)
        {
            var historial = await _unitOfWork.HistorialRepository.GetAllByCuil(cuil);

            return Ok(historial);
        }

        /// <summary>
        /// Agregar un Historial a DB, se usó para testear
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar(HistorialDto dto)
        {
            var historial = new Historial(dto);
            await _unitOfWork.HistorialRepository.Agregar(historial);
            await _unitOfWork.Complete();

            return Ok("Se guardo historial correctamente");
        }
    }
}
