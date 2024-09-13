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
using System.Text.Json.Serialization;

namespace Cl.Intertrade.ActivPay.Result.Usuario
{
    /// <summary>
    /// Esta Clase UsuarioResult  Representa objeto para la salida json
    /// </summary>
    public partial class ListadoUsuarioResult
    {
        public IList<UsuarioResult> Usuarios { get; set; }
        public int StatusCode { get; set; }
    }

    /// <summary>
    /// Esta Clase UsuarioResult  Representa objeto para la salida json
    /// </summary>
    public partial class UsuarioResult
    {
        [JsonPropertyName("tokenUsuario")]
        public string TokenUsuario { get; set; }
        [JsonPropertyName("rutUsuario")]
        public int RutUsuario { get; set; }
        [JsonPropertyName("rutUsuarioDv")]
        public string RutUsuarioDv { get; set; }
        [JsonPropertyName("codigoPais")]
        public string CodigoPais { get; set; }
        [JsonPropertyName("pais")]
        public string Pais { get; set; }
        [JsonPropertyName("codigoRol")]
        public string CodigoRol { get; set; }
        [JsonPropertyName("nombres")]
        public string Nombres { get; set; }
        [JsonPropertyName("apellidos")]
        public string Apellidos { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("telefono")]
        public long Telefono { get; set; }
        [JsonPropertyName("clave")]
        public string Clave { get; set; }
        [JsonPropertyName("ultimaClave")]
        public string UltimaClave { get; set; }
        [JsonPropertyName("debeCambiarClave")]
        public bool DebeCambiarClave { get; set; }
        [JsonPropertyName("fechaCreacion")]
        public DateTime FechaCreacion { get; set; }
        [JsonPropertyName("fechaActualizacion")]
        public DateTime FechaActualizacion { get; set; }
        [JsonPropertyName("activo")]
        public bool Activo { get; set; }

        [JsonPropertyName("tokenAcceso")]
        public string TokenAcceso { get; set; }

        [JsonPropertyName("tokenRecuperacion")]
        public string TokenRecuperacion { get; set; }

        [JsonPropertyName("codigoEdificio")]
        public string CodigoEdificio { get; set; }
        public int StatusCode { get; set; }
        public List<string> Errores { get; set; }
    }
}

