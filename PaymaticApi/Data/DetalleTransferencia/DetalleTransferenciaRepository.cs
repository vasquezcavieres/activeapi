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
using Cl.Intertrade.ActivPay.Entities.DetalleTransferencia;
using System.Collections.Generic;
using System.Linq;

namespace Cl.Intertrade.ActivPay.Repository.DetalleTransferencia
{
	/// <summary>
	/// Esta Clase DetalleTransferencia  permite gestionar la interacción con la base de datos para la tabla DetalleTransferencia
	/// </summary>
	public partial class DetalleTransferenciaRepository : DBBaseHelper, IDetalleTransferenciaRepository
	{	

			public DetalleTransferenciaRepository(ISettingsConfig settings) : base(settings)
			{
				this.settingsConfig = settings;
			}

		/// <summary>
		/// Consulta todos los elementos existentes
		/// </summary>
		/// <returns>Una lista de objetos</returns>
		public IList<DetalleTransferenciaModel> ObtenerDetalleTransferencias( )
		{
			IList<DetalleTransferenciaModel> result;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"Select TransferenciaId, RutRazonSocial, MontoTransferencia, PagoId,CostoComision  FROM Dbo.DetalleTransferencia";
				result = db.Query<DetalleTransferenciaModel>(query).AsList();
			}
			return result;       
		}
		/// <summary>
		/// Consulta una colección de elementos según parámetros de busqueda
		/// </summary>
		/// <param name="transferenciaId"></param>
/// <param name="rutRazonSocial"></param>
/// <returns>Una lista de objetos para la busqueda especificada</returns>
		public IList<DetalleTransferenciaModel> BuscarDetalleTransferencias( int transferenciaId, int rutRazonSocial)
		{
			IList<DetalleTransferenciaModel> result;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"Select TransferenciaId, RutRazonSocial, MontoTransferencia, PagoId,CostoComision    FROM Dbo.DetalleTransferencia WHERE  TransferenciaId = @TransferenciaId AND  RutRazonSocial = @RutRazonSocial ";
				result = db.Query<DetalleTransferenciaModel>(query, new { TransferenciaId=transferenciaId, RutRazonSocial=rutRazonSocial }).AsList();
			}
			return result;       
		}

        public IList<DetalleTransferenciaModel> BuscarDetalleTransferencias(int transferenciaId)
        {
            IList<DetalleTransferenciaModel> result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"Select TransferenciaId, RutRazonSocial, MontoTransferencia, PagoId,CostoComision,MontoPago    FROM Dbo.DetalleTransferencia WHERE  TransferenciaId = @TransferenciaId ";
                result = db.Query<DetalleTransferenciaModel>(query, new { TransferenciaId = transferenciaId }).AsList();
            }
            return result;
        }
        /// <summary>
        /// Consulta un único elemento según clave especificada
        /// </summary>
        /// <param name="transferenciaId"></param>
        /// <param name="rutRazonSocial"></param>
        /// <returns>Un objeto de persistencia para la clave especificada</returns>
        public DetalleTransferenciaModel ObtenerDetalleTransferencia(int transferenciaId, int rutRazonSocial)
		{
			DetalleTransferenciaModel result;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"Select TransferenciaId, RutRazonSocial, MontoTransferencia, PagoId,CostoComision  FROM Dbo.DetalleTransferencia WHERE  TransferenciaId = @TransferenciaId AND  RutRazonSocial = @RutRazonSocial ";
				result = db.QueryFirstOrDefault<DetalleTransferenciaModel>(query, new { TransferenciaId=transferenciaId, RutRazonSocial=rutRazonSocial });
			}
			return result;                        
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="detalleTransferenciaModel"></param>
		/// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
		public DetalleTransferenciaModel CrearDetalleTransferencia(DetalleTransferenciaModel detalleTransferenciaModel)
		{
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"INSERT INTO Dbo.DetalleTransferencia  (TransferenciaId, RutRazonSocial,PagoId,MontoPago,MontoTransferencia,CostoComision) VALUES (@TransferenciaId, @RutRazonSocial,@PagoId,@MontoPago,@MontoTransferencia,@CostoComision)";
                db.Execute(query, detalleTransferenciaModel);
            }
            return detalleTransferenciaModel;
		}

		/// <summary>
		/// Actualiza un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="detalleTransferenciaModel"></param>
		/// <returns>booleano indicando si la operación fue exitosa o no</returns>
		public bool ActualizarDetalleTransferencia(DetalleTransferenciaModel detalleTransferenciaModel)
		{
			bool result = false;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"UPDATE Dbo.DetalleTransferencia SET NumeroCuenta=@NumeroCuenta, TipoCuenta=@TipoCuenta, Banco=@Banco, MontoTransferencia=@MontoTransferencia, EmailNotificacion=@EmailNotificacion, PagoId=@PagoId, Estado=@Estado, FechaTransferencia=@FechaTransferencia WHERE TransferenciaId = @TransferenciaId AND  RutRazonSocial = @RutRazonSocial ";
				int i = db.Execute(query, detalleTransferenciaModel);
                result = i >= 0;
			}
			return result;
		}
		/// <summary>
		/// Elimina un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="transferenciaId"></param>
/// <param name="rutRazonSocial"></param>
/// <returns>booleano indicando si la operación fue exitosa o no</returns>
		public bool EliminarDetalleTransferencia(int transferenciaId, int rutRazonSocial)
		{
			bool result = false;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"DELETE FROM Dbo.DetalleTransferencia WHERE TransferenciaId = @TransferenciaId AND  RutRazonSocial = @RutRazonSocial ";
                int i = db.Execute(query, new { TransferenciaId=transferenciaId, RutRazonSocial=rutRazonSocial });
				result = i >= 1;
			}
			return result;
		}
	}
}

