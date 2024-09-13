/**
* (c)2019-2023 NEGS Todos los Derechos Reservados.
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

namespace Cl.Intertrade.ActivPay.Request.Usuario
{
    /// <summary>
    /// Esta Clase UsuarioRequest define la estructura para las llamadas a la api
    /// </summary>
    public partial class UsuarioRequest
    {
        [MaxLength(50, ErrorMessage = "El campo Token Usuario tiene un largo máximo de 50 caracteres")]
        //[Required(ErrorMessage ="El campo Token Usuario es obligatorio")]
        [JsonPropertyName("tokenUsuario")]
        public string TokenUsuario { get; set; }
        [JsonPropertyName("rutUsuario")]
        public int? RutUsuario { get; set; }
        [MaxLength(1, ErrorMessage = "El campo Rut Usuario Dv tiene un largo máximo de 1 caracteres")]
        [JsonPropertyName("rutUsuarioDv")]
        public string RutUsuarioDv { get; set; }
        [MaxLength(4, ErrorMessage = "El campo Codigo Pais tiene un largo máximo de 4 caracteres")]
        [JsonPropertyName("codigoPais")]
        public string CodigoPais { get; set; }
        [MaxLength(50, ErrorMessage = "El campo Pais tiene un largo máximo de 50 caracteres")]
        [JsonPropertyName("pais")]
        public string Pais { get; set; }
        [MaxLength(50, ErrorMessage = "El campo Codigo Rol tiene un largo máximo de 50 caracteres")]
        [Required(ErrorMessage = "El campo Codigo Rol es obligatorio")]
        [JsonPropertyName("codigoRol")]
        public string CodigoRol { get; set; }
        [MaxLength(100, ErrorMessage = "El campo Nombres tiene un largo máximo de 100 caracteres")]
        [JsonPropertyName("nombres")]
        public string Nombres { get; set; }
        [MaxLength(100, ErrorMessage = "El campo Apellidos tiene un largo máximo de 100 caracteres")]
        [JsonPropertyName("apellidos")]
        public string Apellidos { get; set; }
        [MaxLength(100, ErrorMessage = "El campo Email tiene un largo máximo de 100 caracteres")]
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("telefono")]
        public long? Telefono { get; set; }
        [MaxLength(100, ErrorMessage = "El campo Clave tiene un largo máximo de 100 caracteres")]
        [JsonPropertyName("clave")]
        public string Clave { get; set; }
        [MaxLength(100, ErrorMessage = "El campo Ultima Clave tiene un largo máximo de 100 caracteres")]
        [JsonPropertyName("ultimaClave")]
        public string UltimaClave { get; set; }
        [JsonPropertyName("debeCambiarClave")]
        public bool? DebeCambiarClave { get; set; }
        [JsonPropertyName("fechaCreacion")]
        public DateTime? FechaCreacion { get; set; }
        [JsonPropertyName("fechaActualizacion")]
        public DateTime? FechaActualizacion { get; set; }
        [JsonPropertyName("activo")]
        public bool? Activo { get; set; }


        [JsonPropertyName("tokenAcceso")]
        public string TokenAcceso { get; set; }

        [JsonPropertyName("codigoEdificio")]
        public string CodigoEdificio { get; set; }
    }
}

