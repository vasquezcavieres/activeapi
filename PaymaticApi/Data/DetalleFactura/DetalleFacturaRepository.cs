






/**
* (c)2013-2023 CodeBase Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*25-10-2023,Generador de Código, Clase Inicial 
*/


using Cl.Intertrade.ActivPay.Helpers.Base;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Cl.Intertrade.ActivPay.Entities.DetalleFactura;
using System.Collections.Generic;
using System.Linq;

namespace Cl.Intertrade.ActivPay.Repository.DetalleFactura
{
	/// <summary>
	/// Esta Clase DetalleFactura  permite gestionar la interacción con la base de datos para la tabla DetalleFactura
	/// </summary>
	public partial class DetalleFacturaRepository : DBBaseHelper, IDetalleFacturaRepository
	{	

			public DetalleFacturaRepository(ISettingsConfig settings) : base(settings)
			{
				this.settingsConfig = settings;
			}

		/// <summary>
		/// Consulta todos los elementos existentes
		/// </summary>
		/// <returns>Una lista de objetos</returns>
		public IList<DetalleFacturaModel> ObtenerDetalleFacturas( )
		{
			IList<DetalleFacturaModel> result;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"Select NumeroFactura, TransferenciaId, TotalTransferencia, CostoComision, MontoTransferencia, FechaTransferencia  FROM Dbo.DetalleFactura";
				result = db.Query<DetalleFacturaModel>(query).AsList();
			}
			return result;       
		}
		/// <summary>
		/// Consulta una colección de elementos según parámetros de busqueda
		/// </summary>
		/// <param name="numeroFactura"></param>
/// <param name="transferenciaId"></param>
/// <returns>Una lista de objetos para la busqueda especificada</returns>
		public IList<DetalleFacturaModel> BuscarDetalleFacturas( int numeroFactura)
		{
			IList<DetalleFacturaModel> result;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"Select NumeroFactura, TransferenciaId, TotalTransferencia, CostoComision, MontoTransferencia, FechaTransferencia  FROM Dbo.DetalleFactura WHERE  NumeroFactura = @NumeroFactura ";
				result = db.Query<DetalleFacturaModel>(query, new { NumeroFactura=numeroFactura }).AsList();
			}
			return result;       
		}
		/// <summary>
        /// Consulta un único elemento según clave especificada
        /// </summary>
        /// <param name="numeroFactura"></param>
/// <param name="transferenciaId"></param>
/// <returns>Un objeto de persistencia para la clave especificada</returns>
		public DetalleFacturaModel ObtenerDetalleFactura(int numeroFactura, int transferenciaId)
		{
			DetalleFacturaModel result;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"Select NumeroFactura, TransferenciaId, TotalTransferencia, CostoComision, MontoTransferencia, FechaTransferencia  FROM Dbo.DetalleFactura WHERE  NumeroFactura = @NumeroFactura AND  TransferenciaId = @TransferenciaId ";
				result = db.QueryFirstOrDefault<DetalleFacturaModel>(query, new { NumeroFactura=numeroFactura, TransferenciaId=transferenciaId });
			}
			return result;                        
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="detalleFacturaModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
		public DetalleFacturaModel CrearDetalleFactura(DetalleFacturaModel detalleFacturaModel)
		{
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
		string query = @"INSERT INTO Dbo.DetalleFactura  (NumeroFactura, TransferenciaId, TotalTransferencia, CostoComision, MontoTransferencia, FechaTransferencia) VALUES (@NumeroFactura, @TransferenciaId, @TotalTransferencia, @CostoComision, @MontoTransferencia, @FechaTransferencia)";
		db.Execute(query, detalleFacturaModel);
						}
			return detalleFacturaModel;
		}

		/// <summary>
		/// Actualiza un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="detalleFacturaModel"></param>
		/// <returns>booleano indicando si la operación fue exitosa o no</returns>
		public bool ActualizarDetalleFactura(DetalleFacturaModel detalleFacturaModel)
		{
			bool result = false;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"UPDATE Dbo.DetalleFactura SET TotalTransferencia=@TotalTransferencia, CostoComision=@CostoComision, MontoTransferencia=@MontoTransferencia, FechaTransferencia=@FechaTransferencia WHERE NumeroFactura = @NumeroFactura AND  TransferenciaId = @TransferenciaId ";
				int i = db.Execute(query, detalleFacturaModel);
                result = i >= 0;
			}
			return result;
		}
		/// <summary>
		/// Elimina un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="numeroFactura"></param>
/// <param name="transferenciaId"></param>
/// <returns>booleano indicando si la operación fue exitosa o no</returns>
		public bool EliminarDetalleFactura(int numeroFactura, int transferenciaId)
		{
			bool result = false;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"DELETE FROM Dbo.DetalleFactura WHERE NumeroFactura = @NumeroFactura AND  TransferenciaId = @TransferenciaId ";
                int i = db.Execute(query, new { NumeroFactura=numeroFactura, TransferenciaId=transferenciaId });
				result = i >= 1;
			}
			return result;
		}
	}
}

