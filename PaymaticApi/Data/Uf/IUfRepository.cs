






/**
* (c)2013-2023 CodeBase Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*13-12-2023,Generador de Código, Clase Inicial 
*/


using Cl.Intertrade.ActivPay.Entities.Uf;
using System.Collections.Generic;

namespace Cl.Intertrade.ActivPay.Repository.Uf
{
	/// <summary>
	/// Esta Clase Uf  permite gestionar la interacción con la base de datos para la tabla Uf
	/// </summary>
	public interface IUfRepository
	{

		/// <summary>
		/// Consulta todos los elementos existentes
		/// </summary>
		/// <returns>Una lista de objetos</returns>
		IList<UfModel> ObtenerUfs();
		/// <summary>
		/// Consulta una colección de elementos según parámetros de busqueda
		/// </summary>
		/// <param name="fechaUf"></param>
		/// <returns>Una lista de objetos para la busqueda especificada</returns>
		IList<UfModel> BuscarUfs(DateTime fechaUf);
		/// <summary>
		/// Consulta un único elemento según clave especificada
		/// </summary>
		/// <param name="fechaUf"></param>
		/// <returns>Un objeto de persistencia para la clave especificada</returns>
		UfModel ObtenerUf(DateTime fechaUf);

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="ufModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
		UfModel CrearUf(UfModel ufModel);
		/// <summary>
		/// Actualiza un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="ufModel"></param>
		/// <returns>booleano indicando si la operación fue exitosa o no</returns>
		bool ActualizarUf(UfModel ufModel);
		/// <summary>
		/// Elimina un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="fechaUf"></param>
		/// <returns>booleano indicando si la operación fue exitosa o no</returns>
		bool EliminarUf(DateTime fechaUf);
		UfModel ObtenerUf();

    }
}

