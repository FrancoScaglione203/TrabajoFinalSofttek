using Microsoft.AspNetCore.Mvc;
using TrabajoFinalSofttek.Services;

namespace TrabajoFinalSofttek.Controllers
{
    [ApiController]
    [Route("api/CuentaCripto")]
    public class CuentaCriptoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CuentaCriptoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Devuelve la cuenta fiduciaria que corresponde al cuil ingresado
        /// </summary>
        /// <param name="cuil"></param>
        /// <returns>Retorna datos CuentaFiduciaria seleccionada</returns>
        //[Authorize]
        [HttpGet("CuentaByCuil/{cuil}")]
        public async Task<IActionResult> GetByCuil([FromRoute] long cuil)
        {
            var cuentaCripto = await _unitOfWork.CuentaCriptoRepository.GetByCuil(cuil);
            if (cuentaCripto == null)
            {
                return BadRequest("El Cuil proporcionado no existe.");
            }
            return Ok(cuentaCripto);
        }

        /// <summary>
        /// Deposita
        /// </summary>
        /// <param name="cuil"></param>
        /// <param name="monto"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpPut("DepositoByCuil/{cuil}")]
        public async Task<IActionResult> Deposito([FromRoute] long cuil, decimal monto)
        {
            var result = await _unitOfWork.CuentaCriptoRepository.DepositoByCuil(cuil, monto);
            if (!result)
            {
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
            else
            {
                await _unitOfWork.Complete();
                return Ok("Depositado con exito!");
            };
        }

        /// <summary>
        /// Extrae el monto que se solicita siempre y cuando no sea un monto mayor al saldo que hay en la cuenta
        /// </summary>
        /// <param name="cuil"></param>
        /// <param name="monto"></param>
        /// <returns>Retorna 200 si completo la extraccion o 500 si hubo un error</returns>
        //[Authorize]
        [HttpPut("ExtraccionByCuil/{cuil}")]
        public async Task<IActionResult> Extraccion([FromRoute] long cuil, decimal monto)
        {
            var result = await _unitOfWork.CuentaCriptoRepository.ExtraccionByCuil(cuil, monto);
            if (!result)
            {
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
            else
            {
                await _unitOfWork.Complete();
                return Ok("Extraccion exitosa!");
            };
        }
    }
}
