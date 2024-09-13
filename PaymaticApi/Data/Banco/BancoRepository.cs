






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
using Cl.Intertrade.ActivPay.Entities.Banco;
using System.Collections.Generic;
using System.Linq;

namespace Cl.Intertrade.ActivPay.Repository.Banco
{
	/// <summary>
	/// Esta Clase Banco  permite gestionar la interacción con la base de datos para la tabla Banco
	/// </summary>
	public partial class BancoRepository : DBBaseHelper, IBancoRepository
	{	

			public BancoRepository(ISettingsConfig settings) : base(settings)
			{
				this.settingsConfig = settings;
			}

		/// <summary>
		/// Consulta todos los elementos existentes
		/// </summary>
		/// <returns>Una lista de objetos</returns>
		public IList<BancoModel> ObtenerBancos( )
		{
			IList<BancoModel> result;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"Select CodigoBanco, Nombre  FROM Dbo.Banco";
				result = db.Query<BancoModel>(query).AsList();
			}
			return result;       
		}
		/// <summary>
		/// Consulta una colección de elementos según parámetros de busqueda
		/// </summary>
		/// <returns>Una lista de objetos para la busqueda especificada</returns>
		public IList<BancoModel> BuscarBancos( )
		{
			IList<BancoModel> result;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"Select CodigoBanco, Nombre  FROM Dbo.Banco WHERE  ";
				result = db.Query<BancoModel>(query, new {  }).AsList();
			}
			return result;       
		}
		/// <summary>
        /// Consulta un único elemento según clave especificada
        /// </summary>
        /// <returns>Un objeto de persistencia para la clave especificada</returns>
		public BancoModel ObtenerBanco(string codigoBanco)
		{
			BancoModel result;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"Select CodigoBanco, Nombre  FROM Dbo.Banco WHERE CodigoBanco = @CodigoBanco  ";
				result = db.QueryFirstOrDefault<BancoModel>(query, new { CodigoBanco = codigoBanco });
			}
			return result;                        
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="bancoModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
		public BancoModel CrearBanco(BancoModel bancoModel)
		{
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
		string query = @"INSERT INTO Dbo.Banco  (CodigoBanco, Nombre) VALUES (@CodigoBanco, @Nombre)";
		db.Execute(query, bancoModel);
						}
			return bancoModel;
		}

		/// <summary>
		/// Actualiza un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="bancoModel"></param>
		/// <returns>booleano indicando si la operación fue exitosa o no</returns>
		public bool ActualizarBanco(BancoModel bancoModel)
		{
			bool result = false;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"UPDATE Dbo.Banco SET CodigoBanco=@CodigoBanco, Nombre=@Nombre WHERE ";
				int i = db.Execute(query, bancoModel);
                result = i >= 0;
			}
			return result;
		}
		/// <summary>
		/// Elimina un elemento desde el medio de persistencia
		/// </summary>
		/// <returns>booleano indicando si la operación fue exitosa o no</returns>
		public bool EliminarBanco()
		{
			bool result = false;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"DELETE FROM Dbo.Banco WHERE ";
                int i = db.Execute(query, new {  });
				result = i >= 1;
			}
			return result;
		}
	}
}

