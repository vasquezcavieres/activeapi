






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


using Cl.Intertrade.ActivPay.Request.Banco;
using Cl.Intertrade.ActivPay.Result.Banco;
using System.Collections.Generic;
using System;

namespace Cl.Intertrade.ActivPay.Data.Banco
{
	/// <summary>
	/// Esta Clase Banco  permite gestionar la interacción con la base de datos para la tabla Banco
	/// </summary>
	public interface IBancoService
	{	

/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <returns>Objeto BancoResult con información del resultado de la operación</returns>
		ListadoBancoResult ObtenerBancos();
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <returns>Objeto BancoResult con información del resultado de la operación</returns>
		ListadoBancoResult BuscarBancos();
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <returns>Objeto BancoResult con información del resultado de la operación</returns>
		BancoResult ObtenerBanco();

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="bancoRequest"></param>
		/// <returns>Objeto BancoResult con información del resultado de la operación</returns>
		BancoResult CrearBanco(BancoRequest bancoRequest);
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="bancoModel"></param>
		/// <returns>Objeto BancoResult con información del resultado de la operación</returns>
		public BancoResult ActualizarBanco(BancoRequest bancoRequest);
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="bancoModel"></param>
		/// <returns>Objeto BancoResult con información del resultado de la operación</returns>
		BancoResult EliminarBanco();
	}
}

