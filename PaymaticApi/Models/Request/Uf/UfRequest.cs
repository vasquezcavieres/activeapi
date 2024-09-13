





/**
* (c)2019-2023 NEGS Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*13-12-2023,Generador de Código, Clase Inicial 
*/

	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Text.Json.Serialization;

	namespace Cl.Intertrade.ActivPay.Request.Uf
	{
		/// <summary>
		/// Esta Clase UfRequest define la estructura para las llamadas a la api
		/// </summary>
		public partial class UfRequest
		{	
			[Required(ErrorMessage ="El campo Fecha Uf es obligatorio")]
			[JsonPropertyName("fechaUf")]
			public DateTime FechaUf { get; set; }
			[JsonPropertyName("valor")]
			public decimal? Valor { get; set; }
		}
	}

