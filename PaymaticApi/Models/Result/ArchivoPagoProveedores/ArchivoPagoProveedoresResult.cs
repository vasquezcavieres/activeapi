





/**
* (c)2019-2023 NEGS Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*14-11-2023,Generador de Código, Clase Inicial 
*/

    using System;
	using System.Collections.Generic;
	using System.Text.Json.Serialization;

	namespace Cl.Intertrade.ActivPayApi.Result.ArchivoPagoProveedores
	{
	/// <summary>
		/// Esta Clase ArchivoPagoProveedoresResult  Representa objeto para la salida json
		/// </summary>
		public partial class ListadoArchivoPagoProveedoresResult
		{	
			public IList<ArchivoPagoProveedoresResult> ArchivoPagoProveedoress { get; set; }
			public int StatusCode { get; set; }
		}

		/// <summary>
		/// Esta Clase ArchivoPagoProveedoresResult  Representa objeto para la salida json
		/// </summary>
		public partial class ArchivoPagoProveedoresResult
		{	
			[JsonPropertyName("numeroArchivo")]
			public int NumeroArchivo { get; set; }
			[JsonPropertyName("nombreArchivo")]
			public string NombreArchivo { get; set; }
			[JsonPropertyName("numeroTransferencias")]
			public int NumeroTransferencias { get; set; }
			[JsonPropertyName("fechaCreacion")]
			public DateTime FechaCreacion { get; set; }
			[JsonPropertyName("rutaArchivo")]
			public string RutaArchivo { get; set; }
			public int StatusCode { get; set; }
		}
	}

