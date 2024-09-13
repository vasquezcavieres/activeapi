






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


using Cl.Intertrade.ActivPay.Helpers.Base;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Cl.Intertrade.ActivPay.Entities.CicloTransferencia;
using System.Collections.Generic;
using System.Linq;

namespace Cl.Intertrade.ActivPay.Repository.CicloTransferencia
{
	/// <summary>
	/// Esta Clase CicloTransferencia  permite gestionar la interacción con la base de datos para la tabla CicloTransferencia
	/// </summary>
	public partial class CicloTransferenciaRepository : DBBaseHelper, ICicloTransferenciaRepository
	{	

			public CicloTransferenciaRepository(ISettingsConfig settings) : base(settings)
			{
				this.settingsConfig = settings;
			}

		/// <summary>
		/// Consulta todos los elementos existentes
		/// </summary>
		/// <returns>Una lista de objetos</returns>
		public IList<CicloTransferenciaModel> ObtenerCicloTransferencias( )
		{
			IList<CicloTransferenciaModel> result;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"Select CreadoPor, FechaCreacion, DiasTransferencia, ActualizadoPor, FechaActualizacion  FROM Dbo.CicloTransferencia";
				result = db.Query<CicloTransferenciaModel>(query).AsList();
			}
			return result;       
		}
		/// <summary>
		/// Consulta una colección de elementos según parámetros de busqueda
		/// </summary>
		/// <param name="creadoPor"></param>
/// <returns>Una lista de objetos para la busqueda especificada</returns>
		public IList<CicloTransferenciaModel> BuscarCicloTransferencias( string creadoPor)
		{
			IList<CicloTransferenciaModel> result;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"Select CreadoPor, FechaCreacion, DiasTransferencia, ActualizadoPor, FechaActualizacion  FROM Dbo.CicloTransferencia WHERE  CreadoPor = @CreadoPor ";
				result = db.Query<CicloTransferenciaModel>(query, new { CreadoPor=creadoPor }).AsList();
			}
			return result;       
		}
		/// <summary>
        /// Consulta un único elemento según clave especificada
        /// </summary>
        /// <param name="creadoPor"></param>
/// <returns>Un objeto de persistencia para la clave especificada</returns>
		public CicloTransferenciaModel ObtenerCicloTransferencia(string creadoPor)
		{
			CicloTransferenciaModel result;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"Select CodigoConvenio,CreadoPor, FechaCreacion, DiasTransferencia, ActualizadoPor, FechaActualizacion  FROM Dbo.CicloTransferencia WHERE  CodigoConvenio = @CodigoConvenio ";
				result = db.QueryFirstOrDefault<CicloTransferenciaModel>(query, new { CodigoConvenio = creadoPor });
			}
			return result;                        
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="CicloTransferenciaModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
		public CicloTransferenciaModel CrearCicloTransferencia(CicloTransferenciaModel CicloTransferenciaModel)
		{
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
		string query = @"INSERT INTO Dbo.CicloTransferencia  (CodigoConvenio, CreadoPor, FechaCreacion, DiasTransferencia, ActualizadoPor, FechaActualizacion) VALUES (@CodigoConvenio,@CreadoPor, @FechaCreacion, @DiasTransferencia, @ActualizadoPor, @FechaActualizacion)";
		db.Execute(query, CicloTransferenciaModel);
						}
			return CicloTransferenciaModel;
		}

		/// <summary>
		/// Actualiza un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="CicloTransferenciaModel"></param>
		/// <returns>booleano indicando si la operación fue exitosa o no</returns>
		public bool ActualizarCicloTransferencia(CicloTransferenciaModel CicloTransferenciaModel)
		{
			bool result = false;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"UPDATE Dbo.CicloTransferencia SET DiasTransferencia=@DiasTransferencia, ActualizadoPor=@ActualizadoPor, FechaActualizacion=@FechaActualizacion ";
				int i = db.Execute(query, CicloTransferenciaModel);
                result = i >= 0;
			}
			return result;
		}
		/// <summary>
		/// Elimina un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="creadoPor"></param>
/// <returns>booleano indicando si la operación fue exitosa o no</returns>
		public bool EliminarCicloTransferencia(string creadoPor)
		{
			bool result = false;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"DELETE FROM Dbo.CicloTransferencia WHERE CreadoPor = @CreadoPor ";
                int i = db.Execute(query, new { CreadoPor=creadoPor });
				result = i >= 1;
			}
			return result;
		}
	}
}

