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

namespace Cl.Intertrade.ActivPay.Entities.Factura
{
    /// <summary>
    /// Esta Clase FacturaModel  Representa el objeto de persistencia para la tabla Factura
    /// </summary>
    public partial class FacturaModel
    {
        public int NumeroFactura { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int MontoNeto { get; set; }
        public decimal Iva { get; set; }
        public decimal MontoTotal { get; set; }
        public int RutRazonSocial { get; set; }
        public string Estado { get; set; }
        public string CodigoEdificio { get; set; }
        public string NombreEdificio { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public byte[] PdfNotaCredito { get; set; }
        public List<string> Errores { get; set; }
        public int NumeroNotaCredito { get; set; }
        public string Base64NotaCredito { get; set; }

        /// <summary>
        /// Constructor de la Clase FacturaTo
        /// </summary>
        public FacturaModel()
        {
            NumeroFactura = 0;
            FechaCreacion = new DateTime(1900, 1, 1);
            MontoNeto = 0;
            Iva = 0;
            MontoTotal = 0;
            RutRazonSocial = 0;
            Estado = string.Empty;
        }
    }
}

