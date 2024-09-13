





/**
* (c)2019-2023 NEGS Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*27-09-2023,Generador de Código, Clase Inicial 
*/

    using System;
	using System.Collections.Generic;
	using System.Text.Json.Serialization;

namespace Cl.Intertrade.ActivPay.Result.Pago
{
    /// <summary>
    /// Esta Clase PagoResult  Representa objeto para la salida json
    /// </summary>
    public partial class ListadoPagoResult
    {
        public IList<PagoResult> Pagos { get; set; }
        public int StatusCode { get; set; }
    }

    /// <summary>
    /// Esta Clase PagoResult  Representa objeto para la salida json
    /// </summary>
    public partial class PagoResult
    {
        [JsonPropertyName("pagoId")]
        public string PagoId { get; set; }
        [JsonPropertyName("vendedorId")]
        public string VendedorId { get; set; }
        [JsonPropertyName("nombreVendedor")]
        public string NombreVendedor { get; set; }
        [JsonPropertyName("tokenTransaccion")]
        public string TokenTransaccion { get; set; }
        [JsonPropertyName("tokenMedioPago")]
        public string TokenMedioPago { get; set; }
        [JsonPropertyName("codigoMedioPago")]
        public string CodigoMedioPago { get; set; }
        [JsonPropertyName("numeroOrden")]
        public decimal NumeroOrden { get; set; }
        [JsonPropertyName("emailCliente")]
        public string EmailCliente { get; set; }
        [JsonPropertyName("nombreCliente")]
        public string NombreCliente { get; set; }
        [JsonPropertyName("montoPago")]
        public decimal MontoPago { get; set; }
        [JsonPropertyName("fechaTransaccion")]
        public DateTime FechaTransaccion { get; set; }
        [JsonPropertyName("codigoEdificio")]
        public string CodigoEdificio { get; set; }
        [JsonPropertyName("codigoArea")]
        public string CodigoArea { get; set; }
        [JsonPropertyName("nombreEdificio")]
        public string NombreEdificio { get; set; }
        [JsonPropertyName("direccionEdificio")]
        public string DireccionEdificio { get; set; }
        [JsonPropertyName("ciudadEdificio")]
        public string CiudadEdificio { get; set; }
        [JsonPropertyName("comunaEdificio")]
        public string ComunaEdificio { get; set; }
        [JsonPropertyName("centroCosto")]
        public string CentroCosto { get; set; }
        [JsonPropertyName("exitoso")]
        public bool Exitoso { get; set; }
        [JsonPropertyName("codigoAutorizacion")]
        public string CodigoAutorizacion { get; set; }
        [JsonPropertyName("fechaPago")]
        public DateTime FechaPago { get; set; }
        [JsonPropertyName("mesPago")]
        public int MesPago { get; set; }
        [JsonPropertyName("anioPago")]
        public int AnioPago { get; set; }
        [JsonPropertyName("numeroTarjeta")]
        public string NumeroTarjeta { get; set; }
        [JsonPropertyName("notificado")]
        public bool Notificado { get; set; }
        [JsonPropertyName("codigoNotificacion")]
        public string CodigoNotificacion { get; set; }
        [JsonPropertyName("numeroBoleta")]
        public string NumeroBoleta { get; set; }
        [JsonPropertyName("urlBoleta")]
        public string UrlBoleta { get; set; }
        [JsonPropertyName("fechaBoleta")]
        public DateTime FechaBoleta { get; set; }
        [JsonPropertyName("codigoPais")]
        public string CodigoPais { get; set; }
        [JsonPropertyName("pais")]
        public string Pais { get; set; }
        [JsonPropertyName("ultimoIntento")]
        public DateTime UltimoIntento { get; set; }
        [JsonPropertyName("boletaAux")]
        public string BoletaAux { get; set; }
        [JsonPropertyName("firma")]
        public string Firma { get; set; }

        [JsonPropertyName("fechaDesde")]
        public DateTime FechaDesde { get; set; }
        [JsonPropertyName("fechaHasta")]
        public DateTime FechaHasta { get; set; }
        [JsonPropertyName("codigoConvenio")]
        public int CodigoConvenio { get; set; }
        public int StatusCode { get; set; }


    }
}

