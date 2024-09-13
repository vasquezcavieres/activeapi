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

namespace Cl.Intertrade.ActivPay.Result.Convenio
{
    /// <summary>
    /// Esta Clase ConvenioResult  Representa objeto para la salida json
    /// </summary>
    public partial class ListadoConvenioResult
    {
        public IList<ConvenioResult> Convenios { get; set; }
        public int StatusCode { get; set; }
    }

    /// <summary>
    /// Esta Clase ConvenioResult  Representa objeto para la salida json
    /// </summary>
    public partial class ConvenioResult
    {
        [JsonPropertyName("rutRazonSocial")]
        public int RutRazonSocial { get; set; }
        [JsonPropertyName("rutRazonSocialDv")]
        public char RutRazonSocialDv { get; set; }
        [JsonPropertyName("nombrerazonSocial")]
        public string NombrerazonSocial { get; set; }
        [JsonPropertyName("nombreAdministradora")]
        public string NombreAdministradora { get; set; }
        [JsonPropertyName("direccion")]
        public string Direccion { get; set; }
        [JsonPropertyName("comuna")]
        public string Comuna { get; set; }
        [JsonPropertyName("region")]
        public string Region { get; set; }
        [JsonPropertyName("representanteLegal")]
        public string RepresentanteLegal { get; set; }
        [JsonPropertyName("rutRepresentanteLegal")]
        public int RutRepresentanteLegal { get; set; }
        [JsonPropertyName("rutRepresentanteLegalDv")]
        public string RutRepresentanteLegalDv { get; set; }
        [JsonPropertyName("numeroCuenta")]
        public int NumeroCuenta { get; set; }
        [JsonPropertyName("tipoCuenta")]
        public string TipoCuenta { get; set; }
        [JsonPropertyName("banco")]
        public string Banco { get; set; }
        [JsonPropertyName("correoContacto")]
        public string CorreoContacto { get; set; }
        [JsonPropertyName("vendedorId")]
        public int VendedorId { get; set; }
        [JsonPropertyName("porcentajeComision")]
        public double PorcentajeComision { get; set; }
        [JsonPropertyName("emailNotificacion")]
        public string EmailNotificacion { get; set; }

        [JsonPropertyName("rutAdministrador")]
        public int RutAdministrador { get; set; }

        [JsonPropertyName("minimoGarantizadoComision")]
        public decimal MinimoGarantizadoComision { get; set; }

        [JsonPropertyName("giro")]
        public string Giro { get; set; }
        public int StatusCode { get; set; }
    }
}

