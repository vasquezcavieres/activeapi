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
namespace Cl.Intertrade.ActivPay.Entities.Usuario
{
    /// <summary>
    /// Esta Clase UsuarioModel  Representa el objeto de persistencia para la tabla Usuario
    /// </summary>
    public partial class UsuarioModel
    {
        public string TokenUsuario { get; set; }
        public int RutUsuario { get; set; }
        public string RutUsuarioDv { get; set; }
        public string CodigoPais { get; set; }
        public string Pais { get; set; }
        public string CodigoRol { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public long? Telefono { get; set; }
        public string Clave { get; set; }
        public string UltimaClave { get; set; }
        public bool? DebeCambiarClave { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool? Activo { get; set; }

        public string CodigoEdificio { get; set;}

        public string TokenRecuperacion { get; set; }
        /// <summary>
        /// Constructor de la Clase UsuarioTo
        /// </summary>
        public UsuarioModel()
        {
            TokenUsuario = string.Empty;
            RutUsuario = 0;
            RutUsuarioDv = string.Empty;
            CodigoPais = string.Empty;
            Pais = string.Empty;
            CodigoRol = string.Empty;
            Nombres = string.Empty;
            Apellidos = string.Empty;
            Email = string.Empty;
            Telefono = 0;
            Clave = string.Empty;
            UltimaClave = string.Empty;
            DebeCambiarClave = false;
            FechaCreacion = new DateTime(1900, 1, 1);
            FechaActualizacion = new DateTime(1900, 1, 1);
            Activo = false;
        }
    }
}

