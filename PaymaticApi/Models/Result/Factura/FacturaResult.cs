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

namespace Cl.Intertrade.ActivPay.Result.Factura
{
    /// <summary>
    /// Esta Clase FacturaResult  Representa objeto para la salida json
    /// </summary>
    public partial class ListadoFacturaResult
    {
        public IList<FacturaResult> Facturas { get; set; }
        public int StatusCode { get; set; }
    }

    /// <summary>
    /// Esta Clase FacturaResult  Representa objeto para la salida json
    /// </summary>
    public partial class FacturaResult
    {
        [JsonPropertyName("numeroFactura")]
        public int NumeroFactura { get; set; }
        [JsonPropertyName("fechaCreacion")]
        public DateTime FechaCreacion { get; set; }
        [JsonPropertyName("montoNeto")]
        public decimal MontoNeto { get; set; }
        [JsonPropertyName("iva")]
        public decimal Iva { get; set; }
        [JsonPropertyName("montoTotal")]
        public decimal MontoTotal { get; set; }
        [JsonPropertyName("totalComisiones")]
        public decimal TotalComisiones { get; set; }
        [JsonPropertyName("rutRazonSocial")]
        public int RutRazonSocial { get; set; }
        [JsonPropertyName("estado")]
        public string Estado { get; set; }

        [JsonPropertyName("codigoEdificio")]
        public string CodigoEdificio { get; set; }

        [JsonPropertyName("nombreEdificio")]
        public string NombreEdificio { get; set; }

        [JsonPropertyName("errores")]
        public List<string> Errores { get; set; }

        [JsonPropertyName("pdfNotaCredito")]
        public byte [] PdfNotaCredito { get; set; }
        [JsonPropertyName("base64NotaCredito")]
        public string Base64NotaCredito { get; set; }
        public int StatusCode { get; set; }
    }
}

