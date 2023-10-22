using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using TrabajoFinalSofttek.Services;

namespace TrabajoFinalSofttek.Controllers
{
    [ApiController]
    [Route("api/CuentaFiduciaria")]
    
    public class CuentaFiduciariaController : ControllerBase
    {
        private DolarCotizacion _dolarHelper;
        private readonly IUnitOfWork _unitOfWork;

        public CuentaFiduciariaController(DolarCotizacion dolarHelper, IUnitOfWork unitOfWork)
        {
            _dolarHelper = dolarHelper;
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// EndPoint para testear la API externa para obtener el valor del dolar
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Authorize]
        [Route("CotizacionDolar")]
        public async Task<Decimal> Dolar()
        {
                decimal valor = await _dolarHelper.ValorDolar();
                return valor;
        }



        //[Authorize]
        [HttpGet("CuentaByCuil/{cuil}")]
        public async Task<IActionResult> GetByCuil([FromRoute] long cuil)
        {
            var cuentaFiduciaria = await _unitOfWork.CuentaFiduciariaRepository.GetByCuil(cuil);
            if (cuentaFiduciaria == null)
            {
                return BadRequest("El Cuil proporcionado no existe.");
            }
            return Ok(cuentaFiduciaria);
        }

    }
}
