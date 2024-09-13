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
	using System.ComponentModel.DataAnnotations;
	using System.Text.Json.Serialization;

namespace Cl.Intertrade.ActivPay.Request.Factura
{
    /// <summary>
    /// Esta Clase FacturaRequest define la estructura para las llamadas a la api
    /// </summary>
    public partial class FacturaRequest
    {
       
        [JsonPropertyName("numeroFactura")]
        public int NumeroFactura { get; set; }
        [JsonPropertyName("fechaCreacion")]
        public DateTime? FechaCreacion { get; set; }
        [JsonPropertyName("montoNeto")]
        public int? MontoNeto { get; set; }
        [JsonPropertyName("iva")]
        public int? Iva { get; set; }
        [JsonPropertyName("montoTotal")]
        public int? MontoTotal { get; set; }
        [JsonPropertyName("rutRazonSocial")]
        public int? RutRazonSocial { get; set; }
        [MaxLength(50, ErrorMessage = "El campo Estado tiene un largo máximo de 50 caracteres")]
        [JsonPropertyName("estado")]
        public string Estado { get; set; }

        [JsonPropertyName("codigoEdificio")]
        public string CodigoEdificio { get; set; }

        [JsonPropertyName("fechaDesde")]
        public DateTime? FechaDesde { get; set; }

        [JsonPropertyName("fechaHasta")]
        public DateTime? FechaHasta { get; set; }


        [JsonPropertyName("numeroNotaCredito")]
        public int NumeroNotaCredito { get; set; }
    }
}

