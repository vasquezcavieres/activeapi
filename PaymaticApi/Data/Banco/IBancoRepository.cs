






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


using Cl.Intertrade.ActivPay.Entities.Banco;
using System.Collections.Generic;

namespace Cl.Intertrade.ActivPay.Repository.Banco
{
	/// <summary>
	/// Esta Clase Banco  permite gestionar la interacción con la base de datos para la tabla Banco
	/// </summary>
	public interface IBancoRepository
	{	

		/// <summary>
		/// Consulta todos los elementos existentes
		/// </summary>
		/// <returns>Una lista de objetos</returns>
		IList<BancoModel> ObtenerBancos( );
		/// <summary>
		/// Consulta una colección de elementos según parámetros de busqueda
		/// </summary>
		/// <returns>Una lista de objetos para la busqueda especificada</returns>
		IList<BancoModel> BuscarBancos( );
		/// <summary>
        /// Consulta un único elemento según clave especificada
        /// </summary>
        /// <returns>Un objeto de persistencia para la clave especificada</returns>
		BancoModel ObtenerBanco(string codigoBanco);

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="bancoModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
		BancoModel CrearBanco(BancoModel bancoModel);
		/// <summary>
		/// Actualiza un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="bancoModel"></param>
		/// <returns>booleano indicando si la operación fue exitosa o no</returns>
		bool ActualizarBanco(BancoModel bancoModel);
		/// <summary>
		/// Elimina un elemento desde el medio de persistencia
		/// </summary>
		/// <returns>booleano indicando si la operación fue exitosa o no</returns>
		bool EliminarBanco();
	}
}

