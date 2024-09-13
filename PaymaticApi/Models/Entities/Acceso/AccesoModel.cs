





/**
* (c)2013-2023 CodeBase Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*16-10-2023,Generador de Código, Clase Inicial 
*/

	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
namespace Cl.Intertrade.ActivPay.Entities.Acceso
{
    /// <summary>
    /// Esta Clase AccesoModel  Representa el objeto de persistencia para la tabla Acceso
    /// </summary>
    public partial class AccesoModel
    {
        public int Id { get; set; }
        public string RutUsuario { get; set; }
        public string DvUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public decimal? Telefono { get; set; }
        public string TokenAcceso { get; set; }
        public string TokenUsuario { get; set; }
        public string TokenRefresco { get; set; }
        public string CodigoPais { get; set; }
        public string Pais { get; set; }
        public DateTime FechaCreacion { get; set; }

        public string CodigoRol { get; set; }


        /// <summary>
        /// Constructor de la Clase AccesoTo
        /// </summary>
        public AccesoModel()
        {
            Id = 0;
            RutUsuario = string.Empty;
            DvUsuario = string.Empty;
            Nombres = string.Empty;
            Apellidos = string.Empty;
            Email = string.Empty;
            Telefono = 0;
            TokenAcceso = string.Empty;
            TokenUsuario = string.Empty;
            TokenRefresco = string.Empty;
            CodigoPais = string.Empty;
            FechaCreacion = new DateTime(1900, 1, 1);
        }
    }
}

