





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
	using System.ComponentModel.DataAnnotations;
	using System.Text.Json.Serialization;

namespace Cl.Intertrade.ActivPay.Request.Pago
{
    /// <summary>
    /// Esta Clase PagoRequest define la estructura para las llamadas a la api
    /// </summary>
    public partial class PagoRequest
    {
        [MaxLength(50, ErrorMessage = "El campo Pago Id tiene un largo máximo de 50 caracteres")]
       
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
        [Required(ErrorMessage = "El campo Monto Pago es obligatorio")]
        [JsonPropertyName("montoPago")]
        public decimal MontoPago { get; set; }
        [Required(ErrorMessage = "El campo Fecha Transaccion es obligatorio")]
        [JsonPropertyName("fechaTransaccion")]
        public DateTime FechaTransaccion { get; set; }
        [MaxLength(50, ErrorMessage = "El campo Codigo Edificio tiene un largo máximo de 50 caracteres")]
        [JsonPropertyName("codigoEdificio")]
        public string CodigoEdificio { get; set; }
        [MaxLength(50, ErrorMessage = "El campo Codigo Area tiene un largo máximo de 50 caracteres")]
        [JsonPropertyName("codigoArea")]
        public string CodigoArea { get; set; }
        [MaxLength(100, ErrorMessage = "El campo Nombre Edificio tiene un largo máximo de 100 caracteres")]
        [JsonPropertyName("nombreEdificio")]
        public string NombreEdificio { get; set; }
        [MaxLength(100, ErrorMessage = "El campo Direccion Edificio tiene un largo máximo de 100 caracteres")]
        [JsonPropertyName("direccionEdificio")]
        public string DireccionEdificio { get; set; }
        [MaxLength(50, ErrorMessage = "El campo Ciudad Edificio tiene un largo máximo de 50 caracteres")]
        [JsonPropertyName("ciudadEdificio")]
        public string CiudadEdificio { get; set; }
        [MaxLength(50, ErrorMessage = "El campo Comuna Edificio tiene un largo máximo de 50 caracteres")]
        [JsonPropertyName("comunaEdificio")]
        public string ComunaEdificio { get; set; }
        [MaxLength(50, ErrorMessage = "El campo Centro Costo tiene un largo máximo de 50 caracteres")]
        [JsonPropertyName("centroCosto")]
        public string CentroCosto { get; set; }
        [JsonPropertyName("exitoso")]
        public bool? Exitoso { get; set; }
        [MaxLength(50, ErrorMessage = "El campo Codigo Autorizacion tiene un largo máximo de 50 caracteres")]
        [JsonPropertyName("codigoAutorizacion")]
        public string CodigoAutorizacion { get; set; }
        [JsonPropertyName("fechaPago")]
        public DateTime? FechaPago { get; set; }
        [JsonPropertyName("mesPago")]
        public int? MesPago { get; set; }
        [JsonPropertyName("anioPago")]
        public int? AnioPago { get; set; }
        [MaxLength(100, ErrorMessage = "El campo Numero Tarjeta tiene un largo máximo de 100 caracteres")]
        [JsonPropertyName("numeroTarjeta")]
        public string NumeroTarjeta { get; set; }
        [JsonPropertyName("notificado")]
        public bool? Notificado { get; set; }
        [MaxLength(50, ErrorMessage = "El campo Codigo Notificacion tiene un largo máximo de 50 caracteres")]
        [JsonPropertyName("codigoNotificacion")]
        public string CodigoNotificacion { get; set; }
        [MaxLength(50, ErrorMessage = "El campo Numero Boleta tiene un largo máximo de 50 caracteres")]
        [JsonPropertyName("numeroBoleta")]
        public string NumeroBoleta { get; set; }
        [MaxLength(500, ErrorMessage = "El campo Url Boleta tiene un largo máximo de 500 caracteres")]
        [JsonPropertyName("urlBoleta")]
        public string UrlBoleta { get; set; }
        [JsonPropertyName("fechaBoleta")]
        public DateTime? FechaBoleta { get; set; }
        [MaxLength(4, ErrorMessage = "El campo Codigo Pais tiene un largo máximo de 4 caracteres")]
        [JsonPropertyName("codigoPais")]
        public string CodigoPais { get; set; }
        [MaxLength(50, ErrorMessage = "El campo Pais tiene un largo máximo de 50 caracteres")]
        [JsonPropertyName("pais")]
        public string Pais { get; set; }
        [JsonPropertyName("ultimoIntento")]
        public DateTime? UltimoIntento { get; set; }
        [MaxLength(50, ErrorMessage = "El campo Boleta Aux tiene un largo máximo de 50 caracteres")]
        [JsonPropertyName("boletaAux")]
        public string BoletaAux { get; set; }
        [MaxLength(200, ErrorMessage = "El campo Firma tiene un largo máximo de 200 caracteres")]
        [JsonPropertyName("firma")]
        public string Firma { get; set; }

        [JsonPropertyName("fechaDesde")]
        public DateTime FechaDesde { get; set; }
        [JsonPropertyName("fechaHasta")]
        public DateTime FechaHasta { get; set; }
        [JsonPropertyName("codigoConvenio")]
        public int CodigoConvenio { get; set; }
    }
}

