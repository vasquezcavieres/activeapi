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
using Cl.Intertrade.ActivPay.Data.Usuario;
using Cl.Intertrade.ActivPay.Request.Usuario;
using Cl.Intertrade.ActivPay.Result.Usuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using Newtonsoft.Json.Linq;
using ActivPayApi.Helpers.Validators;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using Cl.Intertrade.ActivPayApi.Models.Result.Usuario;
using AutoMapper;
using Cl.Intertrade.ActivPay.Entities.Acceso;
using Microsoft.AspNetCore.Authorization;
using ActivPayApi.Models.Result.Usuario;
using ActivPayApi.Models.Request.Usuario;
using Newtonsoft.Json;

namespace Cl.Intertrade.ActivPay.Controllers.Usuario
{
    /// <summary>
    /// Esta Clase Usuario  permite gestionar reglas de negocio asociados a la entidad Usuario
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : BaseController<UsuarioController>
    {
        IUsuarioService usuarioService;
        IMapper mapper;
        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioService usuarioService, IWebHostEnvironment environment, ISettingsConfig settings, IMapper mapper)
        {
            this.logger = logger;
            this.usuarioService = usuarioService;
            this.environment = environment;
            this.settings = settings;
            this.mapper = mapper;
        }


        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="usuarioModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/usuarios/all")]
        public ActionResult GetAll()
        {
            ListadoUsuarioResult result = new ListadoUsuarioResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.usuarioService.ObtenerUsuarios();
            }
            catch (Exception e)
            {
                logger.LogError($"Error UsuarioController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.Usuarios);
        }


        [HttpGet("v1/usuarios/comunidad/all")]
        public ActionResult GetAllUsuarioComunidad()
        {
            ListadoUsuarioResult result = new ListadoUsuarioResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.usuarioService.ObtenerUsuariosComunidad();
            }
            catch (Exception e)
            {
                logger.LogError($"Error UsuarioController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.Usuarios);
        }



        [HttpGet("v1/usuarios/administradorConvenio/all")]
        public ActionResult GetAllUsuarioAdministradorConvenio()
        {
            ListadoUsuarioResult result = new ListadoUsuarioResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.usuarioService.ObtenerUsuariosAdministradorConvenio();
            }
            catch (Exception e)
            {
                logger.LogError($"Error UsuarioController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.Usuarios);
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="usuarioModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/usuarios/{tokenUsuario}/")]
        public ActionResult GetAll(string tokenUsuario)
        {
            ListadoUsuarioResult result = new ListadoUsuarioResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.usuarioService.BuscarUsuarios(tokenUsuario);
            }
            catch (Exception e)
            {
                logger.LogError($"Error UsuarioController.GetAll {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result.Usuarios);
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="usuarioModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpGet("v1/usuario/{tokenUsuario}/")]
        public ActionResult Leer(string tokenUsuario)
        {
            UsuarioResult result = new UsuarioResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.usuarioService.ObtenerUsuario(tokenUsuario);
            }
            catch (Exception e)
            {
                logger.LogError($"Error UsuarioController.Get {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="usuarioModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpPost("v1/usuario")]
        public async Task<IActionResult> Post(UsuarioRequest usuarioRequest)
        {
            UsuarioResult result = new UsuarioResult() { StatusCode = StatusCodes.Status202Accepted };
            try
            {
                result = await this.usuarioService.CrearUsuario(usuarioRequest);
            }
            catch (Exception e)
            {
                logger.LogError($"Error UsuarioController.HttpPost {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("v1/login")]
        public IActionResult PostLogin(UsuarioRequest usuarioRequest)
        {
            UsuarioResult result = new UsuarioResult() { StatusCode = StatusCodes.Status202Accepted };
            try
            {
                result = this.usuarioService.Login(usuarioRequest);
            }
            catch (Exception e)
            {
                logger.LogError($"Error UsuarioController.HttpPost {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("v1/verify_token")]
        public IActionResult PostVerifyToken([FromHeader(Name = "Authorization")] string authorization, UsuarioRequest usuarioRequest)
        {
            var token = authorization.Split(" ").Last();
            UsuarioResult result = new UsuarioResult() { StatusCode = StatusCodes.Status202Accepted };
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var tokenS = handler.ReadToken(token) as JwtSecurityToken;
                bool esValido = TokenGenerator.TokenEsValido(tokenS);
                if (!esValido)
                {
                    return StatusCode(StatusCodes.Status401Unauthorized);
                }
                var acceso = this.usuarioService.ObtenerAcceso(token);
                result = mapper.Map<UsuarioResult>(acceso);                
            }
            catch (Exception e)
            {
                logger.LogError($"Error UsuarioController.HttpPost {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="usuarioModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpPut("v1/usuario/{tokenUsuario}/")]
        public IActionResult Put(string tokenUsuario, [FromBody] UsuarioRequest usuarioRequest)
        {
            UsuarioResult result = new UsuarioResult() { StatusCode = StatusCodes.Status202Accepted };
            try
            {
                usuarioRequest.TokenUsuario = tokenUsuario;
                result = this.usuarioService.ActualizarUsuario(usuarioRequest);
            }
            catch (Exception e)
            {
                logger.LogError($"Error UsuarioController.HttpPut {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="usuarioModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        [HttpDelete("v1/usuario/{tokenUsuario}/")]
        public IActionResult Delete(string tokenUsuario)
        {
            UsuarioResult result = new UsuarioResult() { StatusCode = StatusCodes.Status202Accepted };
            try
            {
                result = this.usuarioService.EliminarUsuario(tokenUsuario);
            }
            catch (Exception e)
            {
                logger.LogError($"Error UsuarioController.HttpDelete {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }


        [HttpGet("v1/usuario/recuperarClave/{email}")]
        public async Task<IActionResult> RecuperarClaveUsuario(string email)
        {
            RecuperarClaveResult result = new RecuperarClaveResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                if (ModelState.IsValid)
                {
                    result = await this.usuarioService.RecuperarContrasenaUsuario(email);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, null);
                }

            }
            catch (Exception e)
            {
                logger.LogError($"Error UsuarioController.RecuperarClave {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("v1/usuario/obtenerRecuperacion/{token}")]
        public ActionResult ObtenerRecuperacion(string token)
        {
            UsuarioResult result = new UsuarioResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.usuarioService.ObtenerUsuarioRecuperacion(token);
            }
            catch (Exception e)
            {
                logger.LogError($"Error UsuarioController.Get {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("v1/usuario/confirmaRecuperarClave/{token}")]
        public async Task<IActionResult> ConfirmaRecuperarClaveUsuario(string token)
        {
            RecuperarClaveResult result = new RecuperarClaveResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                 result = await this.usuarioService.CambioContrasenaAutomaticoUsuario(token);           

            }
            catch (Exception e)
            {
                logger.LogError($"Error OAuthController.RecuperarClave {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }


        [HttpPut("v1/acceso/cambiarClave/{token}")]
       // [Authorize]
        public async Task<IActionResult> CambiarClave(string token,IFormCollection data )
        {
            CambiarClaveResult result = new CambiarClaveResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                CambiarClaveRequest cambiarClaveRequest = JsonConvert.DeserializeObject<CambiarClaveRequest>(data["usuario"]);
                //var user = (AccesoModel)HttpContext.Items["User"];
                //cambiarClaveRequest.Token = user.TokenAcceso;
                cambiarClaveRequest.Token = token;
                result =await this.usuarioService.ActualizarClave(cambiarClaveRequest);
                result.StatusCode = StatusCodes.Status200OK;
            }
            catch (Exception e)
            {
                logger.LogError($"Error OAuthController.CambiarClave {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

    }
}

