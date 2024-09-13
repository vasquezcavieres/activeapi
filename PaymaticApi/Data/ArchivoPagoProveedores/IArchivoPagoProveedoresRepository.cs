






/**
* (c)2013-2023 CodeBase Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*14-11-2023,Generador de Código, Clase Inicial 
*/


using Cl.Intertrade.ActivPayApi.Entities.ArchivoPagoProveedores;
using System.Collections.Generic;

namespace Cl.Intertrade.ActivPayApi.Repository.ArchivoPagoProveedores
{
	/// <summary>
	/// Esta Clase ArchivoPagoProveedores  permite gestionar la interacción con la base de datos para la tabla ArchivoPagoProveedores
	/// </summary>
	public interface IArchivoPagoProveedoresRepository
	{	

		/// <summary>
		/// Consulta todos los elementos existentes
		/// </summary>
		/// <returns>Una lista de objetos</returns>
		IList<ArchivoPagoProveedoresModel> ObtenerArchivoPagoProveedoress( );
		/// <summary>
		/// Consulta una colección de elementos según parámetros de busqueda
		/// </summary>
		/// <returns>Una lista de objetos para la busqueda especificada</returns>
		IList<ArchivoPagoProveedoresModel> BuscarArchivoPagoProveedoress( );
        /// <summary>
        /// Consulta un único elemento según clave especificada
        /// </summary>
        /// <returns>Un objeto de persistencia para la clave especificada</returns>
        ArchivoPagoProveedoresModel ObtenerArchivoPagoProveedores(int numeroArchivo);

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="archivoPagoProveedoresModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        ArchivoPagoProveedoresModel CrearArchivoPagoProveedores(ArchivoPagoProveedoresModel archivoPagoProveedoresModel);
		/// <summary>
		/// Actualiza un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="archivoPagoProveedoresModel"></param>
		/// <returns>booleano indicando si la operación fue exitosa o no</returns>
		bool ActualizarArchivoPagoProveedores(ArchivoPagoProveedoresModel archivoPagoProveedoresModel);
		/// <summary>
		/// Elimina un elemento desde el medio de persistencia
		/// </summary>
		/// <returns>booleano indicando si la operación fue exitosa o no</returns>
		bool EliminarArchivoPagoProveedores();
	}
}

