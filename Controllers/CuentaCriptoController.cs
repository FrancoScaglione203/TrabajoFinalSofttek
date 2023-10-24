﻿using Microsoft.AspNetCore.Mvc;
using TrabajoFinalSofttek.DTOs;
using TrabajoFinalSofttek.Entities;
using TrabajoFinalSofttek.Services;

namespace TrabajoFinalSofttek.Controllers
{
    [ApiController]
    [Route("api/CuentaCripto")]
    public class CuentaCriptoController : Controller
    {
        private DolarCotizacion _dolarCotizacion;
        private readonly IUnitOfWork _unitOfWork;
        public CuentaCriptoController(DolarCotizacion dolarCotizacion, IUnitOfWork unitOfWork)
        {
            _dolarCotizacion = dolarCotizacion;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Agregar una cuenta Cripto a la DB
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Retorna Ok(200) cuando finaliza el Endpoint</returns>
        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar(CuentaCriptoDto dto)
        {
            var cuentaCripto = new CuentaCripto(dto);
            await _unitOfWork.CuentaCriptoRepository.Agregar(cuentaCripto);
            await _unitOfWork.Complete();

            return Ok("Cuenta agregada con éxito!");
        }


        /// <summary>
        /// Muestra todas las cuentas de cripto del cuil enviado
        /// </summary>
        /// <param name="cuil"></param>
        /// <returns>Retorna lista de CuentaCripto que tiene el idUsuario que coincide con el cuil</returns>
        [HttpGet]
        [Route("CuentasByCuil/{cuil}")]
        public async Task<IActionResult> GetAllByCuil([FromRoute] long cuil)
        {
            var cuentas = await _unitOfWork.CuentaCriptoRepository.GetAllByCuil(cuil);

            return Ok(cuentas);
        }

        /// <summary>
        /// Devuelve la cuenta con el UUID ingresado
        /// </summary>
        /// <param name="UUID"></param>
        /// <returns>retorna la cuenta solicitada</returns>
        [HttpGet]
        [Route("CuentaByUUID/{UUID}")]
        public async Task<IActionResult> GetByUUID([FromRoute] long UUID)
        {
            var cuenta = await _unitOfWork.CuentaCriptoRepository.GetByUUID(UUID);

            return Ok(cuenta);
        }

        /// <summary>
        /// Devuelve el saldo de BTC de la cuenta con el UUID ingresado
        /// </summary>
        /// <param name="UUID"></param>
        /// <returns>retorna un valor decimal con el saldo de la cuenta</returns>
        [HttpGet]
        [Route("SaldoByUUID/{UUID}")]
        public async Task<IActionResult> SaldoByUUID([FromRoute] long UUID)
        {
            decimal saldo = await _unitOfWork.CuentaCriptoRepository.GetSaldoByUUID(UUID);

            return Ok(saldo);
        }


        /// <summary>
        /// Deposita el monto ingresado en el cuenta Cripto con el UUID que se ingreso
        /// </summary>
        /// <param name="UUID"></param>
        /// <param name="monto"></param>
        /// <returns>Retorna ok(200) si deposito bien o Error(500) si ocurrio un error</returns>
        [HttpPut("DepositoByUUID/{UUID}")]
        public async Task<IActionResult> Deposito([FromRoute] long UUID, decimal monto)
        {
            var result = await _unitOfWork.CuentaCriptoRepository.DepositoByUUID(UUID, monto);
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
        /// Deposita el monto ingresado en el cuenta Cripto con el UUID que se ingreso
        /// </summary>
        /// <param name="UUID"></param>
        /// <param name="monto"></param>
        /// <returns>Retorna ok(200) si deposito bien o Error(500) si ocurrio un error</returns>
        [HttpPut("ExtraccionByUUID/{UUID}")]
        public async Task<IActionResult> Extraccion([FromRoute] long UUID, decimal monto)
        {
            var result = await _unitOfWork.CuentaCriptoRepository.ExtraccionByUUID(UUID, monto);
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

        /// <summary>
        /// Devuelve el equivalente en pesos del saldo de la cuenta con el UUID ingresado
        /// </summary>
        /// <param name="UUID"></param>
        /// <returns>Retorna ok(200) finalizada la consulta</returns>
        [HttpGet("ConsultaVentaBTCByUUID/{UUID}")]
        public async Task<IActionResult> ConsultaVenta([FromRoute] long UUID)
        {
            decimal dolarCotiz = await _dolarCotizacion.ValorDolar();
            decimal consultaVentaBTC = await _unitOfWork.CuentaCriptoRepository.ConsultaVentaBTC(UUID, dolarCotiz);

            return Ok(consultaVentaBTC);
        }

        /// <summary>
        /// Vende la cantidad de BTC indicadas de la cuenta con el UUID ingresado y las deposita en el nro de cuenta en pesos
        /// </summary>
        /// <param name="UUID"></param>
        /// <param name="monto"></param>
        /// <param name="NroCuentaDestino"></param>
        /// <returns>Retorna ok(200) si deposito bien o Error(500) si ocurrio un error</returns>
        [HttpPut("VentaBTCByUUID/{UUID}")]
        public async Task<IActionResult> Venta([FromRoute] long UUID, decimal monto, int NroCuentaDestino)
        {
            decimal dolarCotiz = await _dolarCotizacion.ValorDolar();
            var result = await _unitOfWork.CuentaCriptoRepository.VentaBTC(UUID, dolarCotiz, monto, NroCuentaDestino);
            if (!result)
            {
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
            else
            {
                await _unitOfWork.Complete();
                return Ok("Compra exitosa!");
            };
        }



    }
}