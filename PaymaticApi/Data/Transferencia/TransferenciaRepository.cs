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
using Cl.Intertrade.ActivPay.Entities.Transferencia;
using System.Collections.Generic;
using System.Linq;
using Cl.Intertrade.ActivPayApi.Models.Request.Dashboard;
using DapperQueryBuilder;

namespace Cl.Intertrade.ActivPay.Repository.Transferencia
{
    /// <summary>
    /// Esta Clase Transferencia  permite gestionar la interacción con la base de datos para la tabla Transferencia
    /// </summary>
    public partial class TransferenciaRepository : DBBaseHelper, ITransferenciaRepository
    {

        public TransferenciaRepository(ISettingsConfig settings) : base(settings)
        {
            this.settingsConfig = settings;
        }

        /// <summary>
        /// Consulta todos los elementos existentes
        /// </summary>
        /// <returns>Una lista de objetos</returns>
        public IList<TransferenciaModel> ObtenerTransferencias()
        {
            IList<TransferenciaModel> result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"SELECT [TransferenciaId],[TotalTransferencia],[CostoComision],[FechaTransferencia],[NumeroPagos]
                  ,[CodigoConvenio],[NumeroCuenta],[TipoCuenta],[Banco],[MontoTransferencia],[EmailNotificacion],[Estado] FROM Dbo.Transferencia";
                result = db.Query<TransferenciaModel>(query).AsList();
            }
            return result;
        }
        /// <summary>
        /// Consulta una colección de elementos según parámetros de busqueda
        /// </summary>
        /// <param name="transferenciaId"></param>
        /// <returns>Una lista de objetos para la busqueda especificada</returns>
        public IList<TransferenciaModel> BuscarTransferencias(int transferenciaId)
        {
            IList<TransferenciaModel> result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"SELECT [TransferenciaId],[TotalTransferencia],[CostoComision],[FechaTransferencia],[NumeroPagos]
                  ,[CodigoConvenio],[NumeroCuenta],[TipoCuenta],[Banco],[MontoTransferencia],[EmailNotificacion],[Estado] WHERE  TransferenciaId = @TransferenciaId ";
                result = db.Query<TransferenciaModel>(query, new { TransferenciaId = transferenciaId }).AsList();
            }
            return result;
        }


        public IList<TransferenciaModel> BuscarTransferenciasPorConvenio(int codigoConvenio)
        {
            IList<TransferenciaModel> result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"SELECT [TransferenciaId]
                  ,[TotalTransferencia]
                  ,[CostoComision]
                  ,[FechaTransferencia]
                  ,[NumeroPagos]
                  ,[CodigoConvenio]
                  ,[NumeroCuenta]
                  ,[TipoCuenta]
                  ,[Banco]
                  ,[MontoTransferencia]
                  ,[EmailNotificacion]
                  ,[Estado]
              FROM [dbo].[Transferencia] WHERE  CodigoConvenio = @CodigoConvenio ";
                result = db.Query<TransferenciaModel>(query, new { CodigoConvenio = codigoConvenio }).AsList();
            }
            return result;
        }


        public IList<TransferenciaModel> BuscarTransferenciasPorEdificio(string codigoEdificio)
        {
            IList<TransferenciaModel> result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"SELECT [TransferenciaId]
                  ,[TotalTransferencia]
                  ,[CostoComision]
                  ,[FechaTransferencia]
                  ,[NumeroPagos]
                  ,[CodigoConvenio]
                  ,[NumeroCuenta]
                  ,[TipoCuenta]
                  ,[Banco]
                  ,[MontoTransferencia]
                  ,[EmailNotificacion]
                  ,[Estado],
                    CodigoEdificio,
                    NombreEdificio
              FROM [dbo].[Transferencia] WHERE  CodigoEdificio = @CodigoEdificio ";
                result = db.Query<TransferenciaModel>(query, new {CodigoEdificio = codigoEdificio }).AsList();
            }
            return result;
        }



        /// <summary>
        /// Consulta un único elemento según clave especificada
        /// </summary>
        /// <param name="transferenciaId"></param>
        /// <returns>Un objeto de persistencia para la clave especificada</returns>
        public TransferenciaModel ObtenerTransferencia(int transferenciaId)
        {
            TransferenciaModel result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"SELECT [TransferenciaId],[TotalTransferencia],[CostoComision],[FechaTransferencia],[NumeroPagos]
                  ,[CodigoConvenio],[NumeroCuenta],[TipoCuenta],[Banco],[MontoTransferencia],[EmailNotificacion],[Estado] FROM Dbo.Transferencia WHERE  TransferenciaId = @TransferenciaId ";
                result = db.QueryFirstOrDefault<TransferenciaModel>(query, new { TransferenciaId = transferenciaId });
            }
            return result;
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="transferenciaModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        public TransferenciaModel CrearTransferencia(TransferenciaModel transferenciaModel)
        {
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"INSERT INTO Dbo.Transferencia  ( TotalTransferencia, CostoComision, FechaTransferencia,NumeroPagos,CodigoConvenio,NumeroCuenta,CodigoTipoCuenta,TipoCuenta,CodigoBanco,Banco,MontoTransferencia,EmailNotificacion,Estado,Facturada,CodigoEdificio,NombreEdificio) 
                                VALUES ( @TotalTransferencia, @CostoComision, @FechaTransferencia,@NumeroPagos,@CodigoConvenio,@NumeroCuenta,@CodigoTipoCuenta,@TipoCuenta,@CodigoBanco,@Banco,@MontoTransferencia,@EmailNotificacion,@Estado,@Facturada,@CodigoEdificio,@NombreEdificio);
                                SELECT CAST(SCOPE_IDENTITY() as int)";
                int transferenciaId = db.QuerySingle<int>(query, transferenciaModel);
                transferenciaModel.TransferenciaId = transferenciaId;
            }
            return transferenciaModel;
        }

        /// <summary>
        /// Actualiza un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="transferenciaModel"></param>
        /// <returns>booleano indicando si la operación fue exitosa o no</returns>
        public bool ActualizarTransferencia(TransferenciaModel transferenciaModel)
        {
            bool result = false;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"UPDATE Dbo.Transferencia SET TotalTransferencia=@TotalTransferencia, CostoComision=@CostoComision, FechaTransferencia=@FechaTransferencia WHERE TransferenciaId = @TransferenciaId ";
                int i = db.Execute(query, transferenciaModel);
                result = i >= 0;
            }
            return result;
        }
        /// <summary>
        /// Elimina un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="transferenciaId"></param>
        /// <returns>booleano indicando si la operación fue exitosa o no</returns>
        public bool EliminarTransferencia(int transferenciaId)
        {
            bool result = false;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"DELETE FROM Dbo.Transferencia WHERE TransferenciaId = @TransferenciaId ";
                int i = db.Execute(query, new { TransferenciaId = transferenciaId });
                result = i >= 1;
            }
            return result;
        }

        public bool AprobarTransferencia(int transferenciaId)
        {
            bool result = false;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"UPDATE TRANSFERENCIA SET Estado = 'APROBADO' WHERE TransferenciaId = @TransferenciaId ";
                int i = db.Execute(query, new { TransferenciaId = transferenciaId });
                result = i >= 1;
            }
            return result;
        }

        public IList<TransferenciaModel> ObtenerTransferencias(TransferenciaModel transferenciaModel)
        {
            IList<TransferenciaModel> result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                var query = db.QueryBuilder($"SELECT [TransferenciaId],[TotalTransferencia],[CostoComision],[FechaTransferencia],[NumeroPagos],[CodigoConvenio],[NumeroCuenta],[TipoCuenta],[Banco],[MontoTransferencia],[EmailNotificacion],[Estado],CodigoEdificio from Transferencia WHERE 1 = 1");


                if (transferenciaModel.CodigoConvenio > 0)
                {
                    query.Append($" And CodigoConvenio = {transferenciaModel.CodigoConvenio} ");
                }
                if (!string.IsNullOrEmpty(transferenciaModel.CodigoEdificio))
                {
                    query.Append($" And CodigoEdificio = {transferenciaModel.CodigoEdificio} ");
                }

                if (transferenciaModel.FechaDesde > DateTime.MinValue)
                {
                    query.Append($" And FechaTransferencia >= {transferenciaModel.FechaDesde} ");
                }

                if (transferenciaModel.FechaHasta > DateTime.MinValue)
                {
                    query.Append($" And FechaTransferencia <= {transferenciaModel.FechaHasta} ");
                }
                result = query.Query<TransferenciaModel>().AsList();
            }
            return result;
        }

    }
}

