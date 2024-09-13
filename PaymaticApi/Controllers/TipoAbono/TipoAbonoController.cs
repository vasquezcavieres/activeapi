/**
* (c)2013-2023 CodeBase Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*11-12-2023,Generador de Código, Clase Inicial 
*/

using Cl.Intertrade.ActivPay.Controllers.Base;
using Cl.Intertrade.ActivPay.Helpers.Base;
using Cl.Intertrade.ActivPay.Data.TipoAbono;
using Cl.Intertrade.ActivPay.Request.TipoAbono;
using Cl.Intertrade.ActivPay.Result.TipoAbono;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;

namespace Cl.Intertrade.ActivPay.Controllers.TipoAbono
{
	/// <summary>
	/// Esta Clase TipoAbono  permite gestionar reglas de negocio asociados a la entidad TipoAbono
	/// </summary>
    [Route("api/[controller]")]
    [ApiController]
	public class TipoAbonoController : BaseController<TipoAbonoController>
	{	
        ITipoAbonoService tipoAbonoService;
        public TipoAbonoController(ILogger<TipoAbonoController> logger, ITipoAbonoService tipoAbonoService, IWebHostEnvironment environment, ISettingsConfig settings)
		{
			this.logger = logger;
			this.tipoAbonoService = tipoAbonoService;
			this.environment = environment;
			this.settings = settings;
		}

        
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="tipoAbonoModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/tipoAbonos/all")]
		public ActionResult GetAll()
		{
			ListadoTipoAbonoResult result = new ListadoTipoAbonoResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.tipoAbonoService.ObtenerTipoAbonos();
			}
            catch (Exception e)
            {
                logger.LogError($"Error TipoAbonoController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.TipoAbonos);
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="tipoAbonoModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/tipoAbono/")]
		public ActionResult Leer()
        {
			TipoAbonoResult result = new TipoAbonoResult() { StatusCode = StatusCodes.Status204NoContent };
			try
			{
                result = this.tipoAbonoService.ObtenerTipoAbono();
			}
            catch (Exception e)
            {
                logger.LogError($"Error TipoAbonoController.Get {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="tipoAbonoModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
		[HttpPost("v1/tipoAbono")]
        public IActionResult Post(TipoAbonoRequest tipoAbonoRequest)
		{
			TipoAbonoResult result = new TipoAbonoResult() { StatusCode = StatusCodes.Status202Accepted };
			try
            {
				result = this.tipoAbonoService.CrearTipoAbono(tipoAbonoRequest);
			}
			catch (Exception e)
            {
                logger.LogError($"Error TipoAbonoController.HttpPost {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

		
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="tipoAbonoModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpDelete("v1/tipoAbono/")]
		public IActionResult Delete()
        {
			TipoAbonoResult result = new TipoAbonoResult() { StatusCode = StatusCodes.Status202Accepted };
			try
			{
				result = this.tipoAbonoService.EliminarTipoAbono();
			}
            catch (Exception e)
            {
                logger.LogError($"Error TipoAbonoController.HttpDelete {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }
	}
}

