





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

	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
namespace Cl.Intertrade.ActivPay.Entities.Uf
{
	/// <summary>
	/// Esta Clase UfModel  Representa el objeto de persistencia para la tabla Uf
	/// </summary>
	public partial class UfModel
	{
		public DateTime FechaUf { get; set; }
		public decimal Valor { get; set; }
		/// <summary>
		/// Constructor de la Clase UfTo
		/// </summary>
		public UfModel()
		{
			FechaUf = new DateTime(1900, 1, 1);
			Valor = 0;
		}
	}
}

