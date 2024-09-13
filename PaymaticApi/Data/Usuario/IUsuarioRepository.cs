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


using Cl.Intertrade.ActivPay.Entities.Acceso;
using Cl.Intertrade.ActivPay.Entities.Usuario;
using Cl.Intertrade.ActivPayApi.Models.Result.Usuario;
using Serilog;
using System.Collections.Generic;

namespace Cl.Intertrade.ActivPay.Repository.Usuario
{
    /// <summary>
    /// Esta Clase Usuario  permite gestionar la interacción con la base de datos para la tabla Usuario
    /// </summary>
    public interface IUsuarioRepository
    {

        /// <summary>
        /// Consulta todos los elementos existentes
        /// </summary>
        /// <returns>Una lista de objetos</returns>
        IList<UsuarioModel> ObtenerUsuarios();
        /// <summary>
        /// Consulta una colección de elementos según parámetros de busqueda
        /// </summary>
        /// <param name="tokenUsuario"></param>
        /// <returns>Una lista de objetos para la busqueda especificada</returns>
        IList<UsuarioModel> BuscarUsuarios(string tokenUsuario);
        /// <summary>
        /// Consulta un único elemento según clave especificada
        /// </summary>
        /// <param name="tokenUsuario"></param>
        /// <returns>Un objeto de persistencia para la clave especificada</returns>
        UsuarioModel ObtenerUsuario(string tokenUsuario);

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="usuarioModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        UsuarioModel CrearUsuario(UsuarioModel usuarioModel);
        /// <summary>
        /// Actualiza un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="usuarioModel"></param>
        /// <returns>booleano indicando si la operación fue exitosa o no</returns>
        bool ActualizarUsuario(UsuarioModel usuarioModel);
        /// <summary>
        /// Elimina un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="tokenUsuario"></param>
        /// <returns>booleano indicando si la operación fue exitosa o no</returns>
        bool EliminarUsuario(string tokenUsuario);
        UsuarioModel Login(UsuarioModel usuarioModel);
        bool EliminarAccesoTokenUsuario(string token);
        public AccesoModel ObtenerAcceso(string token);
        AccesoModel CrearAcceso(AccesoModel accesoModel);
        public AccesoModel ObtenerAccesoTokenUsuario(string token);
        UsuarioModel ObtenerUsuarioEmail(string email);

        UsuarioModel ObtenerUsuarioRecuperado(string token);
        bool ActualizarClave(UsuarioModel usuarioModel);
        IList<UsuarioModel> ObtenerUsuariosComunidad();
        IList<UsuarioModel> ObtenerUsuariosAdministradorConvenio();

    }
}

