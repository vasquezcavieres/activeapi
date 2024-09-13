






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


using Cl.Intertrade.ActivPayApi.Request.ArchivoPagoProveedores;
using Cl.Intertrade.ActivPayApi.Result.ArchivoPagoProveedores;
using System.Collections.Generic;
using System;

namespace Cl.Intertrade.ActivPayApi.Data.ArchivoPagoProveedores
{
	/// <summary>
	/// Esta Clase ArchivoPagoProveedores  permite gestionar la interacción con la base de datos para la tabla ArchivoPagoProveedores
	/// </summary>
	public interface IArchivoPagoProveedoresService
	{	

/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <returns>Objeto ArchivoPagoProveedoresResult con información del resultado de la operación</returns>
		ListadoArchivoPagoProveedoresResult ObtenerArchivoPagoProveedoress();
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <returns>Objeto ArchivoPagoProveedoresResult con información del resultado de la operación</returns>
		ListadoArchivoPagoProveedoresResult BuscarArchivoPagoProveedoress();
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <returns>Objeto ArchivoPagoProveedoresResult con información del resultado de la operación</returns>
        ArchivoPagoProveedoresResult ObtenerArchivoPagoProveedores(int numeroArchivo);
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="archivoPagoProveedoresRequest"></param>
        /// <returns>Objeto ArchivoPagoProveedoresResult con información del resultado de la operación</returns>
        ArchivoPagoProveedoresResult CrearArchivoPagoProveedores(ArchivoPagoProveedoresRequest archivoPagoProveedoresRequest);
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="archivoPagoProveedoresModel"></param>
		/// <returns>Objeto ArchivoPagoProveedoresResult con información del resultado de la operación</returns>
		public ArchivoPagoProveedoresResult ActualizarArchivoPagoProveedores(ArchivoPagoProveedoresRequest archivoPagoProveedoresRequest);
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="archivoPagoProveedoresModel"></param>
		/// <returns>Objeto ArchivoPagoProveedoresResult con información del resultado de la operación</returns>
		ArchivoPagoProveedoresResult EliminarArchivoPagoProveedores();
	}
}

