





/**
* (c)2013-2023 CodeBase Todos los Derechos Reservados.
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
	namespace Cl.Intertrade.ActivPayApi.Entities.ArchivoPagoProveedores
	{
		/// <summary>
		/// Esta Clase ArchivoPagoProveedoresModel  Representa el objeto de persistencia para la tabla ArchivoPagoProveedores
		/// </summary>
		public partial class ArchivoPagoProveedoresModel
		{	
			public int? NumeroArchivo { get; set; }
			public string NombreArchivo { get; set; }
			public int? NumeroTransferencias { get; set; }
			public DateTime? FechaCreacion { get; set; }
			public string RutaArchivo { get; set; }
			/// <summary>
			/// Constructor de la Clase ArchivoPagoProveedoresTo
			/// </summary>
			public ArchivoPagoProveedoresModel() {
 		NumeroArchivo = 0; 
			NombreArchivo = string.Empty; 
			NumeroTransferencias = 0; 
			FechaCreacion = new DateTime(1900,1,1); 
			RutaArchivo = string.Empty; 
			}
		}
	}

