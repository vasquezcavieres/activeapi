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

namespace Cl.Intertrade.ActivPay.Request.Transferencia
{
    /// <summary>
    /// Esta Clase TransferenciaRequest define la estructura para las llamadas a la api
    /// </summary>
    public partial class TransferenciaRequest
    {
        [Required(ErrorMessage = "El campo Transferencia Id es obligatorio")]
        [JsonPropertyName("transferenciaId")]
        public int TransferenciaId { get; set; }
        [JsonPropertyName("totalTransferencia")]
        public int TotalTransferencia { get; set; }
        [JsonPropertyName("costoComision")]
        public int CostoComision { get; set; }
        [JsonPropertyName("fechaTransferencia")]
        public DateTime FechaTransferencia { get; set; }

        [JsonPropertyName("numeroPagos")]
        public int NumeroPagos { get; set; }

        [JsonPropertyName("codigoConvenio")]
        public int CodigoConvenio { get; set; }

        [JsonPropertyName("numeroCuenta")]
        public int NumeroCuenta { get; set; }

        [MaxLength(50, ErrorMessage = "El campo Tipo Cuenta tiene un largo máximo de 50 caracteres")]
        [JsonPropertyName("tipoCuenta")]
        public string TipoCuenta { get; set; }
        [MaxLength(50, ErrorMessage = "El campo Banco tiene un largo máximo de 50 caracteres")]
        [JsonPropertyName("banco")]
        public string Banco { get; set; }

        [JsonPropertyName("emailNotificacion")]
        public string EmailNotificacion { get; set; }

        [MaxLength(50, ErrorMessage = "El campo Estado tiene un largo máximo de 50 caracteres")]
        [JsonPropertyName("estado")]
        public string Estado { get; set; }

        [JsonPropertyName("codigoEdificio")]
        public string CodigoEdificio { get; set; }

        [JsonPropertyName("fechaDesde")]
        public DateTime FechaDesde { get; set; }

        [JsonPropertyName("fechaHasta")]
        public DateTime FechaHast { get; set; }
    }
}

