





/**
* (c)2013-2023 CodeBase Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*27-09-2023,Generador de Código, Clase Inicial 
*/

using Cl.Intertrade.ActivPay.Controllers.Base;
using Cl.Intertrade.ActivPay.Helpers.Base;
using Cl.Intertrade.ActivPay.Data.Pago;
using Cl.Intertrade.ActivPay.Request.Pago;
using Cl.Intertrade.ActivPay.Result.Pago;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;

namespace Cl.Intertrade.ActivPay.Controllers.Pago
{
	/// <summary>
	/// Esta Clase Pago  permite gestionar reglas de negocio asociados a la entidad Pago
	/// </summary>
    [Route("api/[controller]")]
    [ApiController]
	public class PagoController : BaseController<PagoController>
	{	
        IPagoService pagoService;
        public PagoController(ILogger<PagoController> logger, IPagoService pagoService, IWebHostEnvironment environment, ISettingsConfig settings)
		{
			this.logger = logger;
			this.pagoService = pagoService;
			this.environment = environment;
			this.settings = settings;
		}

        
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="pagoModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
  //      [HttpGet("v1/pagos/all")]
		//public ActionResult GetAll()
		//{
		//	ListadoPagoResult result = new ListadoPagoResult() { StatusCode = StatusCodes.Status204NoContent };
  //          try
  //          {
  //              result = this.pagoService.ObtenerPagos();
		//	}
  //          catch (Exception e)
  //          {
  //              logger.LogError($"Error PagoController.GetAll {e.StackTrace}");
  //              return StatusCode(StatusCodes.Status500InternalServerError);
  //          }
  //          return StatusCode(result.StatusCode, result.Pagos);
		//}

        [HttpPost("v1/pagos/all")]
        public ActionResult GetAll(PagoRequest pagoRequest)
        {
            ListadoPagoResult result = new ListadoPagoResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.pagoService.ObtenerPagos(pagoRequest);
            }
            catch (Exception e)
            {
                logger.LogError($"Error PagoController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.Pagos);
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="pagoModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/pagos/{pagoId}/")]
		public ActionResult GetAll(string pagoId)
		{
			ListadoPagoResult result = new ListadoPagoResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.pagoService.BuscarPagos(pagoId);
			}
            catch (Exception e)
            {
                logger.LogError($"Error PagoController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.Pagos);
		}

        [HttpGet("v1/pagos/edificio/{codigoEdificio}/")]
        public ActionResult GetAllPagosEdificio(string codigoEdificio)
        {
            ListadoPagoResult result = new ListadoPagoResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.pagoService.BuscarPagosEdificio(codigoEdificio);
            }
            catch (Exception e)
            {
                logger.LogError($"Error PagoController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.Pagos);
        }

        [HttpGet("v1/pagos/convenio/{codigoConvenio}/")]
        public ActionResult GetAllPagosConvenio(string codigoConvenio)
        {
            ListadoPagoResult result = new ListadoPagoResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.pagoService.BuscarPagosConvenio(codigoConvenio);
            }
            catch (Exception e)
            {
                logger.LogError($"Error PagoController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.Pagos);
        }


        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="pagoModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/pago/{pagoId}/")]
		public ActionResult Leer(string pagoId )
        {
			PagoResult result = new PagoResult() { StatusCode = StatusCodes.Status204NoContent };
			try
			{
                result = this.pagoService.ObtenerPago(pagoId);
			}
            catch (Exception e)
            {
                logger.LogError($"Error PagoController.Get {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="pagoModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
		[HttpPost("v1/pago")]
        public IActionResult Post(PagoRequest pagoRequest)
		{
			PagoResult result = new PagoResult() { StatusCode = StatusCodes.Status202Accepted };
			try
            {
				result = this.pagoService.CrearPago(pagoRequest);
			}
			catch (Exception e)
            {
                logger.LogError($"Error PagoController.HttpPost {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="pagoModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpPut("v1/pago/{pagoId}/")]
		public IActionResult Put(string pagoId , [FromBody] PagoRequest pagoRequest)
		{
			PagoResult result = new PagoResult() { StatusCode = StatusCodes.Status202Accepted };
			try
			{
				            pagoRequest.PagoId = pagoId;
                                result = this.pagoService.ActualizarPago(pagoRequest);
			}
            catch (Exception e)
            {
                logger.LogError($"Error PagoController.HttpPut {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
		}
		
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="pagoModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpDelete("v1/pago/{pagoId}/")]
		public IActionResult Delete(string pagoId )
        {
			PagoResult result = new PagoResult() { StatusCode = StatusCodes.Status202Accepted };
			try
			{
				result = this.pagoService.EliminarPago(pagoId);
			}
            catch (Exception e)
            {
                logger.LogError($"Error PagoController.HttpDelete {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }
	}
}

