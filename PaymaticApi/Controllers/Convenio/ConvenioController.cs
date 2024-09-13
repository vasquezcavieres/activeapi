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
using Cl.Intertrade.ActivPay.Data.Convenio;
using Cl.Intertrade.ActivPay.Request.Convenio;
using Cl.Intertrade.ActivPay.Result.Convenio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using Newtonsoft.Json;

namespace Cl.Intertrade.ActivPay.Controllers.Convenio
{
    /// <summary>
    /// Esta Clase Convenio  permite gestionar reglas de negocio asociados a la entidad Convenio
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ConvenioController : BaseController<ConvenioController>
    {
        IConvenioService convenioService;
        public ConvenioController(ILogger<ConvenioController> logger, IConvenioService convenioService, IWebHostEnvironment environment, ISettingsConfig settings)
        {
            this.logger = logger;
            this.convenioService = convenioService;
            this.environment = environment;
            this.settings = settings;
        }


        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="convenioModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/convenios/all")]
        public ActionResult GetAll()
        {
            ListadoConvenioResult result = new ListadoConvenioResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.convenioService.ObtenerConvenios();
            }
            catch (Exception e)
            {



                logger.LogError($"Error ConvenioController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.Convenios);
        }








        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="convenioModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/convenios/{rutRazonSocial}/")]
        public ActionResult GetAll(int rutRazonSocial)
        {
            ListadoConvenioResult result = new ListadoConvenioResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.convenioService.BuscarConvenios(rutRazonSocial);
            }
            catch (Exception e)
            {
                logger.LogError($"Error ConvenioController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.Convenios);
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="convenioModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/convenio/{rutRazonSocial}/")]
        public ActionResult Leer(int rutRazonSocial)
        {
            ConvenioResult result = new ConvenioResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.convenioService.ObtenerConvenio(rutRazonSocial);
            }
            catch (Exception e)
            {
                logger.LogError($"Error ConvenioController.Get {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("v1/convenio/edificio/{codigoEdificio}/")]
        public ActionResult LeerPorEdificio(string codigoEdificio)
        {
            ConvenioResult result = new ConvenioResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.convenioService.ObtenerConvenioPorEdificio(codigoEdificio);
            }
            catch (Exception e)
            {
                logger.LogError($"Error ConvenioController.Get {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("v1/convenio/administrador/{rutAdministrador}/")]
        public ActionResult LeerPorAdministrador(string rutAdministrador)
        {
            ConvenioResult result = new ConvenioResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.convenioService.ObtenerConvenioPorAdministrador(rutAdministrador);
            }
            catch (Exception e)
            {
                logger.LogError($"Error ConvenioController.Get {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }


        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="convenioModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpPost("v1/convenio")]
        public IActionResult Post(ConvenioRequest convenioRequest)
        {
            ConvenioResult result = new ConvenioResult() { StatusCode = StatusCodes.Status202Accepted };
            try
            {
                result = this.convenioService.CrearConvenio(convenioRequest);
            }
            catch (Exception e)
            {
                logger.LogError($"Error ConvenioController.HttpPost {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="convenioModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpPut("v1/convenio/{rutRazonSocial}/")]
        public IActionResult Put(int rutRazonSocial, IFormCollection data)
        {
            ConvenioResult result = new ConvenioResult() { StatusCode = StatusCodes.Status202Accepted };
            try
            {
                var convenioRequest = JsonConvert.DeserializeObject<ConvenioRequest>(data["convenio"]);
                convenioRequest.RutRazonSocial = rutRazonSocial;
                result = this.convenioService.ActualizarConvenio(convenioRequest);
            }
            catch (Exception e)
            {
                logger.LogError($"Error ConvenioController.HttpPut {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }


        [HttpPut("v1/asociarUsuarioAdministrador/{rutRazonSocial}/{rutAdministradorConvenio}/")]
        public IActionResult asociarUsuarioAdministrador(int rutRazonSocial, int rutAdministradorConvenio, IFormCollection data)
        {
            ConvenioResult result = new ConvenioResult() { StatusCode = StatusCodes.Status202Accepted };
            try
            {
                //var convenioRequest = JsonConvert.DeserializeObject<ConvenioRequest>(data["convenio"]);
                ConvenioRequest convenioRequest = new ConvenioRequest();
                convenioRequest.RutRazonSocial = rutRazonSocial;
                convenioRequest.RutAdministrador = rutAdministradorConvenio;
                result = this.convenioService.AsociarUsuarioAdministradaor(convenioRequest);
            }
            catch (Exception e)
            {
                logger.LogError($"Error ConvenioController.HttpPut {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="convenioModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpDelete("v1/convenio/{rutRazonSocial}/")]
        public IActionResult Delete(int rutRazonSocial)
        {
            ConvenioResult result = new ConvenioResult() { StatusCode = StatusCodes.Status202Accepted };
            try
            {
                result = this.convenioService.EliminarConvenio(rutRazonSocial);
            }
            catch (Exception e)
            {
                logger.LogError($"Error ConvenioController.HttpDelete {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }
    }
}

