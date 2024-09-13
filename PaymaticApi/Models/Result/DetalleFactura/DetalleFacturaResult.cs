





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
	using System.Text.Json.Serialization;

	namespace Cl.Intertrade.ActivPay.Result.DetalleFactura
	{
	/// <summary>
		/// Esta Clase DetalleFacturaResult  Representa objeto para la salida json
		/// </summary>
		public partial class ListadoDetalleFacturaResult
		{	
			public IList<DetalleFacturaResult> DetalleFacturas { get; set; }
			public int StatusCode { get; set; }
		}

		/// <summary>
		/// Esta Clase DetalleFacturaResult  Representa objeto para la salida json
		/// </summary>
		public partial class DetalleFacturaResult
		{	
			[JsonPropertyName("numeroFactura")]
			public int NumeroFactura { get; set; }
			[JsonPropertyName("transferenciaId")]
			public int TransferenciaId { get; set; }
			[JsonPropertyName("totalTransferencia")]
			public decimal TotalTransferencia { get; set; }
			[JsonPropertyName("costoComision")]
			public decimal CostoComision { get; set; }
			[JsonPropertyName("montoTransferencia")]
			public decimal MontoTransferencia { get; set; }
			[JsonPropertyName("fechaTransferencia")]
			public DateTime FechaTransferencia { get; set; }
			public int StatusCode { get; set; }
		}
	}

