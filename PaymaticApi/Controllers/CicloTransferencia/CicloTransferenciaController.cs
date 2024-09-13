





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
using Cl.Intertrade.ActivPay.Data.CicloTransferencia;
using Cl.Intertrade.ActivPay.Request.CicloTransferencia;
using Cl.Intertrade.ActivPay.Result.CicloTransferencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using Newtonsoft.Json;

namespace Cl.Intertrade.ActivPay.Controllers.CicloTransferencia
{
    /// <summary>
    /// Esta Clase CicloTransferencia  permite gestionar reglas de negocio asociados a la entidad CicloTransferencia
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CicloTransferenciaController : BaseController<CicloTransferenciaController>
    {
        ICicloTransferenciaService CicloTransferenciaService;
        public CicloTransferenciaController(ILogger<CicloTransferenciaController> logger, ICicloTransferenciaService CicloTransferenciaService, IWebHostEnvironment environment, ISettingsConfig settings)
        {
            this.logger = logger;
            this.CicloTransferenciaService = CicloTransferenciaService;
            this.environment = environment;
            this.settings = settings;
        }


        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="CicloTransferenciaModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/CicloTransferencias/all")]
        public ActionResult GetAll()
        {
            ListadoCicloTransferenciaResult result = new ListadoCicloTransferenciaResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.CicloTransferenciaService.ObtenerCicloTransferencias();
            }
            catch (Exception e)
            {
                logger.LogError($"Error CicloTransferenciaController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.CicloTransferencias);
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="CicloTransferenciaModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/CicloTransferencias/{creadoPor}/")]
        public ActionResult GetAll(string creadoPor)
        {
            ListadoCicloTransferenciaResult result = new ListadoCicloTransferenciaResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.CicloTransferenciaService.BuscarCicloTransferencias(creadoPor);
            }
            catch (Exception e)
            {
                logger.LogError($"Error CicloTransferenciaController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.CicloTransferencias);
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="CicloTransferenciaModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/cicloTransferencia/{codigoConvenio}/")]
        public ActionResult Leer(string codigoConvenio)
        {
            CicloTransferenciaResult result = new CicloTransferenciaResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.CicloTransferenciaService.ObtenerCicloTransferencia(codigoConvenio);
            }
            catch (Exception e)
            {
                logger.LogError($"Error CicloTransferenciaController.Get {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="CicloTransferenciaModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpPost("v1/CicloTransferencia")]
        public IActionResult Post(CicloTransferenciaRequest CicloTransferenciaRequest)
        {
            CicloTransferenciaResult result = new CicloTransferenciaResult() { StatusCode = StatusCodes.Status202Accepted };
            try
            {
                result = this.CicloTransferenciaService.CrearCicloTransferencia(CicloTransferenciaRequest);
            }
            catch (Exception e)
            {
                logger.LogError($"Error CicloTransferenciaController.HttpPost {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="CicloTransferenciaModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpPut("v1/CicloTransferencia/{rutRazonSocial}")]
        public IActionResult Put(int rutRazonSocial, IFormCollection data  )
        {
            CicloTransferenciaResult result = new CicloTransferenciaResult() { StatusCode = StatusCodes.Status202Accepted };
            try
            {
                var cicloTransferenciaRequest = JsonConvert.DeserializeObject<CicloTransferenciaRequest>(data["cicloTransferencia"]);
                cicloTransferenciaRequest.CodigoConvenio = rutRazonSocial;
                result = this.CicloTransferenciaService.ActualizarCicloTransferencia(cicloTransferenciaRequest);
            }
            catch (Exception e)
            {
                logger.LogError($"Error CicloTransferenciaController.HttpPut {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="CicloTransferenciaModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpDelete("v1/CicloTransferencia/{creadoPor}/")]
        public IActionResult Delete(string creadoPor)
        {
            CicloTransferenciaResult result = new CicloTransferenciaResult() { StatusCode = StatusCodes.Status202Accepted };
            try
            {
                result = this.CicloTransferenciaService.EliminarCicloTransferencia(creadoPor);
            }
            catch (Exception e)
            {
                logger.LogError($"Error CicloTransferenciaController.HttpDelete {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }
    }
}

