





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

namespace Cl.Intertrade.ActivPay.Request.CicloTransferencia
{
    /// <summary>
    /// Esta Clase CicloTransferenciaRequest define la estructura para las llamadas a la api
    /// </summary>
    public partial class CicloTransferenciaRequest
    {
        public int CodigoConvenio { get; set; }
        [MaxLength(150, ErrorMessage = "El campo Creado Por tiene un largo máximo de 150 caracteres")]
        [Required(ErrorMessage = "El campo Creado Por es obligatorio")]
        [JsonPropertyName("creadoPor")]
        public string CreadoPor { get; set; }
        [JsonPropertyName("fechaCreacion")]
        public DateTime? FechaCreacion { get; set; }
        [JsonPropertyName("DiasTransferencia")]
        public string DiasTransferencia { get; set; }
        [MaxLength(150, ErrorMessage = "El campo Actualizado Por tiene un largo máximo de 150 caracteres")]
        [JsonPropertyName("actualizadoPor")]
        public string ActualizadoPor { get; set; }
        [JsonPropertyName("fechaActualizacion")]
        public DateTime? FechaActualizacion { get; set; }

        public List<string> DiasTrasnferencias { get; set; }
    }
}

