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

namespace Cl.Intertrade.ActivPay.Result.Transferencia
{
    /// <summary>
    /// Esta Clase TransferenciaResult  Representa objeto para la salida json
    /// </summary>
    public partial class ListadoTransferenciaResult
    {
        public IList<TransferenciaResult> Transferencias { get; set; }
        public int StatusCode { get; set; }
    }

    /// <summary>
    /// Esta Clase TransferenciaResult  Representa objeto para la salida json
    /// </summary>
    public partial class TransferenciaResult
    {
        [JsonPropertyName("transferenciaId")]
        public int TransferenciaId { get; set; }
        [JsonPropertyName("totalTransferencia")]
        public decimal TotalTransferencia { get; set; }
        [JsonPropertyName("costoComision")]
        public decimal CostoComision { get; set; }
        [JsonPropertyName("fechaTransferencia")]
        public DateTime FechaTransferencia { get; set; }

        [JsonPropertyName("numeroPagos")]
        public int NumeroPagos { get; set; }
        [JsonPropertyName("codigoConvenio")]
        public int CodigoConvenio { get; set; }

        [JsonPropertyName("numeroCuenta")]
        public int NumeroCuenta { get; set; }
        [JsonPropertyName("tipoCuenta")]
        public string TipoCuenta { get; set; }
        [JsonPropertyName("banco")]
        public string Banco { get; set; }

        [JsonPropertyName("emailNotificacion")]
        public string EmailNotificacion { get; set; }

        [JsonPropertyName("estado")]
        public string Estado { get; set; }

        [JsonPropertyName("montoTransferencia")]
        public decimal MontoTransferencia { get; set; }


        [JsonPropertyName("fechaDesde")]
        public DateTime FechaDesde { get; set; }

        [JsonPropertyName("fechaHasta")]
        public DateTime FechaHast { get; set; }

        public int StatusCode { get; set; }

        public List<string> Errores { get; set; }
    }
}

