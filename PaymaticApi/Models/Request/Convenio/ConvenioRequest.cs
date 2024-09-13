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

namespace Cl.Intertrade.ActivPay.Request.Convenio
{
    /// <summary>
    /// Esta Clase ConvenioRequest define la estructura para las llamadas a la api
    /// </summary>
    public partial class ConvenioRequest
    {
        [JsonPropertyName("codigoConvenio")]
        public int CodigoConvenio { get; set; }
        [Required(ErrorMessage = "El campo Rut Razon Social es obligatorio")]
        [JsonPropertyName("rutRazonSocial")]
        public int RutRazonSocial { get; set; }
        [MaxLength(1, ErrorMessage = "El campo Rut Razon Social Dv tiene un largo máximo de 1 caracteres")]
        [JsonPropertyName("rutRazonSocialDv")]
        public string RutRazonSocialDv { get; set; }
        [MaxLength(500, ErrorMessage = "El campo Nombrerazon Social tiene un largo máximo de 500 caracteres")]
        [JsonPropertyName("nombrerazonSocial")]
        public string NombrerazonSocial { get; set; }
        [MaxLength(500, ErrorMessage = "El campo Nombre Administradora tiene un largo máximo de 500 caracteres")]
        [JsonPropertyName("nombreAdministradora")]
        public string NombreAdministradora { get; set; }
        [MaxLength(100, ErrorMessage = "El campo Direccion tiene un largo máximo de 100 caracteres")]
        [JsonPropertyName("direccion")]
        public string Direccion { get; set; }
        [MaxLength(100, ErrorMessage = "El campo Comuna tiene un largo máximo de 100 caracteres")]
        [JsonPropertyName("comuna")]
        public string Comuna { get; set; }
        [MaxLength(100, ErrorMessage = "El campo Region tiene un largo máximo de 100 caracteres")]
        [JsonPropertyName("region")]
        public string Region { get; set; }
        [MaxLength(100, ErrorMessage = "El campo Representante Legal tiene un largo máximo de 100 caracteres")]
        [JsonPropertyName("representanteLegal")]
        public string RepresentanteLegal { get; set; }
        [JsonPropertyName("rutRepresentanteLegal")]
        public int? RutRepresentanteLegal { get; set; }
        [MaxLength(1, ErrorMessage = "El campo Rut Representante Legal Dv tiene un largo máximo de 1 caracteres")]
        [JsonPropertyName("rutRepresentanteLegalDv")]
        public string RutRepresentanteLegalDv { get; set; }
        [JsonPropertyName("numeroCuenta")]
        public int? NumeroCuenta { get; set; }
        [MaxLength(100, ErrorMessage = "El campo Tipo Cuenta tiene un largo máximo de 100 caracteres")]
        [JsonPropertyName("tipoCuenta")]
        public string TipoCuenta { get; set; }
        [MaxLength(100, ErrorMessage = "El campo Banco tiene un largo máximo de 100 caracteres")]
        [JsonPropertyName("banco")]
        public string Banco { get; set; }
        [MaxLength(500, ErrorMessage = "El campo Correo Contacto tiene un largo máximo de 500 caracteres")]
        [JsonPropertyName("correoContacto")]
        public string CorreoContacto { get; set; }
        [JsonPropertyName("vendedorId")]
        public int? VendedorId { get; set; }
        [JsonPropertyName("porcentajeComision")]
        public double? PorcentajeComision { get; set; }
        [MaxLength(500, ErrorMessage = "El campo Email Notificacion tiene un largo máximo de 500 caracteres")]
        [JsonPropertyName("emailNotificacion")]
        public string EmailNotificacion { get; set; }

        [JsonPropertyName("rutAdministrador")]
        public int RutAdministrador { get; set; }

        [JsonPropertyName("minimoGarantizadoComision")]
        public decimal MinimoGarantizadoComision { get; set; }
        [JsonPropertyName("giro")]
        public string Giro { get; set; }
    }
}

