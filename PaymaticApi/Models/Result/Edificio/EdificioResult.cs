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

namespace Cl.Intertrade.ActivPay.Result.Edificio
{
    /// <summary>
    /// Esta Clase EdificioResult  Representa objeto para la salida json
    /// </summary>
    public partial class ListadoEdificioResult
    {
        public IList<EdificioResult> Edificios { get; set; }
        public int StatusCode { get; set; }
    }

    /// <summary>
    /// Esta Clase EdificioResult  Representa objeto para la salida json
    /// </summary>
    public partial class EdificioResult
    {
        [JsonPropertyName("codigoEdificio")]
        public string CodigoEdificio { get; set; }
        [JsonPropertyName("codigoArea")]
        public string CodigoArea { get; set; }
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }
        [JsonPropertyName("codigoPais")]
        public string CodigoPais { get; set; }
        [JsonPropertyName("pais")]
        public string Pais { get; set; }
        [JsonPropertyName("direccion")]
        public string Direccion { get; set; }
        [JsonPropertyName("ciudad")]
        public string Ciudad { get; set; }
        [JsonPropertyName("comuna")]
        public string Comuna { get; set; }
        [JsonPropertyName("centroCosto")]
        public string CentroCosto { get; set; }
        [JsonPropertyName("rutRazonSocial")]
        public int RutRazonSocial { get; set; }

        [JsonPropertyName("ventas")]
        public decimal Ventas { get; set; }

        [JsonPropertyName("comisiones")]
        public decimal Comisiones { get; set; }

        [JsonPropertyName("montoTransferir")]
        public decimal MontoTransferir { get; set; }
        [JsonPropertyName("maquinasInstaladas")]
        public int MaquinasInstaladas { get; set; }

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

        [JsonPropertyName("minimoGarantizadoComision")]
        public decimal MinimoGarantizadoComision { get; set; }
        [JsonPropertyName("giro")]
        public string Giro { get; set; }

        [JsonPropertyName("porcentajeComision")]
        public double? PorcentajeComision { get; set; }

        [JsonPropertyName("codigoTipoAbono")]
        public string CodigoTipoAbono { get; set; }
        
        [JsonPropertyName("codigoBanco")]
        public string CodigoBanco { get; set; }

        public int StatusCode { get; set; }
    }
}

