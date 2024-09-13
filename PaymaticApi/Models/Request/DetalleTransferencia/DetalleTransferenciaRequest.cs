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

namespace Cl.Intertrade.ActivPay.Request.DetalleTransferencia
{
    /// <summary>
    /// Esta Clase DetalleTransferenciaRequest define la estructura para las llamadas a la api
    /// </summary>
    public partial class DetalleTransferenciaRequest
    {
        [Required(ErrorMessage = "El campo Transferencia Id es obligatorio")]
        [JsonPropertyName("transferenciaId")]
        public int TransferenciaId { get; set; }

        [Required(ErrorMessage = "El campo Rut Razon Social es obligatorio")]
        [JsonPropertyName("rutRazonSocial")]
        public int RutRazonSocial { get; set; }

        [JsonPropertyName("montoTransferencia")]
        public decimal MontoTransferencia { get; set; }

        [JsonPropertyName("costoComision")]
        public decimal CostoComision { get; set; }

        [JsonPropertyName("fechaTransferencia")]
        public DateTime FechaTransferencia { get; set; }
    }
}
