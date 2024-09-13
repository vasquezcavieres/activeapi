/**
* (c)2013-2023 CodeBase Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*13-09-2023,Generador de Código, Clase Inicial 
*/

using Cl.Intertrade.ActivPay.Controllers.Base;
using Cl.Intertrade.ActivPay.Helpers.Base;
using Cl.Intertrade.ActivPay.Data.DetalleTransferencia;
using Cl.Intertrade.ActivPay.Request.DetalleTransferencia;
using Cl.Intertrade.ActivPay.Result.DetalleTransferencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;

namespace Cl.Intertrade.ActivPay.Controllers.DetalleTransferencia
{
	/// <summary>
	/// Esta Clase DetalleTransferencia  permite gestionar reglas de negocio asociados a la entidad DetalleTransferencia
	/// </summary>
    [Route("api/[controller]")]
    [ApiController]
	public class DetalleTransferenciaController : BaseController<DetalleTransferenciaController>
	{	
        IDetalleTransferenciaService detalleTransferenciaService;
        public DetalleTransferenciaController(ILogger<DetalleTransferenciaController> logger, IDetalleTransferenciaService detalleTransferenciaService, IWebHostEnvironment environment, ISettingsConfig settings)
		{
			this.logger = logger;
			this.detalleTransferenciaService = detalleTransferenciaService;
			this.environment = environment;
			this.settings = settings;
		}

        
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="detalleTransferenciaModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/detalleTransferencias/all")]
		public ActionResult GetAll()
		{
			ListadoDetalleTransferenciaResult result = new ListadoDetalleTransferenciaResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.detalleTransferenciaService.ObtenerDetalleTransferencias();
			}
            catch (Exception e)
            {
                logger.LogError($"Error DetalleTransferenciaController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.DetalleTransferencias);
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="detalleTransferenciaModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
		[HttpGet("v1/detalleTransferencias/{transferenciaId}/{rutRazonSocial}/")]
		public ActionResult GetAll(int transferenciaId , int rutRazonSocial )
		{
			ListadoDetalleTransferenciaResult result = new ListadoDetalleTransferenciaResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.detalleTransferenciaService.BuscarDetalleTransferencias(transferenciaId, rutRazonSocial);
			}
            catch (Exception e)
            {
                logger.LogError($"Error DetalleTransferenciaController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.DetalleTransferencias);
		}

        [HttpGet("v1/detalleTransferencias/{transferenciaId}/")]
        public ActionResult GetAll(int transferenciaId)
        {
            ListadoDetalleTransferenciaResult result = new ListadoDetalleTransferenciaResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.detalleTransferenciaService.BuscarDetalleTransferencias(transferenciaId);
            }
            catch (Exception e)
            {
                logger.LogError($"Error DetalleTransferenciaController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.DetalleTransferencias);
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="detalleTransferenciaModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/detalleTransferencia/{transferenciaId}/{rutRazonSocial}/")]
		public ActionResult Leer(int transferenciaId , int rutRazonSocial )
        {
			DetalleTransferenciaResult result = new DetalleTransferenciaResult() { StatusCode = StatusCodes.Status204NoContent };
			try
			{
                result = this.detalleTransferenciaService.ObtenerDetalleTransferencia(transferenciaId, rutRazonSocial);
			}
            catch (Exception e)
            {
                logger.LogError($"Error DetalleTransferenciaController.Get {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="detalleTransferenciaModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
		[HttpPost("v1/detalleTransferencia")]
        public IActionResult Post(DetalleTransferenciaRequest detalleTransferenciaRequest)
		{
			DetalleTransferenciaResult result = new DetalleTransferenciaResult() { StatusCode = StatusCodes.Status202Accepted };
			try
            {
				result = this.detalleTransferenciaService.CrearDetalleTransferencia(detalleTransferenciaRequest);
			}
			catch (Exception e)
            {
                logger.LogError($"Error DetalleTransferenciaController.HttpPost {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="detalleTransferenciaModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpPut("v1/detalleTransferencia/{transferenciaId}/{rutRazonSocial}/")]
		public IActionResult Put(int transferenciaId , int rutRazonSocial , [FromBody] DetalleTransferenciaRequest detalleTransferenciaRequest)
		{
			DetalleTransferenciaResult result = new DetalleTransferenciaResult() { StatusCode = StatusCodes.Status202Accepted };
			try
			{
				            detalleTransferenciaRequest.TransferenciaId = transferenciaId;
                            detalleTransferenciaRequest.RutRazonSocial = rutRazonSocial;
                                result = this.detalleTransferenciaService.ActualizarDetalleTransferencia(detalleTransferenciaRequest);
			}
            catch (Exception e)
            {
                logger.LogError($"Error DetalleTransferenciaController.HttpPut {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
		}
		
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="detalleTransferenciaModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpDelete("v1/detalleTransferencia/{transferenciaId}/{rutRazonSocial}/")]
		public IActionResult Delete(int transferenciaId , int rutRazonSocial )
        {
			DetalleTransferenciaResult result = new DetalleTransferenciaResult() { StatusCode = StatusCodes.Status202Accepted };
			try
			{
				result = this.detalleTransferenciaService.EliminarDetalleTransferencia(transferenciaId, rutRazonSocial);
			}
            catch (Exception e)
            {
                logger.LogError($"Error DetalleTransferenciaController.HttpDelete {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }
	}
}

