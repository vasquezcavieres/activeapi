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

namespace Cl.Intertrade.ActivPay.Entities.Convenio
{
    /// <summary>
    /// Esta Clase ConvenioModel  Representa el objeto de persistencia para la tabla Convenio
    /// </summary>
    public partial class ConvenioModel
    {
        public int RutRazonSocial { get; set; }
        public string RutRazonSocialDv { get; set; }
        public string NombrerazonSocial { get; set; }
        public string NombreAdministradora { get; set; }
        public string Direccion { get; set; }
        public string Comuna { get; set; }
        public string Region { get; set; }
        public string RepresentanteLegal { get; set; }
        public int? RutRepresentanteLegal { get; set; }
        public string RutRepresentanteLegalDv { get; set; }
        public int? NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public string Banco { get; set; }
        public string CorreoContacto { get; set; }
        public int? VendedorId { get; set; }
        public decimal PorcentajeComision { get; set; }
        public string EmailNotificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int RutAdministrador { get; set; }
        public decimal MinimoGarantizadoComision { get; set; }
        public string Giro { get; set; }
        /// <summary>
        /// Constructor de la Clase ConvenioTo
        /// </summary>
        public ConvenioModel()
        {
            RutRazonSocial = 0;
            RutRazonSocialDv = string.Empty;
            NombrerazonSocial = string.Empty;
            NombreAdministradora = string.Empty;
            Direccion = string.Empty;
            Comuna = string.Empty;
            Region = string.Empty;
            RepresentanteLegal = string.Empty;
            RutRepresentanteLegal = 0;
            RutRepresentanteLegalDv = string.Empty;
            NumeroCuenta = 0;
            TipoCuenta = string.Empty;
            Banco = string.Empty;
            CorreoContacto = string.Empty;
            VendedorId = 0;
            PorcentajeComision = 0;
            EmailNotificacion = string.Empty;
        }
    }
}

