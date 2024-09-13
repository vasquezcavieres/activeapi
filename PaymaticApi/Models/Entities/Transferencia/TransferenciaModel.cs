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
namespace Cl.Intertrade.ActivPay.Entities.Transferencia
{
    /// <summary>
    /// Esta Clase TransferenciaModel  Representa el objeto de persistencia para la tabla Transferencia
    /// </summary>
    public partial class TransferenciaModel
    {
        public int TransferenciaId { get; set; }
        public decimal TotalTransferencia { get; set; }
        public decimal CostoComision { get; set; }
        public DateTime FechaTransferencia { get; set; }
        public int NumeroPagos { get; set; }
        public int CodigoConvenio { get; set; }
        public int NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public string Banco { get; set; }
        public string EmailNotificacion { get; set; }
        public string Estado { get; set; }
        public decimal MontoTransferencia { get; set; }

        public string CodigoEdificio { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }

        public string CodigoTipoCuenta { get; set; }
        public string CodigoBanco { get; set; }
        public bool Facturada { get; set; }
        public string NombreEdificio { get; set; }
        public int RutRazonSocial { get; set; }
        public string RutRazonSocialDv { get; set; }
        public decimal IvaCostoComision { get; set; }




        /// <summary>
        /// Constructor de la Clase TransferenciaTo
        /// </summary>
        public TransferenciaModel()
        {
            TransferenciaId = 0;
            TotalTransferencia = 0;
            CostoComision = 0;
            FechaTransferencia = new DateTime(1900, 1, 1);
        }
    }
}

