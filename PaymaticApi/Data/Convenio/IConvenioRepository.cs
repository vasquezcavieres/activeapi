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


using Cl.Intertrade.ActivPay.Entities.Convenio;
using System.Collections.Generic;

namespace Cl.Intertrade.ActivPay.Repository.Convenio
{
    /// <summary>
    /// Esta Clase Convenio  permite gestionar la interacción con la base de datos para la tabla Convenio
    /// </summary>
    public interface IConvenioRepository
    {

        /// <summary>
        /// Consulta todos los elementos existentes
        /// </summary>
        /// <returns>Una lista de objetos</returns>
        IList<ConvenioModel> ObtenerConvenios();
        /// <summary>
        /// Consulta una colección de elementos según parámetros de busqueda
        /// </summary>
        /// <param name="rutRazonSocial"></param>
        /// <returns>Una lista de objetos para la busqueda especificada</returns>
        IList<ConvenioModel> BuscarConvenios(int rutRazonSocial);
        /// <summary>
        /// Consulta un único elemento según clave especificada
        /// </summary>
        /// <param name="rutRazonSocial"></param>
        /// <returns>Un objeto de persistencia para la clave especificada</returns>
        ConvenioModel ObtenerConvenio(int rutRazonSocial);

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="convenioModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        ConvenioModel CrearConvenio(ConvenioModel convenioModel);
        /// <summary>
        /// Actualiza un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="convenioModel"></param>
        /// <returns>booleano indicando si la operación fue exitosa o no</returns>
        bool ActualizarConvenio(ConvenioModel convenioModel);
        /// <summary>
        /// Elimina un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="rutRazonSocial"></param>
        /// <returns>booleano indicando si la operación fue exitosa o no</returns>
        bool EliminarConvenio(int rutRazonSocial);
        bool AsociarUsuarioAdministradaor(ConvenioModel convenioModel);
        ConvenioModel ObtenerConvenioPorEdificio(string codigoEdificio);
        ConvenioModel ObtenerConvenioPorAdministrador(int rutAdministrador);

    }
}

