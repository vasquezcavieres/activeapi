






/**
* (c)2013-2023 CodeBase Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*14-11-2023,Generador de Código, Clase Inicial 
*/

using Dapper;
using System.Data;
using System.Data.SqlClient;
using Cl.Intertrade.ActivPayApi.Entities.ArchivoPagoProveedores;
using System.Collections.Generic;
using System.Linq;
using Cl.Intertrade.ActivPay.Helpers.Base;

namespace Cl.Intertrade.ActivPayApi.Repository.ArchivoPagoProveedores
{
	/// <summary>
	/// Esta Clase ArchivoPagoProveedores  permite gestionar la interacción con la base de datos para la tabla ArchivoPagoProveedores
	/// </summary>
	public partial class ArchivoPagoProveedoresRepository : DBBaseHelper, IArchivoPagoProveedoresRepository
	{	

			public ArchivoPagoProveedoresRepository(ISettingsConfig settings) : base(settings)
			{
				this.settingsConfig = settings;
			}

		/// <summary>
		/// Consulta todos los elementos existentes
		/// </summary>
		/// <returns>Una lista de objetos</returns>
		public IList<ArchivoPagoProveedoresModel> ObtenerArchivoPagoProveedoress( )
		{
			IList<ArchivoPagoProveedoresModel> result;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"Select NumeroArchivo, NombreArchivo, NumeroTransferencias, FechaCreacion, RutaArchivo  FROM Dbo.ArchivoPagoProveedores";
				result = db.Query<ArchivoPagoProveedoresModel>(query).AsList();
			}
			return result;       
		}
		/// <summary>
		/// Consulta una colección de elementos según parámetros de busqueda
		/// </summary>
		/// <returns>Una lista de objetos para la busqueda especificada</returns>
		public IList<ArchivoPagoProveedoresModel> BuscarArchivoPagoProveedoress( )
		{
			IList<ArchivoPagoProveedoresModel> result;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"Select NumeroArchivo, NombreArchivo, NumeroTransferencias, FechaCreacion, RutaArchivo  FROM Dbo.ArchivoPagoProveedores WHERE  ";
				result = db.Query<ArchivoPagoProveedoresModel>(query, new {  }).AsList();
			}
			return result;       
		}
		/// <summary>
        /// Consulta un único elemento según clave especificada
        /// </summary>
        /// <returns>Un objeto de persistencia para la clave especificada</returns>
		public ArchivoPagoProveedoresModel ObtenerArchivoPagoProveedores(int numeroArchivo )
		{
			ArchivoPagoProveedoresModel result;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"Select NumeroArchivo, NombreArchivo, NumeroTransferencias, FechaCreacion, RutaArchivo  FROM Dbo.ArchivoPagoProveedores WHERE  NumeroArchivo = @NumeroArchivo";
				result = db.QueryFirstOrDefault<ArchivoPagoProveedoresModel>(query, new { NumeroArchivo = numeroArchivo });
			}
			return result;                        
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="archivoPagoProveedoresModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
		public ArchivoPagoProveedoresModel CrearArchivoPagoProveedores(ArchivoPagoProveedoresModel archivoPagoProveedoresModel)
		{
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"INSERT INTO Dbo.ArchivoPagoProveedores  (NombreArchivo, NumeroTransferencias, FechaCreacion, RutaArchivo) VALUES (@NombreArchivo, @NumeroTransferencias, @FechaCreacion, @RutaArchivo)";
                db.Execute(query, archivoPagoProveedoresModel);
            }
            return archivoPagoProveedoresModel;
		}

		/// <summary>
		/// Actualiza un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="archivoPagoProveedoresModel"></param>
		/// <returns>booleano indicando si la operación fue exitosa o no</returns>
		public bool ActualizarArchivoPagoProveedores(ArchivoPagoProveedoresModel archivoPagoProveedoresModel)
		{
			bool result = false;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"UPDATE Dbo.ArchivoPagoProveedores SET NumeroArchivo=@NumeroArchivo, NombreArchivo=@NombreArchivo, NumeroTransferencias=@NumeroTransferencias, FechaCreacion=@FechaCreacion, RutaArchivo=@RutaArchivo WHERE ";
				int i = db.Execute(query, archivoPagoProveedoresModel);
                result = i >= 0;
			}
			return result;
		}
		/// <summary>
		/// Elimina un elemento desde el medio de persistencia
		/// </summary>
		/// <returns>booleano indicando si la operación fue exitosa o no</returns>
		public bool EliminarArchivoPagoProveedores()
		{
			bool result = false;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"DELETE FROM Dbo.ArchivoPagoProveedores WHERE ";
                int i = db.Execute(query, new {  });
				result = i >= 1;
			}
			return result;
		}
	}
}

