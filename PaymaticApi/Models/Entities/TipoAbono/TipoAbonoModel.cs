/**
* (c)2013-2023 CodeBase Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*11-12-2023,Generador de Código, Clase Inicial 
*/

	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
namespace Cl.Intertrade.ActivPay.Entities.TipoAbono
{
    /// <summary>
    /// Esta Clase TipoAbonoModel  Representa el objeto de persistencia para la tabla TipoAbono
    /// </summary>
    public partial class TipoAbonoModel
    {
        public string CodigoTipoAbono { get; set; }
        public string Nombre { get; set; }
        /// <summary>
        /// Constructor de la Clase TipoAbonoTo
        /// </summary>
        public TipoAbonoModel()
        {
            CodigoTipoAbono = string.Empty;
            Nombre = string.Empty;
        }
    }
}

