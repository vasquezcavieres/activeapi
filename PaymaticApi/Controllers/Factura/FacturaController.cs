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
using Cl.Intertrade.ActivPay.Data.Factura;
using Cl.Intertrade.ActivPay.Request.Factura;
using Cl.Intertrade.ActivPay.Result.Factura;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using ActivPayApi.Models.Result.Factura;

namespace Cl.Intertrade.ActivPay.Controllers.Factura
{
	/// <summary>
	/// Esta Clase Factura  permite gestionar reglas de negocio asociados a la entidad Factura
	/// </summary>
    [Route("api/[controller]")]
    [ApiController]
	public class FacturaController : BaseController<FacturaController>
	{	
        IFacturaService facturaService;
        public FacturaController(ILogger<FacturaController> logger, IFacturaService facturaService, IWebHostEnvironment environment, ISettingsConfig settings)
		{
			this.logger = logger;
			this.facturaService = facturaService;
			this.environment = environment;
			this.settings = settings;
		}

        
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="facturaModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/facturas/all")]
		public ActionResult GetAll()
		{
			ListadoFacturaResult result = new ListadoFacturaResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.facturaService.ObtenerFacturas();
			}
            catch (Exception e)
            {
                logger.LogError($"Error FacturaController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.Facturas);
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="facturaModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
		[HttpPost("v1/facturas/")]
		public ActionResult GetAll(FacturaRequest pedidoBuscarRequest)
		{
            ListadoFacturaResult result = new ListadoFacturaResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.facturaService.BuscarFacturas(pedidoBuscarRequest);
			}
            catch (Exception e)
            {
                logger.LogError($"Error FacturaController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.Facturas);
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="facturaModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/factura/{numeroFactura}/")]
		public ActionResult Leer(int numeroFactura )
        {
			FacturaResult result = new FacturaResult() { StatusCode = StatusCodes.Status204NoContent };
			try
			{
                result = this.facturaService.ObtenerFactura(numeroFactura);
			}
            catch (Exception e)
            {
                logger.LogError($"Error FacturaController.Get {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="facturaModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
		[HttpPost("v1/factura")]
        public IActionResult Post(FacturaRequest facturaRequest)
		{
			FacturaResult result = new FacturaResult() { StatusCode = StatusCodes.Status202Accepted };
			try
            {
				result = this.facturaService.CrearFactura(facturaRequest);
			}
			catch (Exception e)
            {
                logger.LogError($"Error FacturaController.HttpPost {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="facturaModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpPut("v1/factura/{numeroFactura}/")]
		public IActionResult Put(int numeroFactura , [FromBody] FacturaRequest facturaRequest)
		{
			FacturaResult result = new FacturaResult() { StatusCode = StatusCodes.Status202Accepted };
			try
			{
				            facturaRequest.NumeroFactura = numeroFactura;
                                result = this.facturaService.ActualizarFactura(facturaRequest);
			}
            catch (Exception e)
            {
                logger.LogError($"Error FacturaController.HttpPut {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
		}
		
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="facturaModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpDelete("v1/factura/{numeroFactura}/")]
		public IActionResult Delete(int numeroFactura )
        {
			FacturaResult result = new FacturaResult() { StatusCode = StatusCodes.Status202Accepted };
			try
			{
				result = this.facturaService.EliminarFactura(numeroFactura);
			}
            catch (Exception e)
            {
                logger.LogError($"Error FacturaController.HttpDelete {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

        //[HttpPost("v1/factura/anular")]
        //public IActionResult PostAnulaFactura(FacturaRequest facturaRequest)
        //{
        //    FacturaResult result = new FacturaResult() { StatusCode = StatusCodes.Status202Accepted };
        //    try
        //    {
        //        result = this.facturaService.AnularFactura(facturaRequest);
        //    }
        //    catch (Exception e)
        //    {
        //        logger.LogError($"Error FacturaController.HttpPost {e.StackTrace}");
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }
        //    return StatusCode(result.StatusCode, result);
        //}

        //[HttpPost("v1/factura/obtenerNotaCredito")]
        //public async Task<IActionResult> PostObtieneNotaCredito(FacturaRequest facturaRequest)
        //{
        //    FacturaResult result = new FacturaResult() { StatusCode = StatusCodes.Status202Accepted };
        //    try
        //    {
        //        result = await this.facturaService.ObtenerNotaCredito(facturaRequest);
        //    }
        //    catch (Exception e)
        //    {
        //        logger.LogError($"Error FacturaController.HttpPost {e.StackTrace}");
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }
        //    return StatusCode(result.StatusCode, result);
        //}
    }
}

