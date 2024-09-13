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


using Cl.Intertrade.ActivPay.Entities.Edificio;
using System.Collections.Generic;

namespace Cl.Intertrade.ActivPay.Repository.Edificio
{
    /// <summary>
    /// Esta Clase Edificio  permite gestionar la interacción con la base de datos para la tabla Edificio
    /// </summary>
    public interface IEdificioRepository
    {

        /// <summary>
        /// Consulta todos los elementos existentes
        /// </summary>
        /// <returns>Una lista de objetos</returns>
        IList<EdificioModel> ObtenerEdificios();
        IList<EdificioModel> ObtenerEdificiosAsociados();

        /// <summary>
        /// Consulta una colección de elementos según parámetros de busqueda
        /// </summary>
        /// <param name="codigoEdificio"></param>
        /// <returns>Una lista de objetos para la busqueda especificada</returns>
        IList<EdificioModel> BuscarEdificios(string codigoEdificio);
        /// <summary>
        /// Consulta un único elemento según clave especificada
        /// </summary>
        /// <param name="codigoEdificio"></param>
        /// <returns>Un objeto de persistencia para la clave especificada</returns>
        EdificioModel ObtenerEdificio(string codigoEdificio);

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="edificioModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        EdificioModel CrearEdificio(EdificioModel edificioModel);
        /// <summary>
        /// Actualiza un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="edificioModel"></param>
        /// <returns>booleano indicando si la operación fue exitosa o no</returns>
        bool ActualizarEdificio(EdificioModel edificioModel);
        /// <summary>
        /// Elimina un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="codigoEdificio"></param>
        /// <returns>booleano indicando si la operación fue exitosa o no</returns>
        bool EliminarEdificio(string codigoEdificio);
        bool AsociarEdificio(EdificioModel edificioModel);
        IList<EdificioModel> BuscarEdificiosConvenio(int razonSocial);
        bool DesAsociarEdificio(EdificioModel edificioModel);
        bool AsociarEdificioComunidad(EdificioModel edificioModel);
        EdificioModel ObtenerEdificioComunidad(int rutComunidad);

    }
}

