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


using Cl.Intertrade.ActivPay.Entities.Factura;
using System.Collections.Generic;

namespace Cl.Intertrade.ActivPay.Repository.Factura
{
    /// <summary>
    /// Esta Clase Factura  permite gestionar la interacción con la base de datos para la tabla Factura
    /// </summary>
    public interface IFacturaRepository
    {

        /// <summary>
        /// Consulta todos los elementos existentes
        /// </summary>
        /// <returns>Una lista de objetos</returns>
        IList<FacturaModel> ObtenerFacturas();
        /// <summary>
        /// Consulta una colección de elementos según parámetros de busqueda
        /// </summary>
        /// <param name="numeroFactura"></param>
        /// <returns>Una lista de objetos para la busqueda especificada</returns>
        IList<FacturaModel> BuscarFacturas(int numeroFactura);
        /// <summary>
        /// Consulta un único elemento según clave especificada
        /// </summary>
        /// <param name="numeroFactura"></param>
        /// <returns>Un objeto de persistencia para la clave especificada</returns>
        FacturaModel ObtenerFactura(int numeroFactura);

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="facturaModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        FacturaModel CrearFactura(FacturaModel facturaModel);
        /// <summary>
        /// Actualiza un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="facturaModel"></param>
        /// <returns>booleano indicando si la operación fue exitosa o no</returns>
        bool ActualizarFactura(FacturaModel facturaModel);
        /// <summary>
        /// Elimina un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="numeroFactura"></param>
        /// <returns>booleano indicando si la operación fue exitosa o no</returns>
        bool EliminarFactura(int numeroFactura);
        IList<FacturaModel> BuscarFacturas(FacturaModel facturaModel);
        FacturaModel AnularFactura(FacturaModel facturaModel);
        Task<FacturaModel> ObtenerNotaCredito(FacturaModel facturaModel);

    }
}

