





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
namespace Cl.Intertrade.ActivPay.Entities.Banco
{
    /// <summary>
    /// Esta Clase BancoModel  Representa el objeto de persistencia para la tabla Banco
    /// </summary>
    public partial class BancoModel
    {
        public string CodigoBanco { get; set; }
        public string Nombre { get; set; }
        /// <summary>
        /// Constructor de la Clase BancoTo
        /// </summary>
        public BancoModel()
        {
            CodigoBanco = string.Empty;
            Nombre = string.Empty;
        }
    }
}

