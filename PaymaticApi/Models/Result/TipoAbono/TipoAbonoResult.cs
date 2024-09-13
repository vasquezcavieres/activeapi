/**
* (c)2019-2023 NEGS Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*11-12-2023,Generador de Código, Clase Inicial 
*/

    using System;
	using System.Collections.Generic;
	using System.Text.Json.Serialization;

	namespace Cl.Intertrade.ActivPay.Result.TipoAbono
	{
	/// <summary>
		/// Esta Clase TipoAbonoResult  Representa objeto para la salida json
		/// </summary>
		public partial class ListadoTipoAbonoResult
		{	
			public IList<TipoAbonoResult> TipoAbonos { get; set; }
			public int StatusCode { get; set; }
		}

		/// <summary>
		/// Esta Clase TipoAbonoResult  Representa objeto para la salida json
		/// </summary>
		public partial class TipoAbonoResult
		{	
			[JsonPropertyName("codigoTipoAbono")]
			public string CodigoTipoAbono { get; set; }
			[JsonPropertyName("nombre")]
			public string Nombre { get; set; }
			public int StatusCode { get; set; }
		}
	}

