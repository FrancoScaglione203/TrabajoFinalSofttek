using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using TrabajoFinalSofttek.DTOs;
using TrabajoFinalSofttek.Entities;
using TrabajoFinalSofttek.Helpers;
using TrabajoFinalSofttek.Services;

namespace TrabajoFinalSofttek.Controllers
{
    [ApiController]
    [Route("api/CuentaFiduciaria")]
    
    public class CuentaFiduciariaController : ControllerBase
    {
        private DolarCotizacion _dolarCotizacion;
        private readonly IUnitOfWork _unitOfWork;

        public CuentaFiduciariaController(DolarCotizacion dolarCotizacion, IUnitOfWork unitOfWork)
        {
            _dolarCotizacion = dolarCotizacion;
            _unitOfWork = unitOfWork;
        }


        
        /// <summary>
        /// Agrega una CuentaFiduciaria a DB
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar(CuentaFiduciariaDto dto)
        {
            var cuentaFiduciaria = new CuentaFiduciaria(dto);
            await _unitOfWork.CuentaFiduciariaRepository.Agregar(cuentaFiduciaria);
            await _unitOfWork.Complete();

            return Ok("Cuenta agregada con éxito!");
        }


        /// <summary>
        /// EndPoint que devuelve la cotizacion del dolar actualizada
        /// </summary>
        /// <returns></returns>
        //[Authorize]
        [HttpGet]
        [Authorize]
        [Route("CotizacionDolar")]
        public async Task<Decimal> Dolar()
        {
            decimal valor = await _dolarCotizacion.ValorDolar();
            return valor;
        }

        /// <summary>
        /// Muestra todas las cuentas de cripto del cuil enviado
        /// </summary>
        /// <param name="cuil"></param>
        /// <returns>Retorna lista de CuentaCripto que tiene el idUsuario que coincide con el cuil</returns>
        [HttpGet]
        [Authorize]
        [Route("CuentasByCuil/{cuil}")]
        public async Task<IActionResult> GetAllByCuil([FromRoute] long cuil)
        {
            var cuentas = await _unitOfWork.CuentaFiduciariaRepository.GetAllByCuil(cuil);

            return Ok(cuentas);
        }


        /// <summary>
        /// Devuelve la cuenta con el NroCuenta ingresado
        /// </summary>
        /// <param name="NroCuenta"></param>
        /// <returns>retorna la cuenta solicitada</returns>
        [HttpGet]
        [Authorize]
        [Route("CuentaByNroCuenta/{NroCuenta}")]
        public async Task<IActionResult> GetByNroCuenta([FromRoute] int NroCuenta)
        {
            var cuenta = await _unitOfWork.CuentaFiduciariaRepository.GetByNroCuenta(NroCuenta);

            return Ok(cuenta);
        }


        /// <summary>
        /// Devuelve el saldo de Pesos de la cuenta con el NroCuenta ingresado
        /// </summary>
        /// <param name="NroCuenta"></param>
        /// <returns>retorna un valor decimal con el saldo de la cuenta</returns>
        [HttpGet]
        [Authorize]
        [Route("SaldoPesosByNroCuenta/{NroCuenta}")]
        public async Task<IActionResult> SaldoByNroCuenta([FromRoute] int NroCuenta)
        {
            decimal saldo = await _unitOfWork.CuentaFiduciariaRepository.GetSaldoPesosByNroCuenta(NroCuenta);

            return Ok(saldo);
        }


        /// <summary>
        /// Devuelve el saldo de Dolares de la cuenta con el NroCuenta ingresado
        /// </summary>
        /// <param name="NroCuenta"></param>
        /// <returns>retorna un valor decimal con el saldo de la cuenta</returns>
        [HttpGet]
        [Authorize]
        [Route("SaldoDolaresByNroCuenta/{NroCuenta}")]
        public async Task<IActionResult> SaldoDolaresByNroCuenta([FromRoute] int NroCuenta)
        {
            decimal saldo = await _unitOfWork.CuentaFiduciariaRepository.GetSaldoDolaresByNroCuenta(NroCuenta);

            return Ok(saldo);
        }


        /// <summary>
        /// Devuelve el equivalente en Pesos del SaldoDolares de la cuenta con el NroCuenta ingresado
        /// </summary>
        /// <param name="NroCuenta"></param>
        /// <returns>Retorna ok(200) finalizada la consulta</returns>
        [HttpGet]
        [Authorize]
        [Route("ConsultaVentaDolaresByNroCuenta/{NroCuenta}")]
        public async Task<IActionResult> ConsultaVentaDolares([FromRoute] int NroCuenta)
        {
            decimal dolarCotiz = await _dolarCotizacion.ValorDolar();
            decimal consultaVentaDolares = await _unitOfWork.CuentaFiduciariaRepository.ConsultaVentaDolaresByNroCuenta(NroCuenta, dolarCotiz);

            return Ok(consultaVentaDolares);
        }

