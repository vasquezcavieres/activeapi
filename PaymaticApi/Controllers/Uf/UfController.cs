





/**
* (c)2013-2023 CodeBase Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*13-12-2023,Generador de Código, Clase Inicial 
*/

using Cl.Intertrade.ActivPay.Controllers.Base;
using Cl.Intertrade.ActivPay.Helpers.Base;
using Cl.Intertrade.ActivPay.Data.Uf;
using Cl.Intertrade.ActivPay.Request.Uf;
using Cl.Intertrade.ActivPay.Result.Uf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;

namespace Cl.Intertrade.ActivPay.Controllers.Uf
{
	/// <summary>
	/// Esta Clase Uf  permite gestionar reglas de negocio asociados a la entidad Uf
	/// </summary>
    [Route("api/[controller]")]
    [ApiController]
	public class UfController : BaseController<UfController>
	{	
        IUfService ufService;
        public UfController(ILogger<UfController> logger, IUfService ufService, IWebHostEnvironment environment, ISettingsConfig settings)
		{
			this.logger = logger;
			this.ufService = ufService;
			this.environment = environment;
			this.settings = settings;
		}

        
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="ufModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/ufs/all")]
		public ActionResult GetAll()
		{
			ListadoUfResult result = new ListadoUfResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.ufService.ObtenerUfs();
			}
            catch (Exception e)
            {
                logger.LogError($"Error UfController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.Ufs);
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="ufModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
		[HttpGet("v1/ufs/{fechaUf}/")]
		public ActionResult GetAll(DateTime fechaUf )
		{
			ListadoUfResult result = new ListadoUfResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.ufService.BuscarUfs(fechaUf);
			}
            catch (Exception e)
            {
                logger.LogError($"Error UfController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.Ufs);
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="ufModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/uf/{fechaUf}/")]
		public ActionResult Leer(DateTime fechaUf )
        {
			UfResult result = new UfResult() { StatusCode = StatusCodes.Status204NoContent };
			try
			{
                result = this.ufService.ObtenerUf(fechaUf);
			}
            catch (Exception e)
            {
                logger.LogError($"Error UfController.Get {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="ufModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
		[HttpPost("v1/uf")]
        public IActionResult Post(UfRequest ufRequest)
		{
			UfResult result = new UfResult() { StatusCode = StatusCodes.Status202Accepted };
			try
            {
				result = this.ufService.CrearUf(ufRequest);
			}
			catch (Exception e)
            {
                logger.LogError($"Error UfController.HttpPost {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="ufModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpPut("v1/uf/{fechaUf}/")]
		public IActionResult Put(DateTime fechaUf , [FromBody] UfRequest ufRequest)
		{
			UfResult result = new UfResult() { StatusCode = StatusCodes.Status202Accepted };
			try
			{
				            ufRequest.FechaUf = fechaUf;
                                result = this.ufService.ActualizarUf(ufRequest);
			}
            catch (Exception e)
            {
                logger.LogError($"Error UfController.HttpPut {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
		}
		
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="ufModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpDelete("v1/uf/{fechaUf}/")]
		public IActionResult Delete(DateTime fechaUf )
        {
			UfResult result = new UfResult() { StatusCode = StatusCodes.Status202Accepted };
			try
			{
				result = this.ufService.EliminarUf(fechaUf);
			}
            catch (Exception e)
            {
                logger.LogError($"Error UfController.HttpDelete {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }
	}
}

