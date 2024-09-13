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

namespace Cl.Intertrade.ActivPay.Request.Edificio
{
    /// <summary>
    /// Esta Clase EdificioRequest define la estructura para las llamadas a la api
    /// </summary>
    public partial class EdificioRequest
    {
        [MaxLength(50, ErrorMessage = "El campo Codigo Edificio tiene un largo máximo de 50 caracteres")]
        [Required(ErrorMessage = "El campo Codigo Edificio es obligatorio")]
        [JsonPropertyName("codigoEdificio")]
        public string CodigoEdificio { get; set; }
        [MaxLength(50, ErrorMessage = "El campo Codigo Area tiene un largo máximo de 50 caracteres")]
        [JsonPropertyName("codigoArea")]
        public string CodigoArea { get; set; }
        [MaxLength(100, ErrorMessage = "El campo Nombre tiene un largo máximo de 100 caracteres")]
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }
        [MaxLength(4, ErrorMessage = "El campo Codigo Pais tiene un largo máximo de 4 caracteres")]
        [JsonPropertyName("codigoPais")]
        public string CodigoPais { get; set; }
        [MaxLength(50, ErrorMessage = "El campo Pais tiene un largo máximo de 50 caracteres")]
        [JsonPropertyName("pais")]
        public string Pais { get; set; }
        [MaxLength(100, ErrorMessage = "El campo Direccion tiene un largo máximo de 100 caracteres")]
        [Required(ErrorMessage = "El campo Direccion es obligatorio")]
        [JsonPropertyName("direccion")]
        public string Direccion { get; set; }
        [MaxLength(50, ErrorMessage = "El campo Ciudad tiene un largo máximo de 50 caracteres")]
        [JsonPropertyName("ciudad")]
        public string Ciudad { get; set; }
        [MaxLength(50, ErrorMessage = "El campo Comuna tiene un largo máximo de 50 caracteres")]
        [JsonPropertyName("comuna")]
        public string Comuna { get; set; }
        [MaxLength(50, ErrorMessage = "El campo Centro Costo tiene un largo máximo de 50 caracteres")]
        [Required(ErrorMessage = "El campo Centro Costo es obligatorio")]
        [JsonPropertyName("centroCosto")]
        public string CentroCosto { get; set; }
        [JsonPropertyName("rutRazonSocial")]
        public int RutRazonSocial { get; set; }

        [JsonPropertyName("numeroCuenta")]
        public int NumeroCuenta { get; set; }
        [JsonPropertyName("tipoCuenta")]
        public string TipoCuenta { get; set; }
        [JsonPropertyName("banco")]
        public string Banco { get; set; }
        [JsonPropertyName("correoContacto")]
        public string CorreoContacto { get; set; }

        [JsonPropertyName("emailNotificacion")]
        public string EmailNotificacion { get; set; }

        [JsonPropertyName("maquinasInstaladas")]
        public int MaquinasInstaladas { get; set; }


        [JsonPropertyName("minimoGarantizadoComision")]
        public decimal MinimoGarantizadoComision { get; set; }
        [JsonPropertyName("giro")]
        public string Giro { get; set; }

        [JsonPropertyName("porcentajeComision")]
        public double? PorcentajeComision { get; set; }

        [JsonPropertyName("fechaDesde")]
        public DateTime? FechaDesde { get; set; }

        [JsonPropertyName("fechaHasta")]
        public DateTime? FechaHasta { get; set; }
    }
}

