/**
* (c)2013-2023 CodeBase Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*27-09-2023,Generador de Código, Clase Inicial 
*/


using Cl.Intertrade.ActivPay.Helpers.Base;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Cl.Intertrade.ActivPay.Entities.Pago;
using System.Collections.Generic;
using System.Linq;
using DapperQueryBuilder;
using Cl.Intertrade.ActivPayApi.Models.Request.Dashboard;
using Cl.Intertrade.ActivPay.Entities.Edificio;

namespace Cl.Intertrade.ActivPay.Repository.Pago
{
    /// <summary>
    /// Esta Clase Pago  permite gestionar la interacción con la base de datos para la tabla Pago
    /// </summary>
    public partial class PagoRepository : DBBaseHelper, IPagoRepository
    {

        public PagoRepository(ISettingsConfig settings) : base(settings)
        {
            this.settingsConfig = settings;
        }

        /// <summary>
        /// Consulta todos los elementos existentes
        /// </summary>
        /// <returns>Una lista de objetos</returns>
        public IList<PagoModel> ObtenerPagos(PagoModel pagoModel)
        {
            IList<PagoModel> result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                var query = db.QueryBuilder($"Select PagoId, VendedorId, NombreVendedor, TokenTransaccion, TokenMedioPago, 'ActivPay'  as CodigoMedioPago, NumeroOrden, EmailCliente, NombreCliente, MontoPago, FechaTransaccion, CodigoEdificio, CodigoArea, NombreEdificio, DireccionEdificio, CiudadEdificio, ComunaEdificio, CentroCosto, Exitoso, CodigoAutorizacion, FechaPago, MesPago, AnioPago, NumeroTarjeta, Notificado, CodigoNotificacion, NumeroBoleta, UrlBoleta, FechaBoleta, CodigoPais, Pais, UltimoIntento, BoletaAux, Firma,CodigoConvenio  From Pago WHERE 1 = 1 AND CodigoEdificio like '%act%' and exitoso = 1  ");

                if (pagoModel.CodigoConvenio>0)
                {
                    query.Append($" And CodigoConvenio  = {pagoModel.CodigoConvenio} ");
                }

                if (!string.IsNullOrEmpty(pagoModel.CodigoEdificio))
                {
                    query.Append($" And CodigoEdificio  = {pagoModel.CodigoEdificio} ");
                }

                if (pagoModel.FechaDesde > DateTime.MinValue)
                {
                    query.Append($" And  CONVERT(varchar, FechaTransaccion,112) >= '{pagoModel.FechaDesde.ToString("yyyyMMdd")}'");
                }

                if (pagoModel.FechaHasta > DateTime.MinValue)
                {
                    query.Append($" And  CONVERT(varchar, FechaTransaccion,112) <= '{pagoModel.FechaHasta.ToString("yyyyMMdd")}' ");
                }
                result = query.Query<PagoModel>().AsList();
            }
            return result;
        }

