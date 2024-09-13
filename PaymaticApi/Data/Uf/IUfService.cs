






/**
* (c)2013-2023 CodeBase Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*13-12-2023,Generador de Código, Clase Inicial 
*/


using Cl.Intertrade.ActivPay.Request.Uf;
using Cl.Intertrade.ActivPay.Result.Uf;
using System.Collections.Generic;
using System;

namespace Cl.Intertrade.ActivPay.Data.Uf
{
	/// <summary>
	/// Esta Clase Uf  permite gestionar la interacción con la base de datos para la tabla Uf
	/// </summary>
	public interface IUfService
	{	

/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <returns>Objeto UfResult con información del resultado de la operación</returns>
		ListadoUfResult ObtenerUfs();
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="fechaUf"></param>
/// <returns>Objeto UfResult con información del resultado de la operación</returns>
		ListadoUfResult BuscarUfs(DateTime fechaUf);
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="fechaUf"></param>
/// <returns>Objeto UfResult con información del resultado de la operación</returns>
		UfResult ObtenerUf(DateTime fechaUf);

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="ufRequest"></param>
		/// <returns>Objeto UfResult con información del resultado de la operación</returns>
		UfResult CrearUf(UfRequest ufRequest);
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="ufModel"></param>
		/// <returns>Objeto UfResult con información del resultado de la operación</returns>
		public UfResult ActualizarUf(UfRequest ufRequest);
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="ufModel"></param>
		/// <returns>Objeto UfResult con información del resultado de la operación</returns>
		UfResult EliminarUf(DateTime fechaUf);
	}
}