        /// <summary>
        /// Deposita el monto ingresado en el cuenta Fiduciaria con el NroCuenta que se ingreso
        /// </summary>
        /// <param name="NroCuenta"></param>
        /// <param name="monto"></param>
        /// <returns>Retorna ok(200) si deposito bien o Error(500) si ocurrio un error</returns>
        [HttpPut]
        [Authorize]
        [Route("DepositoPesosByNroCuenta/{NroCuenta}")]
        public async Task<IActionResult> DepositoPesos([FromRoute] int NroCuenta, decimal monto)
        {
            var result = await _unitOfWork.CuentaFiduciariaRepository.DepositoPesosByNroCuenta(NroCuenta, monto);
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
        /// Deposita el monto ingresado en el cuenta Fiduciaria con el NroCuenta que se ingreso
        /// </summary>
        /// <param name="NroCuenta"></param>
        /// <param name="monto"></param>
        /// <returns>Retorna ok(200) si deposito bien o Error(500) si ocurrio un error</returns>
        [HttpPut]
        [Authorize]
        [Route("DepositoDolaresByNroCuenta/{NroCuenta}")]
        public async Task<IActionResult> DepositoDolares([FromRoute] int NroCuenta, decimal monto)
        {
            var result = await _unitOfWork.CuentaFiduciariaRepository.DepositoDolaresByNroCuenta(NroCuenta, monto);
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
        /// Extrae el monto ingresado de la cuenta Fiduciaria con el NroCuenta que se ingreso
        /// </summary>
        /// <param name="NroCuenta"></param>
        /// <param name="monto"></param>
        /// <returns>Retorna ok(200) si extrajo bien o Error(500) si ocurrio un error</returns>
        [HttpPut]
        [Authorize]
        [Route("ExtraccionPesosByNroCuenta/{NroCuenta}")]
        public async Task<IActionResult> ExtraccionPesos([FromRoute] int NroCuenta, decimal monto)
        {
            var result = await _unitOfWork.CuentaFiduciariaRepository.ExtraccionPesosByNroCuenta(NroCuenta, monto);
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
        /// Extrae el monto ingresado de la cuenta Fiduciaria con el NroCuenta que se ingreso
        /// </summary>
        /// <param name="NroCuenta"></param>
        /// <param name="monto"></param>
        /// <returns>Retorna ok(200) si extrajo bien o Error(500) si ocurrio un error</returns>
        [HttpPut]
        [Authorize]
        [Route("ExtraccionDolaresByNroCuenta/{NroCuenta}")]
        public async Task<IActionResult> ExtraccionDolares([FromRoute] int NroCuenta, decimal monto)
        {
            var result = await _unitOfWork.CuentaFiduciariaRepository.ExtraccionDolaresByNroCuenta(NroCuenta, monto);
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
        /// Vende la cantidad de Dolares indicadas de la cuenta con el NroCuenta ingresado y las deposita en el nro de cuenta en pesos
        /// </summary>
        /// <param name="NroCuenta"></param>
        /// <param name="monto"></param>
        /// <returns>Retorna ok(200) si deposito bien o Error(500) si ocurrio un error</returns>
        [HttpPut]
        [Authorize]
        [Route("VentaDolaresByNroCuenta/{NroCuenta}")]
        public async Task<IActionResult> Venta([FromRoute] int NroCuenta, decimal monto)
        {
            decimal dolarCotiz = await _dolarCotizacion.ValorDolar();
            var result = await _unitOfWork.CuentaFiduciariaRepository.VentaDolares(NroCuenta, dolarCotiz, monto);
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

        /// <summary>
        /// Tranfiere pesos de la cuenta origen a la cuenta destino
        /// </summary>
        /// <param name="OringenNroCuenta"></param>
        /// <param name="DestinoNroCuenta"></param>
        /// <param name="monto"></param>
        /// <returns>retorna ok(200) si fue exitosa error(500) si hubo un error</returns>
        [HttpPut]
        [Authorize]
        [Route("TransferenciaPesos")]
        public async Task<IActionResult> TransferenciaPesos(int OringenNroCuenta, int DestinoNroCuenta, decimal monto)
        {
            decimal dolarCotiz = await _dolarCotizacion.ValorDolar();
            var result = await _unitOfWork.CuentaFiduciariaRepository.TransferenciaPesos(OringenNroCuenta, DestinoNroCuenta, monto);
            if (!result)
            {
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
            else
            {
                await _unitOfWork.Complete();
                return Ok("Transferencia exitosa!");
            };
        }


        /// <summary>
        /// Tranfiere dolares de la cuenta origen a la cuenta destino
        /// </summary>
        /// <param name="OringenNroCuenta"></param>
        /// <param name="DestinoNroCuenta"></param>
        /// <param name="monto"></param>
        /// <returns>retorna ok(200) si fue exitosa error(500) si hubo un error</returns>
        [HttpPut]
        [Authorize]
        [Route("TransferenciaDolares")]
        public async Task<IActionResult> TransferenciaDolares(int OringenNroCuenta, int DestinoNroCuenta, decimal monto)
        {
            decimal dolarCotiz = await _dolarCotizacion.ValorDolar();
            var result = await _unitOfWork.CuentaFiduciariaRepository.TransferenciaDolares(OringenNroCuenta, DestinoNroCuenta, monto);
            if (!result)
            {
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
            else
            {
                await _unitOfWork.Complete();
                return Ok("Transferencia exitosa!");
            };
        }

    }
}
