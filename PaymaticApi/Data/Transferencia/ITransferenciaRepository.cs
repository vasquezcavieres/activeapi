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


using Cl.Intertrade.ActivPay.Entities.Transferencia;
using System.Collections.Generic;

namespace Cl.Intertrade.ActivPay.Repository.Transferencia
{
    /// <summary>
    /// Esta Clase Transferencia  permite gestionar la interacción con la base de datos para la tabla Transferencia
    /// </summary>
    public interface ITransferenciaRepository
    {

        /// <summary>
        /// Consulta todos los elementos existentes
        /// </summary>
        /// <returns>Una lista de objetos</returns>
        IList<TransferenciaModel> ObtenerTransferencias();
        /// <summary>
        /// Consulta una colección de elementos según parámetros de busqueda
        /// </summary>
        /// <param name="transferenciaId"></param>
        /// <returns>Una lista de objetos para la busqueda especificada</returns>
        IList<TransferenciaModel> BuscarTransferencias(int transferenciaId);
        /// <summary>
        /// Consulta un único elemento según clave especificada
        /// </summary>
        /// <param name="transferenciaId"></param>
        /// <returns>Un objeto de persistencia para la clave especificada</returns>
        TransferenciaModel ObtenerTransferencia(int transferenciaId);

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="transferenciaModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        TransferenciaModel CrearTransferencia(TransferenciaModel transferenciaModel);
        /// <summary>
        /// Actualiza un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="transferenciaModel"></param>
        /// <returns>booleano indicando si la operación fue exitosa o no</returns>
        bool ActualizarTransferencia(TransferenciaModel transferenciaModel);
        /// <summary>
        /// Elimina un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="transferenciaId"></param>
        /// <returns>booleano indicando si la operación fue exitosa o no</returns>
        bool EliminarTransferencia(int transferenciaId);
        IList<TransferenciaModel> BuscarTransferenciasPorConvenio(int codigoConvenio);
        bool AprobarTransferencia(int transferenciaId);
        IList<TransferenciaModel> ObtenerTransferencias(TransferenciaModel transferenciaModel);
        IList<TransferenciaModel> BuscarTransferenciasPorEdificio(string codigoEdificio);

    }
}

