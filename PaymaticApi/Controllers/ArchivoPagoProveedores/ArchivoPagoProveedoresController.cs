





/**
* (c)2013-2023 CodeBase Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*14-11-2023,Generador de Código, Clase Inicial 
*/

using Cl.Intertrade.ActivPayApi.Data.ArchivoPagoProveedores;
using Cl.Intertrade.ActivPayApi.Request.ArchivoPagoProveedores;
using Cl.Intertrade.ActivPayApi.Result.ArchivoPagoProveedores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using Cl.Intertrade.ActivPay.Controllers.Base;
using Microsoft.AspNetCore.StaticFiles;
using static Dapper.SqlMapper;

namespace Cl.Intertrade.ActivPayApi.Controllers.ArchivoPagoProveedores
{
	/// <summary>
	/// Esta Clase ArchivoPagoProveedores  permite gestionar reglas de negocio asociados a la entidad ArchivoPagoProveedores
	/// </summary>
    [Route("api/[controller]")]
    [ApiController]
	public class ArchivoPagoProveedoresController : BaseController<ArchivoPagoProveedoresController>
	{	
        IArchivoPagoProveedoresService archivoPagoProveedoresService;
        public ArchivoPagoProveedoresController(ILogger<ArchivoPagoProveedoresController> logger, IArchivoPagoProveedoresService archivoPagoProveedoresService, IWebHostEnvironment environment)
		{
			this.logger = logger;
			this.archivoPagoProveedoresService = archivoPagoProveedoresService;
			this.environment = environment;
			this.settings = settings;
		}

        
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="archivoPagoProveedoresModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/archivoPagoProveedores/all")]
		public ActionResult GetAll()
		{
			ListadoArchivoPagoProveedoresResult result = new ListadoArchivoPagoProveedoresResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.archivoPagoProveedoresService.ObtenerArchivoPagoProveedoress();
			}
            catch (Exception e)
            {
                logger.LogError($"Error ArchivoPagoProveedoresController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.ArchivoPagoProveedoress);
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="archivoPagoProveedoresModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/archivoPagoProveedores/")]
		public ActionResult Leer()
        {
			ArchivoPagoProveedoresResult result = new ArchivoPagoProveedoresResult() { StatusCode = StatusCodes.Status204NoContent };
			try
			{
                result = this.archivoPagoProveedoresService.ObtenerArchivoPagoProveedores(1);
			}
            catch (Exception e)
            {
                logger.LogError($"Error ArchivoPagoProveedoresController.Get {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="archivoPagoProveedoresModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
		[HttpPost("v1/archivoPagoProveedores")]
        public IActionResult Post(ArchivoPagoProveedoresRequest archivoPagoProveedoresRequest)
		{
			ArchivoPagoProveedoresResult result = new ArchivoPagoProveedoresResult() { StatusCode = StatusCodes.Status202Accepted };
			try
            {
				result = this.archivoPagoProveedoresService.CrearArchivoPagoProveedores(archivoPagoProveedoresRequest);
			}
			catch (Exception e)
            {
                logger.LogError($"Error ArchivoPagoProveedoresController.HttpPost {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

		
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="archivoPagoProveedoresModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpDelete("v1/archivoPagoProveedores/")]
		public IActionResult Delete()
        {
			ArchivoPagoProveedoresResult result = new ArchivoPagoProveedoresResult() { StatusCode = StatusCodes.Status202Accepted };
			try
			{
				result = this.archivoPagoProveedoresService.EliminarArchivoPagoProveedores();
			}
            catch (Exception e)
            {
                logger.LogError($"Error ArchivoPagoProveedoresController.HttpDelete {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("v1/GetFile/{id}")]
        public List<string> GetFile(int id)
        {

            var file = this.archivoPagoProveedoresService.ObtenerArchivoPagoProveedores(id);

            List<String> listaArchivos = new List<String>();

            byte[] archivo = null;

            //var fieltupe = GetMimeType(file.NombreArchivo);
            //GetMimeType
            if (System.IO.File.Exists(file.RutaArchivo))
            {
                using (FileStream fs = new FileStream(file.RutaArchivo, FileMode.Open, FileAccess.Read))
                {
                    // Create a byte array of file stream length
                    byte[] bytes = System.IO.File.ReadAllBytes(file.RutaArchivo);
                    //Read block of bytes from stream into the byte array
                    fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));
                    //Close the File Stream
                    fs.Close();
                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    listaArchivos.Add(file.NombreArchivo);
                    listaArchivos.Add(base64String);
                    //return bytes; //return the byte data
                }
            }

            return listaArchivos;
        }

        //public string GetMimeType(string fileName)
        //{
        //    var provider = new FileExtensionContentTypeProvider();
        //    string contentType;
        //    if (!provider.TryGetContentType(fileName, out contentType))
        //    {
        //        contentType = "application/octet-stream";
        //    }

        //    return contentType;
        //}

    }
}

