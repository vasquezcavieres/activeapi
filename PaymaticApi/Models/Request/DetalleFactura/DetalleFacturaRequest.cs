





/**
* (c)2019-2023 NEGS Todos los Derechos Reservados.
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
	using System.Text.Json.Serialization;

	namespace Cl.Intertrade.ActivPay.Request.DetalleFactura
	{
		/// <summary>
		/// Esta Clase DetalleFacturaRequest define la estructura para las llamadas a la api
		/// </summary>
		public partial class DetalleFacturaRequest
		{	
			[Required(ErrorMessage ="El campo Numero Factura es obligatorio")]
			[JsonPropertyName("numeroFactura")]
			public int NumeroFactura { get; set; }
			[Required(ErrorMessage ="El campo Transferencia Id es obligatorio")]
			[JsonPropertyName("transferenciaId")]
			public int TransferenciaId { get; set; }
			[JsonPropertyName("totalTransferencia")]
			public decimal? TotalTransferencia { get; set; }
			[JsonPropertyName("costoComision")]
			public decimal? CostoComision { get; set; }
			[JsonPropertyName("montoTransferencia")]
			public decimal? MontoTransferencia { get; set; }
			[JsonPropertyName("fechaTransferencia")]
			public DateTime? FechaTransferencia { get; set; }
		}
	}

