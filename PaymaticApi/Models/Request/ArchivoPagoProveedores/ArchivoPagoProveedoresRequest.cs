





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
	using System.ComponentModel.DataAnnotations;
	using System.Text.Json.Serialization;

	namespace Cl.Intertrade.ActivPayApi.Request.ArchivoPagoProveedores
	{
		/// <summary>
		/// Esta Clase ArchivoPagoProveedoresRequest define la estructura para las llamadas a la api
		/// </summary>
		public partial class ArchivoPagoProveedoresRequest
		{	
			[JsonPropertyName("numeroArchivo")]
			public int? NumeroArchivo { get; set; }
			[MaxLength(300, ErrorMessage ="El campo Nombre Archivo tiene un largo máximo de 300 caracteres")]
			[JsonPropertyName("nombreArchivo")]
			public string NombreArchivo { get; set; }
			[JsonPropertyName("numeroTransferencias")]
			public int? NumeroTransferencias { get; set; }
			[JsonPropertyName("fechaCreacion")]
			public DateTime? FechaCreacion { get; set; }
			[MaxLength(500, ErrorMessage ="El campo Ruta Archivo tiene un largo máximo de 500 caracteres")]
			[JsonPropertyName("rutaArchivo")]
			public string RutaArchivo { get; set; }
		}
	}

