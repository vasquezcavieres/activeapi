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


using AutoMapper;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Http;
using Cl.Intertrade.ActivPay.Helpers.Base;
using Cl.Intertrade.ActivPay.Entities.Usuario;
using Cl.Intertrade.ActivPay.Request.Usuario;
using Cl.Intertrade.ActivPay.Result.Usuario;
using Cl.Intertrade.ActivPay.Repository.Usuario;
using Cl.Intertrade.ActivPay.OAuth.Validators;
using System.Security.Cryptography;
using System.Text;
using ActivPayApi.Helpers.Validators;
using Cl.Intertrade.ActivPay.Entities.Acceso;
using Cl.Intertrade.ActivPayApi.Models.Result.Usuario;
using SendGrid;
using SendGrid.Helpers.Mail;
using Cl.Intertrade.ActivPay.Helpers.Security;
using ActivPayApi.Models.Request.Usuario;
using ActivPayApi.Models.Result.Usuario;
using Cl.Intertrade.ActivPay.Repository.Edificio;
using Cl.Intertrade.ActivPay.Entities.Edificio;

namespace Cl.Intertrade.ActivPay.Data.Usuario
{
	/// <summary>
	/// Esta Clase Usuario  permite gestionar reglas de negocio asociados a la entidad Usuario
	/// </summary>
	public partial class UsuarioService : IUsuarioService
	{	
        private ISettingsConfig settings;
        private IUsuarioRepository usuarioRepository;
        private IEdificioRepository edificioRepository;
        private ILogger<UsuarioService> logger;
        private IMapper mapper;
        public UsuarioService(IUsuarioRepository usuarioRepository, ISettingsConfig settings, ILogger<UsuarioService> logger, IMapper mapper, IEdificioRepository edificioRepository)
        {
            this.usuarioRepository = usuarioRepository;
            this.edificioRepository = edificioRepository;
            this.mapper = mapper;
            this.settings = settings;
            this.logger = logger;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <returns>Objeto UsuarioResult con información del resultado de la operación</returns>
		public ListadoUsuarioResult ObtenerUsuarios()
		{
			ListadoUsuarioResult listadoUsuarioResult = new ListadoUsuarioResult();
            listadoUsuarioResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
				var usuarios = usuarioRepository.ObtenerUsuarios();
                listadoUsuarioResult.Usuarios = new List<UsuarioResult>();

                if (usuarios != null)
                {
                    listadoUsuarioResult.Usuarios = mapper.Map<IList<UsuarioResult>>(usuarios);
                    listadoUsuarioResult.StatusCode = StatusCodes.Status200OK;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"UsuarioService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoUsuarioResult;
		}

        public ListadoUsuarioResult ObtenerUsuariosComunidad()
        {
            ListadoUsuarioResult listadoUsuarioResult = new ListadoUsuarioResult();
            listadoUsuarioResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
                var usuarios = usuarioRepository.ObtenerUsuariosComunidad();
                listadoUsuarioResult.Usuarios = new List<UsuarioResult>();

                if (usuarios != null)
                {
                    listadoUsuarioResult.Usuarios = mapper.Map<IList<UsuarioResult>>(usuarios);
                    listadoUsuarioResult.StatusCode = StatusCodes.Status200OK;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"UsuarioService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoUsuarioResult;
        }

        public ListadoUsuarioResult ObtenerUsuariosAdministradorConvenio()
        {
            ListadoUsuarioResult listadoUsuarioResult = new ListadoUsuarioResult();
            listadoUsuarioResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
                var usuarios = usuarioRepository.ObtenerUsuariosAdministradorConvenio();
                listadoUsuarioResult.Usuarios = new List<UsuarioResult>();

                if (usuarios != null)
                {
                    listadoUsuarioResult.Usuarios = mapper.Map<IList<UsuarioResult>>(usuarios);
                    listadoUsuarioResult.StatusCode = StatusCodes.Status200OK;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"UsuarioService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoUsuarioResult;
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="tokenUsuario"></param>
        /// <returns>Objeto UsuarioResult con información del resultado de la operación</returns>
        public ListadoUsuarioResult BuscarUsuarios(string tokenUsuario )
		{
			ListadoUsuarioResult listadoUsuarioResult = new ListadoUsuarioResult();
            listadoUsuarioResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
				var usuarios = usuarioRepository.BuscarUsuarios(tokenUsuario);
                listadoUsuarioResult.Usuarios = new List<UsuarioResult>();

                if (usuarios != null)
                {
                    listadoUsuarioResult.Usuarios = mapper.Map<IList<UsuarioResult>>(usuarios);
                    listadoUsuarioResult.StatusCode = StatusCodes.Status200OK;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"UsuarioService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoUsuarioResult;
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="tokenUsuario"></param>
/// <returns>Objeto UsuarioResult con información del resultado de la operación</returns>
		public UsuarioResult ObtenerUsuario(string tokenUsuario )
        {
			UsuarioResult usuarioResult = new UsuarioResult();
            usuarioResult.StatusCode = StatusCodes.Status202Accepted;
			try
			{
				var usuario = usuarioRepository.ObtenerUsuario(tokenUsuario);
                if (usuario!=null)
                {
                    usuarioResult = mapper.Map<UsuarioResult>(usuario);
                    usuarioResult.StatusCode = StatusCodes.Status200OK;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"UsuarioService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return usuarioResult;
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="usuarioModel"></param>
		/// <returns>Objeto UsuarioResult con información del resultado de la operación</returns>
		public async  Task<UsuarioResult> CrearUsuario(UsuarioRequest usuarioRequest)
		{
			UsuarioResult usuarioResult = new UsuarioResult();
            usuarioResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {
				var usuario = mapper.Map<UsuarioModel>(usuarioRequest);
                usuario.TokenUsuario = Guid.NewGuid().ToString().CleanScriptPoint();
                usuario.FechaCreacion = DateTime.Now;                
                usuario.Activo = true;

                if (usuario.CodigoRol == string.Empty)
                {
                    usuario.CodigoRol = "CONVENIO";
                }                

                usuario = usuarioRepository.CrearUsuario(usuario);
                if (usuario != null)
                {

                    var generator = new PasswordGenerator(minimumLengthPassword: 8,
                                     maximumLengthPassword: 8,
                                     minimumUpperCaseChars: 1,
                                     minimumNumericChars: 1,
                                     minimumSpecialChars: 0);
                    string password = generator.Generate();
                    usuario.UltimaClave = password;// usuario.Clave;
                    usuario.Clave = password;

                    using (var md5 = MD5.Create())
                    {
                        var resultpass = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
                        var passwordCodificada = Encoding.ASCII.GetString(resultpass);
                        usuario.Clave = passwordCodificada;
                    }

                    usuario.DebeCambiarClave = true;
                    usuario.FechaActualizacion = DateTime.Now;
                    //usuario.TokenRecuperacion = string.Empty;
                    var result = usuarioRepository.ActualizarClave(usuario);
                    
                    if (result)
                    {
                        if (usuario.CodigoRol == "COMUNIDAD")
                        {
                            var edificio = new EdificioModel();
                            edificio.RutComunidad = usuario.RutUsuario;
                            edificio.CodigoEdificio = usuario.CodigoEdificio;
                            var asociar = edificioRepository.AsociarEdificioComunidad(edificio);
                        }

                        usuarioResult = mapper.Map<UsuarioResult>(usuario);
                        usuarioResult.Clave = password;
                        await EnviarEmailBienvenida(usuarioResult);
                        
                    }
                    usuarioResult = mapper.Map<UsuarioResult>(usuario);
                    usuarioResult.StatusCode = StatusCodes.Status201Created;
                }
			}
			catch (Exception e)
            {
                logger.LogError($"UsuarioService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return usuarioResult;
        }

        public UsuarioResult Login(UsuarioRequest usuarioRequest)
        {
            UsuarioResult usuarioResult = new UsuarioResult();
            usuarioResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {
                var usuario = mapper.Map<UsuarioModel>(usuarioRequest);          
                using (var md5 = MD5.Create())
                {
                    var result = md5.ComputeHash(Encoding.ASCII.GetBytes(usuario.Clave));
                    var passwordCodificada = Encoding.ASCII.GetString(result);
                    usuario.Clave = passwordCodificada;
                }

                usuario = usuarioRepository.Login(usuario);
                if (usuario != null)
                {
                    usuarioResult = mapper.Map<UsuarioResult>(usuario);
                    var token = TokenGenerator.GenerateTokenJwt(usuario.RutUsuario);
                    usuarioResult.TokenAcceso = token;

                    //crear acceso               
                    AccesoModel accesoModel = new AccesoModel();
                    accesoModel.Id = 0;
                    accesoModel.TokenAcceso = token;
                    accesoModel.TokenUsuario = usuario.TokenUsuario;
                    accesoModel.TokenRefresco = "";
                    accesoModel.FechaCreacion = DateTime.Now;
                    accesoModel.Nombres = usuario.Nombres;
                    accesoModel.Apellidos = usuario.Apellidos;
                    accesoModel.RutUsuario = usuario.RutUsuario.ToString();
                    accesoModel.DvUsuario = usuario.RutUsuarioDv;
                    accesoModel.Email = usuario.Email;
                    accesoModel.CodigoRol = usuario.CodigoRol;
                    accesoModel.CodigoPais = usuario.CodigoPais;
                    accesoModel.Pais = usuario.Pais;
                    
                    accesoModel = usuarioRepository.CrearAcceso(accesoModel);

                    //if (usuarioResult.DebeCambiarClave == false)
                    //{
                    //    accesoModel = usuarioRepository.CrearAcceso(accesoModel);
                    //}

                    //var resultado = usuarioRepository.EliminarAccesoTokenUsuario(usuarioResult.TokenUsuario);
                    //if (resultado)
                    //{
                    //    if (usuarioResult.DebeCambiarClave == false)
                    //    {
                    //        accesoModel = usuarioRepository.CrearAcceso(accesoModel);
                    //    }
                    //}

                    usuarioResult.StatusCode = StatusCodes.Status201Created;
                }
                else
                {
                    usuarioResult.StatusCode = StatusCodes.Status401Unauthorized;
                    usuarioResult.Errores = new List<string>
                    {
                        "Favor Revisar Email y Clave."
                    };
                }

            }
            catch (Exception e)
            {
                logger.LogError($"UsuarioService: {e.Message}, {e.StackTrace}");
                throw e;
            }

            logger.LogError($"Login => : usuarioResult =>  { Newtonsoft.Json.JsonConvert.SerializeObject(usuarioResult)  }");
            return usuarioResult;
        }



        public AccesoModel ObtenerAcceso(string token)
        {
            AccesoModel usuarioResult = new AccesoModel();
           // usuarioResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {
                usuarioResult = usuarioRepository.ObtenerAcceso(token);             
            }
            catch (Exception e)
            {
                logger.LogError($"UsuarioService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return usuarioResult;
        }


        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="usuarioModel"></param>
        /// <returns>Objeto UsuarioResult con información del resultado de la operación</returns>
        public UsuarioResult ActualizarUsuario(UsuarioRequest usuarioRequest)
		{
			UsuarioResult usuarioResult = new UsuarioResult();
            usuarioResult.StatusCode = StatusCodes.Status202Accepted;
			try
			{
				var usuario = mapper.Map<UsuarioModel>(usuarioRequest);
                var result = usuarioRepository.ActualizarUsuario(usuario);
                if (result)
                {
                    usuarioResult.StatusCode = StatusCodes.Status204NoContent;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"UsuarioService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return usuarioResult;
		}
		
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="usuarioModel"></param>
		/// <returns>Objeto UsuarioResult con información del resultado de la operación</returns>
		public UsuarioResult EliminarUsuario(string tokenUsuario )
        {
			UsuarioResult usuarioResult = new UsuarioResult();
            usuarioResult.StatusCode = StatusCodes.Status202Accepted;
			try
			{
				var result = usuarioRepository.EliminarUsuario(tokenUsuario);
                if (result)
                {
                    usuarioResult.StatusCode = StatusCodes.Status204NoContent;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"UsuarioService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return usuarioResult;
        }


        //OAUTH
        public async Task<RecuperarClaveResult> RecuperarContrasenaUsuario( string email)
        {

            logger.LogInformation($"RecuperarContrasenaUsuario => {email}");

            RecuperarClaveResult recuperarClaveResult = new RecuperarClaveResult();
            recuperarClaveResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
                var usuario = usuarioRepository.ObtenerUsuarioEmail(email);
                if (usuario != null)
                {
                    if (usuario.Activo == true)
                    {
                        usuario.TokenRecuperacion = Guid.NewGuid().ToString().CleanScriptPoint();
                        usuario.FechaActualizacion = DateTime.Now;
                        var result = usuarioRepository.ActualizarUsuario(usuario);
                        recuperarClaveResult.Result = result;
                        if (result)
                        {
                            var usuarioResult = mapper.Map<UsuarioResult>(usuario);

                            logger.LogInformation($"EnviarEmailRecuperacion => {email}");
                            await EnviarEmailRecuperacion( usuarioResult);
                            recuperarClaveResult.StatusCode = StatusCodes.Status200OK;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return recuperarClaveResult;
        }

        public UsuarioResult ObtenerUsuarioRecuperacion(string tokenRecuperacion)
        {
            UsuarioResult usuarioResult = new UsuarioResult();
            usuarioResult.StatusCode = StatusCodes.Status404NotFound;
            try
            {               
                var usuario = usuarioRepository.ObtenerUsuarioRecuperado(tokenRecuperacion);
                if (usuario != null)
                {
                    usuarioResult = mapper.Map<UsuarioResult>(usuario);
                    usuarioResult.StatusCode = StatusCodes.Status200OK;
                }
                else
                {
                    usuarioResult.StatusCode = StatusCodes.Status400BadRequest;
                    usuarioResult.Errores = new List<string>();
                    usuarioResult.Errores.Add("El enlace proporcionado no está disponible.");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return usuarioResult;
        }

        public async Task<RecuperarClaveResult> CambioContrasenaAutomaticoUsuario(string token)
        {
            RecuperarClaveResult recuperarClaveResult = new RecuperarClaveResult();
            recuperarClaveResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {               
                var usuario = usuarioRepository.ObtenerUsuarioRecuperado(token);
                if (usuario != null)
                {
                    if (usuario.Activo == true)
                    {
                        var generator = new PasswordGenerator(minimumLengthPassword: 8,
                                      maximumLengthPassword: 8,
                                      minimumUpperCaseChars: 1,
                                      minimumNumericChars: 1,
                                      minimumSpecialChars: 0);
                        string password = generator.Generate();
                        usuario.UltimaClave = usuario.Clave;
                        usuario.Clave = password;

                        using (var md5 = MD5.Create())
                        {
                            var resultpass = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
                            var passwordCodificada = Encoding.ASCII.GetString(resultpass);
                            usuario.Clave = passwordCodificada;
                        }

                        usuario.DebeCambiarClave = true;
                        usuario.FechaActualizacion = DateTime.Now;
                        //usuario.TokenRecuperacion = string.Empty;
                        var result = usuarioRepository.ActualizarClave(usuario);
                        recuperarClaveResult.Result = result;
                        recuperarClaveResult.Token = usuario.TokenUsuario;
                        if (result)
                        {
                            var usuarioResult = mapper.Map<UsuarioResult>(usuario);
                            usuarioResult.Clave = password;
                            await EnviarEmailClave(usuarioResult);
                            recuperarClaveResult.StatusCode = StatusCodes.Status200OK;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return recuperarClaveResult;
        }


        public async Task<CambiarClaveResult> ActualizarClave(CambiarClaveRequest cambiarClaveRequest)
        {
            logger.LogInformation($"ActualizarClave =>cambiarClaveRequest => {Newtonsoft.Json.JsonConvert.SerializeObject(cambiarClaveRequest)}");
            CambiarClaveResult cambiarClaveResult = new CambiarClaveResult();
            cambiarClaveResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
                var accesoModel = usuarioRepository.ObtenerUsuarioRecuperado(cambiarClaveRequest.Token);
                logger.LogInformation($"ActualizarClave =>accesoModel => {Newtonsoft.Json.JsonConvert.SerializeObject(accesoModel)}");
                var usuario = new UsuarioModel();
                usuario.TokenUsuario = accesoModel.TokenUsuario;
                usuario.TokenRecuperacion = string.Empty;
                usuario.DebeCambiarClave = false;
                usuario.FechaActualizacion = DateTime.Now;
                usuario.Email = accesoModel.Email;
                using (var md5 = MD5.Create())
                {
                    var resultpass = md5.ComputeHash(Encoding.ASCII.GetBytes(cambiarClaveRequest.Clave));
                    var passwordCodificada = Encoding.ASCII.GetString(resultpass);
                    usuario.Clave = passwordCodificada;
                }

                var result = usuarioRepository.ActualizarClave(usuario);
                logger.LogInformation($"ActualizarClave =>ActualizarClave => {Newtonsoft.Json.JsonConvert.SerializeObject(result)}");
                if (result)
                {
                    var usuarioResult = mapper.Map<UsuarioResult>(usuario);
                    logger.LogInformation($"EnviarEmailAvisoClave");
                    await EnviarEmailAvisoClave(usuarioResult);
                    cambiarClaveResult.StatusCode = StatusCodes.Status200OK;
                }

            }
            catch (Exception e)
            {
                logger.LogInformation($"ActualizarClave =>e => {Newtonsoft.Json.JsonConvert.SerializeObject(e)}");
                throw e;
            }
            return cambiarClaveResult;
        }

        public async Task<bool> EnviarEmailRecuperacion(UsuarioResult usuarioResult)
        {
            logger.LogInformation($"EnviarEmailRecuperacion => settings.SendgridProfile.TemplateId => {settings.SendgridProfile.TemplateId}");
            logger.LogInformation($"usuarioResult =>  {Newtonsoft.Json.JsonConvert.SerializeObject(usuarioResult)}");

            bool result = false;

            var client = new SendGridClient(settings.SendgridProfile.ApiKey);
            var from = new EmailAddress(settings.SendgridProfile.From);
            var to = new EmailAddress(usuarioResult.Email);
            byte[] content = null;

            var templateData = new
            {
                Nombre = $"{usuarioResult.Nombres} {usuarioResult.Apellidos}",
                Token = usuarioResult.TokenRecuperacion
            };

            var msg = MailHelper.CreateSingleTemplateEmail(from, to, settings.SendgridProfile.TemplateId, templateData);
            var response = await client.SendEmailAsync(msg);

            logger.LogInformation($"response SendEmailAsync =>  {Newtonsoft.Json.JsonConvert.SerializeObject(response)}");
            return result;
        }

        public async Task<bool> EnviarEmailClave(UsuarioResult usuarioResult)
        {
            bool result = false;

            var client = new SendGridClient(settings.SendgridProfile.ApiKey);
            var from = new EmailAddress(settings.SendgridProfile.From);
            var to = new EmailAddress(usuarioResult.Email);
            byte[] content = null;

            var templateData = new
            {
                Nombre = $"{usuarioResult.Nombres} {usuarioResult.Apellidos}",
                Clave = usuarioResult.Clave
            };

            var msg = MailHelper.CreateSingleTemplateEmail(from, to, settings.SendgridProfile.TemplateNuevaClaveId, templateData);
            var response = await client.SendEmailAsync(msg);
            return result;
        }

        public async Task<bool> EnviarEmailBienvenida(UsuarioResult usuarioResult)
        {
            bool result = false;

            var client = new SendGridClient(settings.SendgridProfile.ApiKey);
            var from = new EmailAddress(settings.SendgridProfile.From);
            var to = new EmailAddress(usuarioResult.Email);
            byte[] content = null;

            var templateData = new
            {
                Nombre = $"{usuarioResult.Nombres} {usuarioResult.Apellidos}",
                Clave = usuarioResult.Clave
            };

            var msg = MailHelper.CreateSingleTemplateEmail(from, to, settings.SendgridProfile.TemplateBienvenida, templateData);
            var response = await client.SendEmailAsync(msg);
            return result;
        }

        public async Task<bool> EnviarEmailAvisoClave(UsuarioResult usuarioResult)
        {
            logger.LogInformation($"EnviarEmailAvisoClave =>usuarioResult => {Newtonsoft.Json.JsonConvert.SerializeObject(usuarioResult)}");
            bool result = false;

            var client = new SendGridClient(settings.SendgridProfile.ApiKey);
            var from = new EmailAddress(settings.SendgridProfile.From);
            var to = new EmailAddress(usuarioResult.Email);
            byte[] content = null;

            var templateData = new
            {
                Nombre = $"{usuarioResult.Nombres} {usuarioResult.Apellidos}"
            };

            var msg = MailHelper.CreateSingleTemplateEmail(from, to, settings.SendgridProfile.TemplateCambioCalve, templateData);
            var response = await client.SendEmailAsync(msg);
            logger.LogInformation($"EnviarEmailAvisoClave =>response => {Newtonsoft.Json.JsonConvert.SerializeObject(response)}");
            return result;
        }

    }
}

