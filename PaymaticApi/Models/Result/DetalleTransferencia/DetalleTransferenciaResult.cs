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

namespace Cl.Intertrade.ActivPay.Result.DetalleTransferencia
{
    /// <summary>
    /// Esta Clase DetalleTransferenciaResult  Representa objeto para la salida json
    /// </summary>
    public partial class ListadoDetalleTransferenciaResult
    {
        public IList<DetalleTransferenciaResult> DetalleTransferencias { get; set; }
        public int StatusCode { get; set; }
    }

    /// <summary>
    /// Esta Clase DetalleTransferenciaResult  Representa objeto para la salida json
    /// </summary>
    public partial class DetalleTransferenciaResult
    {
        [JsonPropertyName("transferenciaId")]
        public int TransferenciaId { get; set; }
        [JsonPropertyName("rutRazonSocial")]
        public int RutRazonSocial { get; set; }

        [JsonPropertyName("pagoId")]
        public string PagoId { get; set; }

        [JsonPropertyName("montoTransferencia")]
        public decimal MontoTransferencia { get; set; }

        [JsonPropertyName("costoComision")]
        public decimal CostoComision { get; set; }

        [JsonPropertyName("montoPago")]
        public decimal MontoPago { get; set; }
        public int StatusCode { get; set; }
    }
}
