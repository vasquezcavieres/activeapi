





/**
* (c)2013-2023 CodeBase Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*25-10-2023,Generador de Código, Clase Inicial 
*/

	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	namespace Cl.Intertrade.ActivPay.Entities.DetalleFactura
	{
		/// <summary>
		/// Esta Clase DetalleFacturaModel  Representa el objeto de persistencia para la tabla DetalleFactura
		/// </summary>
		public partial class DetalleFacturaModel
		{	
			public int NumeroFactura { get; set; }
			public int TransferenciaId { get; set; }
			public decimal TotalTransferencia { get; set; }
			public decimal CostoComision { get; set; }
			public decimal MontoTransferencia { get; set; }
			public DateTime? FechaTransferencia { get; set; }
			/// <summary>
			/// Constructor de la Clase DetalleFacturaTo
			/// </summary>
			public DetalleFacturaModel() {
 		NumeroFactura = 0; 
			TransferenciaId = 0; 
			TotalTransferencia = 0; 
			CostoComision = 0; 
			MontoTransferencia = 0; 
			FechaTransferencia = new DateTime(1900,1,1); 
			}
		}
	}

