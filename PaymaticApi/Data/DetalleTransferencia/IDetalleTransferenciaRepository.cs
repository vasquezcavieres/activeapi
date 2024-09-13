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


using Cl.Intertrade.ActivPay.Entities.DetalleTransferencia;
using System.Collections.Generic;

namespace Cl.Intertrade.ActivPay.Repository.DetalleTransferencia
{
    /// <summary>
    /// Esta Clase DetalleTransferencia  permite gestionar la interacción con la base de datos para la tabla DetalleTransferencia
    /// </summary>
    public interface IDetalleTransferenciaRepository
    {

        /// <summary>
        /// Consulta todos los elementos existentes
        /// </summary>
        /// <returns>Una lista de objetos</returns>
        IList<DetalleTransferenciaModel> ObtenerDetalleTransferencias();
        /// <summary>
        /// Consulta una colección de elementos según parámetros de busqueda
        /// </summary>
        /// <param name="transferenciaId"></param>
        /// <param name="rutRazonSocial"></param>
        /// <returns>Una lista de objetos para la busqueda especificada</returns>
        IList<DetalleTransferenciaModel> BuscarDetalleTransferencias(int transferenciaId, int rutRazonSocial);
        /// <summary>
        /// Consulta un único elemento según clave especificada
        /// </summary>
        /// <param name="transferenciaId"></param>
        /// <param name="rutRazonSocial"></param>
        /// <returns>Un objeto de persistencia para la clave especificada</returns>
        DetalleTransferenciaModel ObtenerDetalleTransferencia(int transferenciaId, int rutRazonSocial);

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="detalleTransferenciaModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        DetalleTransferenciaModel CrearDetalleTransferencia(DetalleTransferenciaModel detalleTransferenciaModel);
        /// <summary>
        /// Actualiza un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="detalleTransferenciaModel"></param>
        /// <returns>booleano indicando si la operación fue exitosa o no</returns>
        bool ActualizarDetalleTransferencia(DetalleTransferenciaModel detalleTransferenciaModel);
        /// <summary>
        /// Elimina un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="transferenciaId"></param>
        /// <param name="rutRazonSocial"></param>
        /// <returns>booleano indicando si la operación fue exitosa o no</returns>
        bool EliminarDetalleTransferencia(int transferenciaId, int rutRazonSocial);
        IList<DetalleTransferenciaModel> BuscarDetalleTransferencias(int transferenciaId);

    }
}

