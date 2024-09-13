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


using Cl.Intertrade.ActivPay.Helpers.Base;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Cl.Intertrade.ActivPay.Entities.Uf;
using System.Collections.Generic;
using System.Linq;

namespace Cl.Intertrade.ActivPay.Repository.Uf
{
	/// <summary>
	/// Esta Clase Uf  permite gestionar la interacción con la base de datos para la tabla Uf
	/// </summary>
	public partial class UfRepository : DBBaseHelper, IUfRepository
	{	
			public UfRepository(ISettingsConfig settings) : base(settings)
			{
				this.settingsConfig = settings;
			}

		/// <summary>
		/// Consulta todos los elementos existentes
		/// </summary>
		/// <returns>Una lista de objetos</returns>
		public IList<UfModel> ObtenerUfs( )
		{
			IList<UfModel> result;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"Select FechaUf, Valor  FROM Dbo.Uf";
				result = db.Query<UfModel>(query).AsList();
			}
			return result;       
		}
		/// <summary>
		/// Consulta una colección de elementos según parámetros de busqueda
		/// </summary>
		/// <param name="fechaUf"></param>
/// <returns>Una lista de objetos para la busqueda especificada</returns>
		public IList<UfModel> BuscarUfs( DateTime fechaUf)
		{
			IList<UfModel> result;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"Select FechaUf, Valor  FROM Dbo.Uf WHERE  FechaUf = @FechaUf ";
				result = db.Query<UfModel>(query, new { FechaUf=fechaUf }).AsList();
			}
			return result;       
		}
		/// <summary>
        /// Consulta un único elemento según clave especificada
        /// </summary>
        /// <param name="fechaUf"></param>
/// <returns>Un objeto de persistencia para la clave especificada</returns>
		public UfModel ObtenerUf(DateTime fechaUf)
		{
			UfModel result;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"Select FechaUf, Valor  FROM Dbo.Uf WHERE  FechaUf = @FechaUf ";
				result = db.QueryFirstOrDefault<UfModel>(query, new { FechaUf=fechaUf });
			}
			return result;                        
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="ufModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
		public UfModel CrearUf(UfModel ufModel)
		{
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
		string query = @"INSERT INTO Dbo.Uf  (FechaUf, Valor) VALUES (@FechaUf, @Valor)";
		db.Execute(query, ufModel);
						}
			return ufModel;
		}

		/// <summary>
		/// Actualiza un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="ufModel"></param>
		/// <returns>booleano indicando si la operación fue exitosa o no</returns>
		public bool ActualizarUf(UfModel ufModel)
		{
			bool result = false;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"UPDATE Dbo.Uf SET Valor=@Valor WHERE FechaUf = @FechaUf ";
				int i = db.Execute(query, ufModel);
                result = i >= 0;
			}
			return result;
		}
		/// <summary>
		/// Elimina un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="fechaUf"></param>
/// <returns>booleano indicando si la operación fue exitosa o no</returns>
		public bool EliminarUf(DateTime fechaUf)
		{
			bool result = false;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"DELETE FROM Dbo.Uf WHERE FechaUf = @FechaUf ";
                int i = db.Execute(query, new { FechaUf=fechaUf });
				result = i >= 1;
			}
			return result;
		}

        public UfModel ObtenerUf()
        {
            UfModel result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"Select FechaUf, Valor  
                                FROM Dbo.Uf 
                                WHERE  1 = 1
                                group by FechaUf, Valor  
                                having   FechaUf = MAX(FechaUf)";
                result = db.QueryFirstOrDefault<UfModel>(query);
            }
            return result;
        }

    }
}

