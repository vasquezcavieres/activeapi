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


using Cl.Intertrade.ActivPay.Request.Usuario;
using Cl.Intertrade.ActivPay.Result.Usuario;
using System.Collections.Generic;
using System;
using Cl.Intertrade.ActivPay.Entities.Acceso;
using Cl.Intertrade.ActivPayApi.Models.Result.Usuario;
using ActivPayApi.Models.Request.Usuario;
using ActivPayApi.Models.Result.Usuario;

namespace Cl.Intertrade.ActivPay.Data.Usuario
{
    /// <summary>
    /// Esta Clase Usuario  permite gestionar la interacción con la base de datos para la tabla Usuario
    /// </summary>
    public interface IUsuarioService
    {

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <returns>Objeto UsuarioResult con información del resultado de la operación</returns>
        ListadoUsuarioResult ObtenerUsuarios();
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="tokenUsuario"></param>
        /// <returns>Objeto UsuarioResult con información del resultado de la operación</returns>
        ListadoUsuarioResult BuscarUsuarios(string tokenUsuario);
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="tokenUsuario"></param>
        /// <returns>Objeto UsuarioResult con información del resultado de la operación</returns>
        UsuarioResult ObtenerUsuario(string tokenUsuario);

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="usuarioRequest"></param>
        /// <returns>Objeto UsuarioResult con información del resultado de la operación</returns>
        public Task<UsuarioResult> CrearUsuario(UsuarioRequest usuarioRequest);
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="usuarioModel"></param>
        /// <returns>Objeto UsuarioResult con información del resultado de la operación</returns>
        public UsuarioResult ActualizarUsuario(UsuarioRequest usuarioRequest);
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="usuarioModel"></param>
        /// <returns>Objeto UsuarioResult con información del resultado de la operación</returns>
        UsuarioResult EliminarUsuario(string tokenUsuario);
        UsuarioResult Login(UsuarioRequest usuarioRequest);
        AccesoModel ObtenerAcceso(string token);
        Task<RecuperarClaveResult> RecuperarContrasenaUsuario(string email);

        Task<RecuperarClaveResult> CambioContrasenaAutomaticoUsuario(string token);
        UsuarioResult ObtenerUsuarioRecuperacion(string tokenRecuperacion);
        Task<CambiarClaveResult> ActualizarClave(CambiarClaveRequest cambiarClaveRequest);
        ListadoUsuarioResult ObtenerUsuariosComunidad();
        ListadoUsuarioResult ObtenerUsuariosAdministradorConvenio();

    }
}

