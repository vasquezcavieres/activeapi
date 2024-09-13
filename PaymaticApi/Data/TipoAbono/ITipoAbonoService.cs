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


using Cl.Intertrade.ActivPay.Request.TipoAbono;
using Cl.Intertrade.ActivPay.Result.TipoAbono;
using System.Collections.Generic;
using System;

namespace Cl.Intertrade.ActivPay.Data.TipoAbono
{
	/// <summary>
	/// Esta Clase TipoAbono  permite gestionar la interacción con la base de datos para la tabla TipoAbono
	/// </summary>
	public interface ITipoAbonoService
	{	

/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <returns>Objeto TipoAbonoResult con información del resultado de la operación</returns>
		ListadoTipoAbonoResult ObtenerTipoAbonos();
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <returns>Objeto TipoAbonoResult con información del resultado de la operación</returns>
		ListadoTipoAbonoResult BuscarTipoAbonos();
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <returns>Objeto TipoAbonoResult con información del resultado de la operación</returns>
		TipoAbonoResult ObtenerTipoAbono();

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="tipoAbonoRequest"></param>
		/// <returns>Objeto TipoAbonoResult con información del resultado de la operación</returns>
		TipoAbonoResult CrearTipoAbono(TipoAbonoRequest tipoAbonoRequest);
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="tipoAbonoModel"></param>
		/// <returns>Objeto TipoAbonoResult con información del resultado de la operación</returns>
		public TipoAbonoResult ActualizarTipoAbono(TipoAbonoRequest tipoAbonoRequest);
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="tipoAbonoModel"></param>
		/// <returns>Objeto TipoAbonoResult con información del resultado de la operación</returns>
		TipoAbonoResult EliminarTipoAbono();
	}
}

