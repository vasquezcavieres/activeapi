





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
using Cl.Intertrade.ActivPay.Data.Banco;
using Cl.Intertrade.ActivPay.Request.Banco;
using Cl.Intertrade.ActivPay.Result.Banco;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;

namespace Cl.Intertrade.ActivPay.Controllers.Banco
{
	/// <summary>
	/// Esta Clase Banco  permite gestionar reglas de negocio asociados a la entidad Banco
	/// </summary>
    [Route("api/[controller]")]
    [ApiController]
	public class BancoController : BaseController<BancoController>
	{	
        IBancoService bancoService;
        public BancoController(ILogger<BancoController> logger, IBancoService bancoService, IWebHostEnvironment environment, ISettingsConfig settings)
		{
			this.logger = logger;
			this.bancoService = bancoService;
			this.environment = environment;
			this.settings = settings;
		}

        
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="bancoModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/bancos/all")]
		public ActionResult GetAll()
		{
			ListadoBancoResult result = new ListadoBancoResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.bancoService.ObtenerBancos();
			}
            catch (Exception e)
            {
                logger.LogError($"Error BancoController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.Bancos);
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="bancoModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/banco/")]
		public ActionResult Leer()
        {
			BancoResult result = new BancoResult() { StatusCode = StatusCodes.Status204NoContent };
			try
			{
                result = this.bancoService.ObtenerBanco();
			}
            catch (Exception e)
            {
                logger.LogError($"Error BancoController.Get {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="bancoModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
		[HttpPost("v1/banco")]
        public IActionResult Post(BancoRequest bancoRequest)
		{
			BancoResult result = new BancoResult() { StatusCode = StatusCodes.Status202Accepted };
			try
            {
				result = this.bancoService.CrearBanco(bancoRequest);
			}
			catch (Exception e)
            {
                logger.LogError($"Error BancoController.HttpPost {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }
		
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="bancoModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpDelete("v1/banco/")]
		public IActionResult Delete()
        {
			BancoResult result = new BancoResult() { StatusCode = StatusCodes.Status202Accepted };
			try
			{
				result = this.bancoService.EliminarBanco();
			}
            catch (Exception e)
            {
                logger.LogError($"Error BancoController.HttpDelete {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }
	}
}

