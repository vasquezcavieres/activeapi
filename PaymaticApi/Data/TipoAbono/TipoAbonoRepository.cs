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


using Cl.Intertrade.ActivPay.Helpers.Base;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Cl.Intertrade.ActivPay.Entities.TipoAbono;
using System.Collections.Generic;
using System.Linq;

namespace Cl.Intertrade.ActivPay.Repository.TipoAbono
{
	/// <summary>
	/// Esta Clase TipoAbono  permite gestionar la interacción con la base de datos para la tabla TipoAbono
	/// </summary>
	public partial class TipoAbonoRepository : DBBaseHelper, ITipoAbonoRepository
	{	

			public TipoAbonoRepository(ISettingsConfig settings) : base(settings)
			{
				this.settingsConfig = settings;
			}

		/// <summary>
		/// Consulta todos los elementos existentes
		/// </summary>
		/// <returns>Una lista de objetos</returns>
		public IList<TipoAbonoModel> ObtenerTipoAbonos( )
		{
			IList<TipoAbonoModel> result;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"Select CodigoTipoAbono, Nombre  FROM Dbo.TipoAbono";
				result = db.Query<TipoAbonoModel>(query).AsList();
			}
			return result;       
		}
		/// <summary>
		/// Consulta una colección de elementos según parámetros de busqueda
		/// </summary>
		/// <returns>Una lista de objetos para la busqueda especificada</returns>
		public IList<TipoAbonoModel> BuscarTipoAbonos( )
		{
			IList<TipoAbonoModel> result;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"Select CodigoTipoAbono, Nombre  FROM Dbo.TipoAbono WHERE  ";
				result = db.Query<TipoAbonoModel>(query, new {  }).AsList();
			}
			return result;       
		}
		/// <summary>
        /// Consulta un único elemento según clave especificada
        /// </summary>
        /// <returns>Un objeto de persistencia para la clave especificada</returns>
		public TipoAbonoModel ObtenerTipoAbono(string codigoTipoAbono)
		{
			TipoAbonoModel result;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"Select CodigoTipoAbono, Nombre  FROM Dbo.TipoAbono WHERE  codigoTipoAbono =@CodigoTipoAbono";
				result = db.QueryFirstOrDefault<TipoAbonoModel>(query, new { CodigoTipoAbono = codigoTipoAbono });
			}
			return result;                        
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="tipoAbonoModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
		public TipoAbonoModel CrearTipoAbono(TipoAbonoModel tipoAbonoModel)
		{
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
		string query = @"INSERT INTO Dbo.TipoAbono  (CodigoTipoAbono, Nombre) VALUES (@CodigoTipoAbono, @Nombre)";
		db.Execute(query, tipoAbonoModel);
						}
			return tipoAbonoModel;
		}

		/// <summary>
		/// Actualiza un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="tipoAbonoModel"></param>
		/// <returns>booleano indicando si la operación fue exitosa o no</returns>
		public bool ActualizarTipoAbono(TipoAbonoModel tipoAbonoModel)
		{
			bool result = false;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"UPDATE Dbo.TipoAbono SET CodigoTipoAbono=@CodigoTipoAbono, Nombre=@Nombre WHERE ";
				int i = db.Execute(query, tipoAbonoModel);
                result = i >= 0;
			}
			return result;
		}
		/// <summary>
		/// Elimina un elemento desde el medio de persistencia
		/// </summary>
		/// <returns>booleano indicando si la operación fue exitosa o no</returns>
		public bool EliminarTipoAbono()
		{
			bool result = false;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"DELETE FROM Dbo.TipoAbono WHERE ";
                int i = db.Execute(query, new {  });
				result = i >= 1;
			}
			return result;
		}
	}
}