        public IList<PagoModel> ObtenerPagosEdificio(EdificioModel edificioModel)
        {
            IList<PagoModel> result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                var query = db.QueryBuilder($"Select PagoId, VendedorId, NombreVendedor, TokenTransaccion, TokenMedioPago,'ActivPay'  as  CodigoMedioPago, NumeroOrden, EmailCliente, NombreCliente, MontoPago, FechaTransaccion, CodigoEdificio, CodigoArea, NombreEdificio, DireccionEdificio, CiudadEdificio, ComunaEdificio, CentroCosto, Exitoso, CodigoAutorizacion, FechaPago, MesPago, AnioPago, NumeroTarjeta, Notificado, CodigoNotificacion, NumeroBoleta, UrlBoleta, FechaBoleta, CodigoPais, Pais, UltimoIntento, BoletaAux, Firma ,CodigoConvenio   From Pago WHERE 1 = 1 AND CodigoEdificio like '%act%' and exitoso = 1 ");

                if(!string.IsNullOrEmpty(edificioModel.CodigoEdificio))
                {
                    query.Append($" And CodigoEdificio = {edificioModel.CodigoEdificio} ");
                }

                if (edificioModel.FechaDesde > DateTime.MinValue)
                {
                    query.Append($" And  CONVERT(varchar, FechaTransaccion,112) >=  '{edificioModel.FechaDesde.Value.ToString("yyyyMMdd")}' ");
                }

                if (edificioModel.FechaHasta > DateTime.MinValue)
                {
                    query.Append($" And  CONVERT(varchar, FechaTransaccion,112) <= '{edificioModel.FechaHasta.Value.ToString("yyyyMMdd")}'");
                }
                result = query.Query<PagoModel>().AsList();
            }
            return result;
        }

        public IList<PagoModel> BuscarDashboard(DashboardRequest dashboardRequest)
        {
            IList<PagoModel> result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {                
                var query = db.QueryBuilder($"SELECT p.CodigoEdificio, sum(p.MontoPago) as MontoPago, e.MaquinasInstaladas,p.codigoConvenio From Pago p INNER JOIN Edificio e on p.CodigoEdificio = e.CodigoEdificio WHERE 1 = 1 AND e.CodigoEdificio like '%act%' and exitoso = 1 ");

                if (dashboardRequest.CodigoConvenio != 0)
                {
                    query.Append($" And CodigoConvenio = {dashboardRequest.CodigoConvenio} ");
                }
                if (!string.IsNullOrEmpty(dashboardRequest.CodigoEdificio))
                {
                    query.Append($" And e.CodigoEdificio  = {dashboardRequest.CodigoEdificio} ");
                }

                if (dashboardRequest.FechaDesde > DateTime.MinValue)
                {
                    query.Append($" And CONVERT(varchar, FechaTransaccion,112) >= '{dashboardRequest.FechaDesde.ToString("yyyyMMdd")}' ");
                }

                if (dashboardRequest.FechaHasta > DateTime.MinValue)
                {
                    query.Append($" And CONVERT(varchar, FechaTransaccion,112) <= '{dashboardRequest.FechaHasta.ToString("yyyyMMdd")}'");
                }



                query.Append($" GROUP BY p.CodigoEdificio,p.codigoConvenio, e.MaquinasInstaladas");
                result = query.Query<PagoModel>().AsList();
            }
            return result;
        }

        public IList<PagoModel> BuscarDashboardNoFacturado(DashboardRequest dashboardRequest)
        {
            IList<PagoModel> result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                var query = db.QueryBuilder($"SELECT p.CodigoEdificio, sum(p.MontoPago) as MontoPago, e.MaquinasInstaladas FROM pago p INNER JOIN Edificio e on p.CodigoEdificio = e.CodigoEdificio WHERE 1 = 1 and exitoso = 1  AND PagoId not in (SELECT PagoId from DetalleTransferencia)");

                if (dashboardRequest.CodigoConvenio != 0)
                {
                    query.Append($" And p.CodigoConvenio  = {dashboardRequest.CodigoConvenio} ");
                }
                if (!string.IsNullOrEmpty(dashboardRequest.CodigoEdificio))
                {
                    query.Append($" And p.CodigoEdificio  = {dashboardRequest.CodigoEdificio} ");
                }

                //if (dashboardRequest.FechaDesde > DateTime.MinValue)
                //{
                //    query.Append($" And FechaTransaccion >= {dashboardRequest.FechaDesde} ");
                //}

                //if (dashboardRequest.FechaHasta > DateTime.MinValue)
                //{
                //    query.Append($" And FechaTransaccion <= {dashboardRequest.FechaHasta} ");
                //}

                query.Append($" GROUP BY p.CodigoEdificio, e.MaquinasInstaladas");
                result = query.Query<PagoModel>().AsList();
            }
            return result;
        }


        /// <summary>
        /// Consulta una colección de elementos según parámetros de busqueda
        /// </summary>
        /// <param name="pagoId"></param>
        /// <returns>Una lista de objetos para la busqueda especificada</returns>
        public IList<PagoModel> BuscarPagos(string pagoId)
        {
            IList<PagoModel> result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"Select PagoId, VendedorId, NombreVendedor, TokenTransaccion, TokenMedioPago,'ActivPay'  as  CodigoMedioPago, NumeroOrden, EmailCliente, NombreCliente, MontoPago, FechaTransaccion, CodigoEdificio, CodigoArea, NombreEdificio, DireccionEdificio, CiudadEdificio, ComunaEdificio, CentroCosto, Exitoso, CodigoAutorizacion, FechaPago, MesPago, AnioPago, NumeroTarjeta, Notificado, CodigoNotificacion, NumeroBoleta, UrlBoleta, FechaBoleta, CodigoPais, Pais, UltimoIntento, BoletaAux, Firma  FROM Dbo.Pago WHERE  PagoId = @PagoId and exitoso = 1  ";
                result = db.Query<PagoModel>(query, new { PagoId = pagoId }).AsList();
            }
            return result;
        }

        public IList<PagoModel> BuscarPagosEdificio(string codigoEdificio)
        {
            IList<PagoModel> result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"Select PagoId, VendedorId, NombreVendedor, TokenTransaccion, TokenMedioPago,'ActivPay'  as  CodigoMedioPago, NumeroOrden, EmailCliente, NombreCliente, MontoPago, FechaTransaccion, CodigoEdificio, CodigoArea, NombreEdificio, DireccionEdificio, CiudadEdificio, ComunaEdificio, CentroCosto, Exitoso, CodigoAutorizacion, FechaPago, MesPago, AnioPago, NumeroTarjeta, Notificado, CodigoNotificacion, NumeroBoleta, UrlBoleta, FechaBoleta, CodigoPais, Pais, UltimoIntento, BoletaAux, Firma  FROM Dbo.Pago WHERE  CodigoEdificio = @CodigoEdificio and exitoso = 1  ";
                result = db.Query<PagoModel>(query, new { CodigoEdificio = codigoEdificio }).AsList();
            }
            return result;
        }

        public IList<PagoModel> BuscarPagosConvenio(string codigoConvenio)
        {
            IList<PagoModel> result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"Select PagoId, VendedorId, NombreVendedor, TokenTransaccion, TokenMedioPago,'ActivPay'  as  CodigoMedioPago, NumeroOrden, EmailCliente, NombreCliente, MontoPago, FechaTransaccion, CodigoEdificio, CodigoArea, NombreEdificio, DireccionEdificio, CiudadEdificio, ComunaEdificio, CentroCosto, Exitoso, CodigoAutorizacion, FechaPago, MesPago, AnioPago, NumeroTarjeta, Notificado, CodigoNotificacion, NumeroBoleta, UrlBoleta, FechaBoleta, CodigoPais, Pais, UltimoIntento, BoletaAux, Firma  FROM Dbo.Pago WHERE  CodigoConvenio = @CodigoConvenio and exitoso = 1  ";
                result = db.Query<PagoModel>(query, new { CodigoConvenio = codigoConvenio }).AsList();
            }
            return result;
        }

        /// <summary>
        /// Consulta un único elemento según clave especificada
        /// </summary>
        /// <param name="pagoId"></param>
        /// <returns>Un objeto de persistencia para la clave especificada</returns>
        public PagoModel ObtenerPago(string pagoId)
        {
            PagoModel result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"Select PagoId, VendedorId, NombreVendedor, TokenTransaccion, TokenMedioPago,'ActivPay'  as  CodigoMedioPago, NumeroOrden, EmailCliente, NombreCliente, MontoPago, FechaTransaccion, CodigoEdificio, CodigoArea, NombreEdificio, DireccionEdificio, CiudadEdificio, ComunaEdificio, CentroCosto, Exitoso, CodigoAutorizacion, FechaPago, MesPago, AnioPago, NumeroTarjeta, Notificado, CodigoNotificacion, NumeroBoleta, UrlBoleta, FechaBoleta, CodigoPais, Pais, UltimoIntento, BoletaAux, Firma  FROM Dbo.Pago WHERE  PagoId = @PagoId and exitoso = 1  ";
                result = db.QueryFirstOrDefault<PagoModel>(query, new { PagoId = pagoId });
            }
            return result;
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="pagoModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        public PagoModel CrearPago(PagoModel pagoModel)
        {
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"INSERT INTO Dbo.Pago (PagoId, VendedorId, NombreVendedor, TokenTransaccion, TokenMedioPago, CodigoMedioPago, EmailCliente, NombreCliente, MontoPago, FechaTransaccion, CodigoEdificio, CodigoArea, NombreEdificio, DireccionEdificio, CiudadEdificio, ComunaEdificio, CentroCosto, Exitoso, CodigoAutorizacion, FechaPago, MesPago, AnioPago, NumeroTarjeta, Notificado, CodigoNotificacion, NumeroBoleta, UrlBoleta, FechaBoleta, CodigoPais, Pais, UltimoIntento, BoletaAux, Firma) VALUES (@PagoId, @VendedorId, @NombreVendedor, @TokenTransaccion, @TokenMedioPago, @CodigoMedioPago, @EmailCliente, @NombreCliente, @MontoPago, @FechaTransaccion, @CodigoEdificio, @CodigoArea, @NombreEdificio, @DireccionEdificio, @CiudadEdificio, @ComunaEdificio, @CentroCosto, @Exitoso, @CodigoAutorizacion, @FechaPago, @MesPago, @AnioPago, @NumeroTarjeta, @Notificado, @CodigoNotificacion, @NumeroBoleta, @UrlBoleta, @FechaBoleta, @CodigoPais, @Pais, @UltimoIntento, @BoletaAux, @Firma); SELECT CAST(SCOPE_IDENTITY() as int)";
                var result = db.Query<int>(query, pagoModel);
                var identity = result.FirstOrDefault();
                pagoModel.NumeroOrden = identity;
            }
            return pagoModel;
        }

        /// <summary>
        /// Actualiza un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="pagoModel"></param>
        /// <returns>booleano indicando si la operación fue exitosa o no</returns>
        public bool ActualizarPago(PagoModel pagoModel)
        {
            bool result = false;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"UPDATE Dbo.Pago SET VendedorId=@VendedorId, NombreVendedor=@NombreVendedor, TokenTransaccion=@TokenTransaccion, TokenMedioPago=@TokenMedioPago, CodigoMedioPago=@CodigoMedioPago, NumeroOrden=@NumeroOrden, EmailCliente=@EmailCliente, NombreCliente=@NombreCliente, MontoPago=@MontoPago, FechaTransaccion=@FechaTransaccion, CodigoEdificio=@CodigoEdificio, CodigoArea=@CodigoArea, NombreEdificio=@NombreEdificio, DireccionEdificio=@DireccionEdificio, CiudadEdificio=@CiudadEdificio, ComunaEdificio=@ComunaEdificio, CentroCosto=@CentroCosto, Exitoso=@Exitoso, CodigoAutorizacion=@CodigoAutorizacion, FechaPago=@FechaPago, MesPago=@MesPago, AnioPago=@AnioPago, NumeroTarjeta=@NumeroTarjeta, Notificado=@Notificado, CodigoNotificacion=@CodigoNotificacion, NumeroBoleta=@NumeroBoleta, UrlBoleta=@UrlBoleta, FechaBoleta=@FechaBoleta, CodigoPais=@CodigoPais, Pais=@Pais, UltimoIntento=@UltimoIntento, BoletaAux=@BoletaAux, Firma=@Firma WHERE PagoId = @PagoId ";
                int i = db.Execute(query, pagoModel);
                result = i >= 0;
            }
            return result;
        }
        /// <summary>
        /// Elimina un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="pagoId"></param>
        /// <returns>booleano indicando si la operación fue exitosa o no</returns>
        public bool EliminarPago(string pagoId)
        {
            bool result = false;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"DELETE FROM Dbo.Pago WHERE PagoId = @PagoId ";
                int i = db.Execute(query, new { PagoId = pagoId });
                result = i >= 1;
            }
            return result;
        }



        public IList<PagoModel> BuscarPagosProcesoTrasnferencia()
        {
            IList<PagoModel> result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"Select PagoId, VendedorId, NombreVendedor, TokenTransaccion, TokenMedioPago, CodigoMedioPago,
                                 NumeroOrden, EmailCliente, NombreCliente, MontoPago, FechaTransaccion, p.CodigoEdificio,p.CodigoArea, 
                                 NombreEdificio, DireccionEdificio, CiudadEdificio, ComunaEdificio, p.CentroCosto, Exitoso, CodigoAutorizacion, 
                                 FechaPago, MesPago, AnioPago, NumeroTarjeta, Notificado, CodigoNotificacion, NumeroBoleta, UrlBoleta, FechaBoleta, 
                                 p.CodigoPais, p.Pais, UltimoIntento, BoletaAux, Firma,e.MaquinasInstaladas
                                 FROM Dbo.Pago p
                                 INNER JOIN Edificio e on p.CodigoEdificio = e.CodigoEdificio
                                 WHERE  p.CodigoEdificio like '%act%' 
                                 AND p.exitoso = 1 
                               ";
                result = db.Query<PagoModel>(query, null).AsList();
            }
            return result;
        }
    }
}

