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
using Cl.Intertrade.ActivPay.Data.Edificio;
using Cl.Intertrade.ActivPay.Request.Edificio;
using Cl.Intertrade.ActivPay.Result.Edificio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using Newtonsoft.Json;
using Cl.Intertrade.ActivPay.Request.Convenio;
using Cl.Intertrade.ActivPay.Result.Convenio;

namespace Cl.Intertrade.ActivPay.Controllers.Edificio
{
    /// <summary>
    /// Esta Clase Edificio  permite gestionar reglas de negocio asociados a la entidad Edificio
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EdificioController : BaseController<EdificioController>
    {
        IEdificioService edificioService;
        public EdificioController(ILogger<EdificioController> logger, IEdificioService edificioService, IWebHostEnvironment environment, ISettingsConfig settings)
        {
            this.logger = logger;
            this.edificioService = edificioService;
            this.environment = environment;
            this.settings = settings;
        }


        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="edificioModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/edificios/all")]
        public ActionResult GetAll()
        {
            ListadoEdificioResult result = new ListadoEdificioResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.edificioService.ObtenerEdificios();
            }
            catch (Exception e)
            {
                logger.LogError($"Error EdificioController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.Edificios);
        }

        [HttpGet("v1/edificiosAsociados/all")]
        public ActionResult GetAllAsociados()
        {
            ListadoEdificioResult result = new ListadoEdificioResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.edificioService.ObtenerEdificiosAsociados();
            }
            catch (Exception e)
            {
                logger.LogError($"Error EdificioController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.Edificios);
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="edificioModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/edificios/{codigoEdificio}/")]
        public ActionResult GetAll(string codigoEdificio)
        {
            ListadoEdificioResult result = new ListadoEdificioResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.edificioService.BuscarEdificios(codigoEdificio);
            }
            catch (Exception e)
            {
                logger.LogError($"Error EdificioController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.Edificios);
        }

        [HttpGet("v1/edificiosConvenio/{rutRazonSocial}/")]
        public ActionResult GetAllEdificiosConvenio(int rutRazonSocial)
        {
            ListadoEdificioResult result = new ListadoEdificioResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.edificioService.BuscarEdificiosConvenio(rutRazonSocial);
            }
            catch (Exception e)
            {
                logger.LogError($"Error EdificioController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.Edificios);
        }

        [HttpPost("v1/edificiosConvenio")]
        public ActionResult PostAllEdificiosConvenio(EdificioRequest edificioRequest)
        {
            ListadoEdificioResult result = new ListadoEdificioResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.edificioService.BuscarEdificiosConvenio(edificioRequest);
            }
            catch (Exception e)
            {
                logger.LogError($"Error EdificioController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.Edificios);
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="edificioModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/edificio/{codigoEdificio}/")]
        public ActionResult Leer(string codigoEdificio)
        {
            EdificioResult result = new EdificioResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.edificioService.ObtenerEdificio(codigoEdificio);
            }
            catch (Exception e)
            {
                logger.LogError($"Error EdificioController.Get {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("v1/edificioComunidad/{rutComunidad}/")]
        public ActionResult LeerEdificioComunidad(string rutComunidad)
        {
            EdificioResult result = new EdificioResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.edificioService.ObtenerEdificioComunidad(Convert.ToInt32(rutComunidad));
            }
            catch (Exception e)
            {
                logger.LogError($"Error EdificioController.Get {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="edificioModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpPost("v1/edificio")]
        public IActionResult Post(EdificioRequest edificioRequest)
        {
            EdificioResult result = new EdificioResult() { StatusCode = StatusCodes.Status202Accepted };
            try
            {
                result = this.edificioService.CrearEdificio(edificioRequest);
            }
            catch (Exception e)
            {
                logger.LogError($"Error EdificioController.HttpPost {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="edificioModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpPut("v1/edificio/{codigoEdificio}/")]
        public IActionResult Put(string codigoEdificio, [FromBody] EdificioRequest edificioRequest)
        {
            EdificioResult result = new EdificioResult() { StatusCode = StatusCodes.Status202Accepted };
            try
            {
                edificioRequest.CodigoEdificio = codigoEdificio;
                result = this.edificioService.ActualizarEdificio(edificioRequest);
            }
            catch (Exception e)
            {
                logger.LogError($"Error EdificioController.HttpPut {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }


        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="edificioModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpDelete("v1/edificio/{codigoEdificio}/")]
        public IActionResult Delete(string codigoEdificio)
        {
            EdificioResult result = new EdificioResult() { StatusCode = StatusCodes.Status202Accepted };
            try
            {
                result = this.edificioService.EliminarEdificio(codigoEdificio);
            }
            catch (Exception e)
            {
                logger.LogError($"Error EdificioController.HttpDelete {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }


        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="edificioModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpPut("v1/asociarEdificios/{rutRazonSocial}")]
        public IActionResult AsociarEdificios(int rutRazonSocial, IFormCollection data)
        {
            EdificioResult result = new EdificioResult() { StatusCode = StatusCodes.Status202Accepted };
            var edificiosRequest = JsonConvert.DeserializeObject<List<EdificioRequest>>(data["edificios"]); 
            
            try
            {
                result = this.edificioService.AsociarEdificios(rutRazonSocial,edificiosRequest);
            }
            catch (Exception e)
            {
                logger.LogError($"Error EdificioController.HttpPost {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

    }
}

