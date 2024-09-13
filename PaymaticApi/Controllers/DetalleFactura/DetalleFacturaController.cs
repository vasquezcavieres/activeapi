





/**
* (c)2013-2023 CodeBase Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*25-10-2023,Generador de Código, Clase Inicial 
*/

using Cl.Intertrade.ActivPay.Controllers.Base;
using Cl.Intertrade.ActivPay.Helpers.Base;
using Cl.Intertrade.ActivPay.Data.DetalleFactura;
using Cl.Intertrade.ActivPay.Request.DetalleFactura;
using Cl.Intertrade.ActivPay.Result.DetalleFactura;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;

namespace Cl.Intertrade.ActivPay.Controllers.DetalleFactura
{
	/// <summary>
	/// Esta Clase DetalleFactura  permite gestionar reglas de negocio asociados a la entidad DetalleFactura
	/// </summary>
    [Route("api/[controller]")]
    [ApiController]
	public class DetalleFacturaController : BaseController<DetalleFacturaController>
	{	
        IDetalleFacturaService detalleFacturaService;
        public DetalleFacturaController(ILogger<DetalleFacturaController> logger, IDetalleFacturaService detalleFacturaService, IWebHostEnvironment environment, ISettingsConfig settings)
		{
			this.logger = logger;
			this.detalleFacturaService = detalleFacturaService;
			this.environment = environment;
			this.settings = settings;
		}

        
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="detalleFacturaModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/detalleFacturas/all")]
		public ActionResult GetAll()
		{
			ListadoDetalleFacturaResult result = new ListadoDetalleFacturaResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.detalleFacturaService.ObtenerDetalleFacturas();
			}
            catch (Exception e)
            {
                logger.LogError($"Error DetalleFacturaController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.DetalleFacturas);
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="detalleFacturaModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
		[HttpGet("v1/detalleFacturas/{numeroFactura}/")]
		public ActionResult GetAll(int numeroFactura )
		{
			ListadoDetalleFacturaResult result = new ListadoDetalleFacturaResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.detalleFacturaService.BuscarDetalleFacturas(numeroFactura);
			}
            catch (Exception e)
            {
                logger.LogError($"Error DetalleFacturaController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.DetalleFacturas);
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="detalleFacturaModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/detalleFactura/{numeroFactura}/{transferenciaId}/")]
		public ActionResult Leer(int numeroFactura , int transferenciaId )
        {
			DetalleFacturaResult result = new DetalleFacturaResult() { StatusCode = StatusCodes.Status204NoContent };
			try
			{
                result = this.detalleFacturaService.ObtenerDetalleFactura(numeroFactura, transferenciaId);
			}
            catch (Exception e)
            {
                logger.LogError($"Error DetalleFacturaController.Get {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="detalleFacturaModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
		[HttpPost("v1/detalleFactura")]
        public IActionResult Post(DetalleFacturaRequest detalleFacturaRequest)
		{
			DetalleFacturaResult result = new DetalleFacturaResult() { StatusCode = StatusCodes.Status202Accepted };
			try
            {
				result = this.detalleFacturaService.CrearDetalleFactura(detalleFacturaRequest);
			}
			catch (Exception e)
            {
                logger.LogError($"Error DetalleFacturaController.HttpPost {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="detalleFacturaModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpPut("v1/detalleFactura/{numeroFactura}/{transferenciaId}/")]
		public IActionResult Put(int numeroFactura , int transferenciaId , [FromBody] DetalleFacturaRequest detalleFacturaRequest)
		{
			DetalleFacturaResult result = new DetalleFacturaResult() { StatusCode = StatusCodes.Status202Accepted };
			try
			{
				            detalleFacturaRequest.NumeroFactura = numeroFactura;
                            detalleFacturaRequest.TransferenciaId = transferenciaId;
                                result = this.detalleFacturaService.ActualizarDetalleFactura(detalleFacturaRequest);
			}
            catch (Exception e)
            {
                logger.LogError($"Error DetalleFacturaController.HttpPut {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
		}
		
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="detalleFacturaModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpDelete("v1/detalleFactura/{numeroFactura}/{transferenciaId}/")]
		public IActionResult Delete(int numeroFactura , int transferenciaId )
        {
			DetalleFacturaResult result = new DetalleFacturaResult() { StatusCode = StatusCodes.Status202Accepted };
			try
			{
				result = this.detalleFacturaService.EliminarDetalleFactura(numeroFactura, transferenciaId);
			}
            catch (Exception e)
            {
                logger.LogError($"Error DetalleFacturaController.HttpDelete {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }
	}
}

