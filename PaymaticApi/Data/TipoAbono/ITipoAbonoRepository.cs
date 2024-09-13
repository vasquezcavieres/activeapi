/**
* (c)2013-2023 CodeBase Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*11-12-2023,Generador de Código, Clase Inicial 
*/


using Cl.Intertrade.ActivPay.Entities.TipoAbono;
using System.Collections.Generic;

namespace Cl.Intertrade.ActivPay.Repository.TipoAbono
{
	/// <summary>
	/// Esta Clase TipoAbono  permite gestionar la interacción con la base de datos para la tabla TipoAbono
	/// </summary>
	public interface ITipoAbonoRepository
	{	

		/// <summary>
		/// Consulta todos los elementos existentes
		/// </summary>
		/// <returns>Una lista de objetos</returns>
		IList<TipoAbonoModel> ObtenerTipoAbonos( );
		/// <summary>
		/// Consulta una colección de elementos según parámetros de busqueda
		/// </summary>
		/// <returns>Una lista de objetos para la busqueda especificada</returns>
		IList<TipoAbonoModel> BuscarTipoAbonos( );
		/// <summary>
        /// Consulta un único elemento según clave especificada
        /// </summary>
        /// <returns>Un objeto de persistencia para la clave especificada</returns>
		TipoAbonoModel ObtenerTipoAbono(string codigoTipoAbono);

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="tipoAbonoModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
		TipoAbonoModel CrearTipoAbono(TipoAbonoModel tipoAbonoModel);
		/// <summary>
		/// Actualiza un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="tipoAbonoModel"></param>
		/// <returns>booleano indicando si la operación fue exitosa o no</returns>
		bool ActualizarTipoAbono(TipoAbonoModel tipoAbonoModel);
		/// <summary>
		/// Elimina un elemento desde el medio de persistencia
		/// </summary>
		/// <returns>booleano indicando si la operación fue exitosa o no</returns>
		bool EliminarTipoAbono();
	}
}

