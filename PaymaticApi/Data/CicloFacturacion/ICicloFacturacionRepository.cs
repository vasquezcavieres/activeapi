






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


using Cl.Intertrade.ActivPay.Entities.CicloTransferencia;
using System.Collections.Generic;

namespace Cl.Intertrade.ActivPay.Repository.CicloTransferencia
{
	/// <summary>
	/// Esta Clase CicloTransferencia  permite gestionar la interacción con la base de datos para la tabla CicloTransferencia
	/// </summary>
	public interface ICicloTransferenciaRepository
	{	

		/// <summary>
		/// Consulta todos los elementos existentes
		/// </summary>
		/// <returns>Una lista de objetos</returns>
		IList<CicloTransferenciaModel> ObtenerCicloTransferencias( );
		/// <summary>
		/// Consulta una colección de elementos según parámetros de busqueda
		/// </summary>
		/// <param name="creadoPor"></param>
/// <returns>Una lista de objetos para la busqueda especificada</returns>
		IList<CicloTransferenciaModel> BuscarCicloTransferencias( string creadoPor);
		/// <summary>
        /// Consulta un único elemento según clave especificada
        /// </summary>
        /// <param name="creadoPor"></param>
/// <returns>Un objeto de persistencia para la clave especificada</returns>
		CicloTransferenciaModel ObtenerCicloTransferencia(string creadoPor);

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="CicloTransferenciaModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
		CicloTransferenciaModel CrearCicloTransferencia(CicloTransferenciaModel CicloTransferenciaModel);
		/// <summary>
		/// Actualiza un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="CicloTransferenciaModel"></param>
		/// <returns>booleano indicando si la operación fue exitosa o no</returns>
		bool ActualizarCicloTransferencia(CicloTransferenciaModel CicloTransferenciaModel);
		/// <summary>
		/// Elimina un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="creadoPor"></param>
/// <returns>booleano indicando si la operación fue exitosa o no</returns>
		bool EliminarCicloTransferencia(string creadoPor);
	}
}

