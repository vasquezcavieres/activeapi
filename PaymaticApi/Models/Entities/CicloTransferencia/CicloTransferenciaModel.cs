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
namespace Cl.Intertrade.ActivPay.Entities.CicloTransferencia
{
    /// <summary>
    /// Esta Clase CicloTransferenciaModel  Representa el objeto de persistencia para la tabla CicloTransferencia
    /// </summary>
    public partial class CicloTransferenciaModel
    {
        public int CodigoConvenio { get; set; }
        public string CreadoPor { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string DiasTransferencia { get; set; }
        public string ActualizadoPor { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        /// <summary>
        /// Constructor de la Clase CicloTransferenciaTo
        /// </summary>
        public CicloTransferenciaModel()
        {
            CreadoPor = string.Empty;
            FechaCreacion = new DateTime(1900, 1, 1);
            DiasTransferencia = string.Empty;
            ActualizadoPor = string.Empty;
            FechaActualizacion = new DateTime(1900, 1, 1);
        }
    }
}

