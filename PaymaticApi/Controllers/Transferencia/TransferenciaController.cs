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
using Cl.Intertrade.ActivPay.Data.Transferencia;
using Cl.Intertrade.ActivPay.Request.Transferencia;
using Cl.Intertrade.ActivPay.Result.Transferencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;

namespace Cl.Intertrade.ActivPay.Controllers.Transferencia
{
	/// <summary>
	/// Esta Clase Transferencia  permite gestionar reglas de negocio asociados a la entidad Transferencia
	/// </summary>
    [Route("api/[controller]")]
    [ApiController]
	public class TransferenciaController : BaseController<TransferenciaController>
	{	
        ITransferenciaService transferenciaService;
        public TransferenciaController(ILogger<TransferenciaController> logger, ITransferenciaService transferenciaService, IWebHostEnvironment environment, ISettingsConfig settings)
		{
			this.logger = logger;
			this.transferenciaService = transferenciaService;
			this.environment = environment;
			this.settings = settings;
		}

        
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="transferenciaModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/transferencias/all")]
		public ActionResult GetAll()
		{
			ListadoTransferenciaResult result = new ListadoTransferenciaResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.transferenciaService.ObtenerTransferencias();
			}
            catch (Exception e)
            {
                logger.LogError($"Error TransferenciaController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.Transferencias);
		}

        [HttpPost("v1/transferencias/all")]
        public ActionResult GetAll(TransferenciaRequest transferenciaRequest)
        {
            ListadoTransferenciaResult result = new ListadoTransferenciaResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.transferenciaService.ObtenerTransferencias(transferenciaRequest);
            }
            catch (Exception e)
            {
                logger.LogError($"Error TransferenciaController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.Transferencias);
        }


        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="transferenciaModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/transferencias/{transferenciaId}/")]
		public ActionResult GetAll(int transferenciaId )
		{
			ListadoTransferenciaResult result = new ListadoTransferenciaResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.transferenciaService.BuscarTransferencias(transferenciaId);
			}
            catch (Exception e)
            {
                logger.LogError($"Error TransferenciaController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.Transferencias);
		}

        [HttpGet("v1/transferencias/convenio/{codigoConvenio}/")]
        public ActionResult GetAllByConvenio(int codigoConvenio)
        {
            ListadoTransferenciaResult result = new ListadoTransferenciaResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.transferenciaService.BuscarTransferenciasPorConvenio(codigoConvenio);
            }
            catch (Exception e)
            {
                logger.LogError($"Error TransferenciaController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.Transferencias);
        }

        [HttpGet("v1/transferencias/edificio/{codigoEdificio}/")]
        public ActionResult GetAllByEdificio(string codigoEdificio)
        {
            ListadoTransferenciaResult result = new ListadoTransferenciaResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.transferenciaService.BuscarTransferenciasPorEdificio(codigoEdificio);
            }
            catch (Exception e)
            {
                logger.LogError($"Error TransferenciaController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.Transferencias);
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="transferenciaModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/transferencia/{transferenciaId}/")]
		public ActionResult Leer(int transferenciaId )
        {
			TransferenciaResult result = new TransferenciaResult() { StatusCode = StatusCodes.Status204NoContent };
			try
			{
                result = this.transferenciaService.ObtenerTransferencia(transferenciaId);
			}
            catch (Exception e)
            {
                logger.LogError($"Error TransferenciaController.Get {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="transferenciaModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
		[HttpPost("v1/transferencia")]
        public IActionResult Post(TransferenciaRequest transferenciaRequest)
		{
			TransferenciaResult result = new TransferenciaResult() { StatusCode = StatusCodes.Status202Accepted };
			try
            {
				result = this.transferenciaService.CrearTransferencia(transferenciaRequest);
			}
			catch (Exception e)
            {
                logger.LogError($"Error TransferenciaController.HttpPost {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("v1/transferencia/{transferenciaId}/")]
		public IActionResult Put(int transferenciaId , [FromBody] TransferenciaRequest transferenciaRequest)
		{
			TransferenciaResult result = new TransferenciaResult() { StatusCode = StatusCodes.Status202Accepted };
			try
			{
				            transferenciaRequest.TransferenciaId = transferenciaId;
                                result = this.transferenciaService.ActualizarTransferencia(transferenciaRequest);
			}
            catch (Exception e)
            {
                logger.LogError($"Error TransferenciaController.HttpPut {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
		}
		
        [HttpDelete("v1/transferencia/{transferenciaId}/")]
		public IActionResult Delete(int transferenciaId )
        {
			TransferenciaResult result = new TransferenciaResult() { StatusCode = StatusCodes.Status202Accepted };
			try
			{
				result = this.transferenciaService.EliminarTransferencia(transferenciaId);
			}
            catch (Exception e)
            {
                logger.LogError($"Error TransferenciaController.HttpDelete {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("v1/transferencia/aprobar/")]
        public IActionResult PostAprobar(TransferenciaRequest transferenciaRequest)
        {
            TransferenciaResult result = new TransferenciaResult() { StatusCode = StatusCodes.Status202Accepted };
            try
            {
                result = this.transferenciaService.AprobarTransferencia(transferenciaRequest.TransferenciaId);
            }
            catch (Exception e)
            {
                logger.LogError($"Error TransferenciaController.HttpPut {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("v1/transferencia/procesoTransferencia")]
        public async Task<IActionResult> ProcesoTransferencia(TransferenciaRequest transferenciaRequest)
        {
            TransferenciaResult result = new TransferenciaResult() { StatusCode = StatusCodes.Status202Accepted };
            try
            {
                result = await this.transferenciaService.ProcesoTransferencia();
            }
            catch (Exception e)
            {
                logger.LogError($"Error TransferenciaController.HttpPut {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }
    }
}

