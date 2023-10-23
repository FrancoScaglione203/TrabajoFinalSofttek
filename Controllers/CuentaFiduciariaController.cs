﻿using Microsoft.AspNetCore.Authorization;
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
        private DolarCotizacion _dolarCotizacion;
        private readonly IUnitOfWork _unitOfWork;

        public CuentaFiduciariaController(DolarCotizacion dolarHelper, IUnitOfWork unitOfWork)
        {
            _dolarCotizacion = dolarHelper;
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// EndPoint para testear la API externa para obtener el valor del dolar
        /// </summary>
        /// <returns></returns>
        //[Authorize]
        [HttpGet]
        [Route("CotizacionDolar")]
        public async Task<Decimal> Dolar()
        {
                decimal valor = await _dolarCotizacion.ValorDolar();
                return valor;
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
            var cuentaFiduciaria = await _unitOfWork.CuentaFiduciariaRepository.GetByCuil(cuil);
            if (cuentaFiduciaria == null)
            {
                return BadRequest("El Cuil proporcionado no existe.");
            }
            return Ok(cuentaFiduciaria);
        }


        /// <summary>
        /// Deposita
        /// </summary>
        /// <param name="cuil"></param>
        /// <param name="monto"></param>
        /// <param name="idMoneda"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpPut("DepositoByCuil/{cuil}")]
        public async Task<IActionResult> Deposito([FromRoute] long cuil, decimal monto, int idMoneda)
        {
            var result = await _unitOfWork.CuentaFiduciariaRepository.DepositoByCuil(cuil, monto, idMoneda);
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
        /// Extrae el monto de la moneda que se solicita siempre y cuando no sea un monto mayor al saldo que hay en la cuenta
        /// </summary>
        /// <param name="cuil"></param>
        /// <param name="monto"></param>
        /// <param name="idMoneda"></param>
        /// <returns>Retorna 200 si completo la extraccion o 500 si hubo un error</returns>
        //[Authorize]
        [HttpPut("ExtraccionByCuil/{cuil}")]
        public async Task<IActionResult> Extraccion([FromRoute] long cuil, decimal monto, int idMoneda)
        {
            var result = await _unitOfWork.CuentaFiduciariaRepository.ExtraccionByCuil(cuil, monto, idMoneda);
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
