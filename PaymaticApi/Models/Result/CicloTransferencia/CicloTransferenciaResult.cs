





/**
* (c)2019-2023 NEGS Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*13-09-2023,Generador de Código, Clase Inicial 
*/

    using System;
	using System.Collections.Generic;
	using System.Text.Json.Serialization;

	namespace Cl.Intertrade.ActivPay.Result.CicloTransferencia
	{
	/// <summary>
		/// Esta Clase CicloTransferenciaResult  Representa objeto para la salida json
		/// </summary>
		public partial class ListadoCicloTransferenciaResult
		{	
			public IList<CicloTransferenciaResult> CicloTransferencias { get; set; }
			public int StatusCode { get; set; }
		}

		/// <summary>
		/// Esta Clase CicloTransferenciaResult  Representa objeto para la salida json
		/// </summary>
		public partial class CicloTransferenciaResult
		{
            [JsonPropertyName("codigoConvenio")]
            public int CodigoConvenio { get; set; }
            [JsonPropertyName("creadoPor")]
			public string CreadoPor { get; set; }
			[JsonPropertyName("fechaCreacion")]
			public DateTime FechaCreacion { get; set; }
			[JsonPropertyName("DiasTransferencia")]
			public string DiasTransferencia { get; set; }
			[JsonPropertyName("actualizadoPor")]
			public string ActualizadoPor { get; set; }
			[JsonPropertyName("fechaActualizacion")]
			public DateTime FechaActualizacion { get; set; }
			public int StatusCode { get; set; }

            public List<string> DiasTrasnferencias { get; set; }
		}
	}

