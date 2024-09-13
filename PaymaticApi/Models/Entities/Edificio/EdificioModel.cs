/**
* (c)2013-2023 CodeBase Todos los Derechos Reservados.
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
namespace Cl.Intertrade.ActivPay.Entities.Edificio
{
    /// <summary>
    /// Esta Clase EdificioModel  Representa el objeto de persistencia para la tabla Edificio
    /// </summary>
    public partial class EdificioModel
    {
        public string CodigoEdificio { get; set; }
        public string CodigoArea { get; set; }
        public string Nombre { get; set; }
        public string CodigoPais { get; set; }
        public string Pais { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Comuna { get; set; }
        public string CentroCosto { get; set; }
        public int RutRazonSocial { get; set; }
        public int NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public string CodigoTipoCuenta { get; set; }
        public string CodigoBanco { get; set; }
        public string Banco { get; set; }   
        public string CorreoContacto { get; set; }
        public string EmailNotificacion { get; set; }
        public int MaquinasInstaladas { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public int? RutComunidad { get; set; }
        public decimal MinimoGarantizadoComision { get; set; }
        public string Giro { get; set; }
        public double? PorcentajeComision { get; set; }


        public string CodigoTipoAbono { get; set; }

        /// <summary>
        /// Constructor de la Clase EdificioTo
        /// </summary>
        public EdificioModel()
        {
            CodigoEdificio = string.Empty;
            CodigoArea = string.Empty;
            Nombre = string.Empty;
            CodigoPais = string.Empty;
            Pais = string.Empty;
            Direccion = string.Empty;
            Ciudad = string.Empty;
            Comuna = string.Empty;
            CentroCosto = string.Empty;
            RutRazonSocial = 0;
        }
    }
}

