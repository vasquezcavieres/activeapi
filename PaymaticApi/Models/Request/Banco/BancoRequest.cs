





/**
* (c)2019-2023 NEGS Todos los Derechos Reservados.
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
	using System.Text.Json.Serialization;

	namespace Cl.Intertrade.ActivPay.Request.Banco
	{
		/// <summary>
		/// Esta Clase BancoRequest define la estructura para las llamadas a la api
		/// </summary>
		public partial class BancoRequest
		{	
			[JsonPropertyName("codigoBanco")]
			public int? CodigoBanco { get; set; }
			[MaxLength(150, ErrorMessage ="El campo Nombre tiene un largo máximo de 150 caracteres")]
			[JsonPropertyName("nombre")]
			public string Nombre { get; set; }
		}
	}

