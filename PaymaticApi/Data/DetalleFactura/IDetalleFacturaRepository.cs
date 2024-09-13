






/**
* (c)2013-2023 CodeBase Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*25-10-2023,Generador de Código, Clase Inicial 
*/


using Cl.Intertrade.ActivPay.Entities.DetalleFactura;
using System.Collections.Generic;

namespace Cl.Intertrade.ActivPay.Repository.DetalleFactura
{
	/// <summary>
	/// Esta Clase DetalleFactura  permite gestionar la interacción con la base de datos para la tabla DetalleFactura
	/// </summary>
	public interface IDetalleFacturaRepository
	{	

		/// <summary>
		/// Consulta todos los elementos existentes
		/// </summary>
		/// <returns>Una lista de objetos</returns>
		IList<DetalleFacturaModel> ObtenerDetalleFacturas( );
		/// <summary>
		/// Consulta una colección de elementos según parámetros de busqueda
		/// </summary>
		/// <param name="numeroFactura"></param>
/// <param name="transferenciaId"></param>
/// <returns>Una lista de objetos para la busqueda especificada</returns>
		IList<DetalleFacturaModel> BuscarDetalleFacturas( int numeroFactura);
		/// <summary>
        /// Consulta un único elemento según clave especificada
        /// </summary>
        /// <param name="numeroFactura"></param>
/// <param name="transferenciaId"></param>
/// <returns>Un objeto de persistencia para la clave especificada</returns>
		DetalleFacturaModel ObtenerDetalleFactura(int numeroFactura, int transferenciaId);

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="detalleFacturaModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
		DetalleFacturaModel CrearDetalleFactura(DetalleFacturaModel detalleFacturaModel);
		/// <summary>
		/// Actualiza un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="detalleFacturaModel"></param>
		/// <returns>booleano indicando si la operación fue exitosa o no</returns>
		bool ActualizarDetalleFactura(DetalleFacturaModel detalleFacturaModel);
		/// <summary>
		/// Elimina un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="numeroFactura"></param>
/// <param name="transferenciaId"></param>
/// <returns>booleano indicando si la operación fue exitosa o no</returns>
		bool EliminarDetalleFactura(int numeroFactura, int transferenciaId);
	}
}

