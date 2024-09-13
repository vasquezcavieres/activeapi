





/**
* (c)2019-2023 NEGS Todos los Derechos Reservados.
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
	using System.Text.Json.Serialization;

	namespace Cl.Intertrade.ActivPay.Result.Uf
	{
	/// <summary>
		/// Esta Clase UfResult  Representa objeto para la salida json
		/// </summary>
		public partial class ListadoUfResult
		{	
			public IList<UfResult> Ufs { get; set; }
            public List<string> Errores { get; set; }
			public int StatusCode { get; set; }
		}

		/// <summary>
		/// Esta Clase UfResult  Representa objeto para la salida json
		/// </summary>
		public partial class UfResult
		{	
			[JsonPropertyName("fechaUf")]
			public DateTime FechaUf { get; set; }
			[JsonPropertyName("valor")]
			public decimal Valor { get; set; }
        public List<string> Errores { get; set; }
        public int StatusCode { get; set; }
		}
	}

