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

namespace Cl.Intertrade.ActivPay.Entities.DetalleTransferencia
{
    /// <summary>
    /// Esta Clase DetalleTransferenciaModel  Representa el objeto de persistencia para la tabla DetalleTransferencia
    /// </summary>
    public partial class DetalleTransferenciaModel
    {
        public int TransferenciaId { get; set; }
        public int RutRazonSocial { get; set; }
        public string PagoId { get; set; }
        public decimal MontoTransferencia { get; set; }
        public DateTime FechaTransferencia { get; set; }
        public decimal CostoComision { get; set; }
        public decimal MontoPago { get; set; }


        /// <summary>
        /// Constructor de la Clase DetalleTransferenciaTo
        /// </summary>
        public DetalleTransferenciaModel()
        {
            TransferenciaId = 0;
            RutRazonSocial = 0;
            MontoTransferencia = 0;
            FechaTransferencia = new DateTime(1900, 1, 1);
        }
    }
}

