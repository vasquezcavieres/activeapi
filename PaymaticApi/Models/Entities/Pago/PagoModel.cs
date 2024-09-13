





/**
* (c)2013-2023 CodeBase Todos los Derechos Reservados.
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

namespace Cl.Intertrade.ActivPay.Entities.Pago
{
    /// <summary>
    /// Esta Clase PagoModel  Representa el objeto de persistencia para la tabla Pago
    /// </summary>
    public partial class PagoModel
    {
        public string PagoId { get; set; }
        public string VendedorId { get; set; }
        public string NombreVendedor { get; set; }
        public string TokenTransaccion { get; set; }
        public string TokenMedioPago { get; set; }
        public string CodigoMedioPago { get; set; }
        public decimal NumeroOrden { get; set; }
        public string EmailCliente { get; set; }
        public string NombreCliente { get; set; }
        public decimal MontoPago { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public string CodigoEdificio { get; set; }
        public string CodigoArea { get; set; }
        public string NombreEdificio { get; set; }
        public string DireccionEdificio { get; set; }
        public string CiudadEdificio { get; set; }
        public string ComunaEdificio { get; set; }
        public string CentroCosto { get; set; }
        public bool? Exitoso { get; set; }
        public string CodigoAutorizacion { get; set; }
        public DateTime? FechaPago { get; set; }
        public int? MesPago { get; set; }
        public int? AnioPago { get; set; }
        public string NumeroTarjeta { get; set; }
        public bool? Notificado { get; set; }
        public string CodigoNotificacion { get; set; }
        public string NumeroBoleta { get; set; }
        public string UrlBoleta { get; set; }
        public DateTime? FechaBoleta { get; set; }
        public string CodigoPais { get; set; }
        public string Pais { get; set; }
        public DateTime? UltimoIntento { get; set; }
        public string BoletaAux { get; set; }
        public string Firma { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public int? CodigoConvenio { get; set; }
        public int MaquinasInstaladas { get; set; }

        /// <summary>
        /// Constructor de la Clase PagoTo
        /// </summary>
        public PagoModel()
        {
            PagoId = string.Empty;
            VendedorId = string.Empty;
            NombreVendedor = string.Empty;
            TokenTransaccion = string.Empty;
            TokenMedioPago = string.Empty;
            CodigoMedioPago = string.Empty;
            NumeroOrden = 0;
            EmailCliente = string.Empty;
            NombreCliente = string.Empty;
            MontoPago = 0;
            FechaTransaccion = new DateTime(1900, 1, 1);
            CodigoEdificio = string.Empty;
            CodigoArea = string.Empty;
            NombreEdificio = string.Empty;
            DireccionEdificio = string.Empty;
            CiudadEdificio = string.Empty;
            ComunaEdificio = string.Empty;
            CentroCosto = string.Empty;
            Exitoso = false;
            CodigoAutorizacion = string.Empty;
            FechaPago = new DateTime(1900, 1, 1);
            MesPago = 0;
            AnioPago = 0;
            NumeroTarjeta = string.Empty;
            Notificado = false;
            CodigoNotificacion = string.Empty;
            NumeroBoleta = string.Empty;
            UrlBoleta = string.Empty;
            FechaBoleta = new DateTime(1900, 1, 1);
            CodigoPais = string.Empty;
            Pais = string.Empty;
            UltimoIntento = new DateTime(1900, 1, 1);
            BoletaAux = string.Empty;
            Firma = string.Empty;
        }
    }
}

