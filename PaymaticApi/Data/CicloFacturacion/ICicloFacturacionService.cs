






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


using Cl.Intertrade.ActivPay.Request.CicloTransferencia;
using Cl.Intertrade.ActivPay.Result.CicloTransferencia;
using System.Collections.Generic;
using System;

namespace Cl.Intertrade.ActivPay.Data.CicloTransferencia
{
	/// <summary>
	/// Esta Clase CicloTransferencia  permite gestionar la interacción con la base de datos para la tabla CicloTransferencia
	/// </summary>
	public interface ICicloTransferenciaService
	{	

/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <returns>Objeto CicloTransferenciaResult con información del resultado de la operación</returns>
		ListadoCicloTransferenciaResult ObtenerCicloTransferencias();
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="creadoPor"></param>
/// <returns>Objeto CicloTransferenciaResult con información del resultado de la operación</returns>
		ListadoCicloTransferenciaResult BuscarCicloTransferencias(string creadoPor);
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="creadoPor"></param>
/// <returns>Objeto CicloTransferenciaResult con información del resultado de la operación</returns>
		CicloTransferenciaResult ObtenerCicloTransferencia(string creadoPor);

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="CicloTransferenciaRequest"></param>
		/// <returns>Objeto CicloTransferenciaResult con información del resultado de la operación</returns>
		CicloTransferenciaResult CrearCicloTransferencia(CicloTransferenciaRequest CicloTransferenciaRequest);
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="CicloTransferenciaModel"></param>
		/// <returns>Objeto CicloTransferenciaResult con información del resultado de la operación</returns>
		public CicloTransferenciaResult ActualizarCicloTransferencia(CicloTransferenciaRequest CicloTransferenciaRequest);
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="CicloTransferenciaModel"></param>
		/// <returns>Objeto CicloTransferenciaResult con información del resultado de la operación</returns>
		CicloTransferenciaResult EliminarCicloTransferencia(string creadoPor);
	}
}

