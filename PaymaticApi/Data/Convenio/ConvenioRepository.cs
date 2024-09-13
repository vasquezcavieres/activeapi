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
using Cl.Intertrade.ActivPay.Entities.Convenio;
using System.Collections.Generic;
using System.Linq;

namespace Cl.Intertrade.ActivPay.Repository.Convenio
{
    /// <summary>
    /// Esta Clase Convenio  permite gestionar la interacción con la base de datos para la tabla Convenio
    /// </summary>
    public partial class ConvenioRepository : DBBaseHelper, IConvenioRepository
    {

        public ConvenioRepository(ISettingsConfig settings) : base(settings)
        {
            this.settingsConfig = settings;
        }

        /// <summary>
        /// Consulta todos los elementos existentes
        /// </summary>
        /// <returns>Una lista de objetos</returns>
        public IList<ConvenioModel> ObtenerConvenios()
        {
            IList<ConvenioModel> result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"Select RutRazonSocial, RutRazonSocialDv, NombrerazonSocial, NombreAdministradora, Direccion, Comuna, Region, RepresentanteLegal, RutRepresentanteLegal, RutRepresentanteLegalDv, NumeroCuenta, TipoCuenta, Banco, CorreoContacto, VendedorId, PorcentajeComision, EmailNotificacion,MinimoGarantizadoComision,Giro  FROM Dbo.Convenio";
                result = db.Query<ConvenioModel>(query).AsList();
            }
            return result;
        }
        /// <summary>
        /// Consulta una colección de elementos según parámetros de busqueda
        /// </summary>
        /// <param name="rutRazonSocial"></param>
        /// <returns>Una lista de objetos para la busqueda especificada</returns>
        public IList<ConvenioModel> BuscarConvenios(int rutRazonSocial)
        {
            IList<ConvenioModel> result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"Select RutRazonSocial, RutRazonSocialDv, NombrerazonSocial, NombreAdministradora, Direccion, Comuna, Region, RepresentanteLegal, RutRepresentanteLegal, RutRepresentanteLegalDv, NumeroCuenta, TipoCuenta, Banco, CorreoContacto, VendedorId, PorcentajeComision, EmailNotificacion,MinimoGarantizadoComision,Giro FROM Dbo.Convenio WHERE  RutRazonSocial = @RutRazonSocial ";
                result = db.Query<ConvenioModel>(query, new { RutRazonSocial = rutRazonSocial }).AsList();
            }
            return result;
        }
        /// <summary>
        /// Consulta un único elemento según clave especificada
        /// </summary>
        /// <param name="rutRazonSocial"></param>
        /// <returns>Un objeto de persistencia para la clave especificada</returns>
        public ConvenioModel ObtenerConvenio(int rutRazonSocial)
        {
            ConvenioModel result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"Select RutRazonSocial, RutRazonSocialDv, NombrerazonSocial, NombreAdministradora, Direccion, Comuna, Region, RepresentanteLegal, RutRepresentanteLegal, RutRepresentanteLegalDv, NumeroCuenta, TipoCuenta, Banco, CorreoContacto, VendedorId, PorcentajeComision, EmailNotificacion, RutAdministrador,MinimoGarantizadoComision,Giro  FROM Dbo.Convenio WHERE  RutRazonSocial = @RutRazonSocial ";
                result = db.QueryFirstOrDefault<ConvenioModel>(query, new { RutRazonSocial = rutRazonSocial });
            }
            return result;
        }

        public ConvenioModel ObtenerConvenioPorEdificio(string codigoEdificio)
        {
            ConvenioModel result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"SELECT c.[RutRazonSocial]
                                  ,[RutRazonSocialDv]
                                  ,[NombrerazonSocial]
                                  ,[NombreAdministradora]
                                  ,c.[Direccion]
                                  ,c.[Comuna]
                                  ,[Region]
                                  ,[RepresentanteLegal]
                                  ,[RutRepresentanteLegal]
                                  ,[RutRepresentanteLegalDv]
                                  ,e.[NumeroCuenta]
                                  ,e.[TipoCuenta]
                                  ,e.[Banco]
                                  ,e.[CorreoContacto]
                                  ,[VendedorId]
                                  ,[PorcentajeComision]
                                  ,e.[EmailNotificacion]
                                  ,[FechaCreacion]
                                  ,[RutAdministrador],MinimoGarantizadoComision,Giro
                              FROM [Convenio] c
                              inner join Edificio e on c.RutRazonSocial = e.RutRazonSocial
                              where e.CodigoEdificio = @CodigoEdificio";
                result = db.QueryFirstOrDefault<ConvenioModel>(query, new { CodigoEdificio = codigoEdificio });
            }
            return result;
        }

        public ConvenioModel ObtenerConvenioPorAdministrador(int rutAdministrador)
        {
            ConvenioModel result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"SELECT c.[RutRazonSocial]
                                  ,[RutRazonSocialDv]
                                  ,[NombrerazonSocial]
                                  ,[NombreAdministradora]
                                  ,[Direccion]
                                  ,[Comuna]
                                  ,[Region]
                                  ,[RepresentanteLegal]
                                  ,[RutRepresentanteLegal]
                                  ,[RutRepresentanteLegalDv]
                                  ,[NumeroCuenta]
                                  ,[TipoCuenta]
                                  ,[Banco]
                                  ,[CorreoContacto]
                                  ,[VendedorId]
                                  ,[PorcentajeComision]
                                  ,[EmailNotificacion]
                                  ,[FechaCreacion]
                                  ,[RutAdministrador]
                                    ,MinimoGarantizadoComision,Giro
                              FROM [Convenio] c                             
                              where RutAdministrador = @RutAdministrador";
                result = db.QueryFirstOrDefault<ConvenioModel>(query, new { RutAdministrador = rutAdministrador });
            }
            return result;
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="convenioModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        public ConvenioModel CrearConvenio(ConvenioModel convenioModel)
        {
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"INSERT INTO Dbo.Convenio  (RutRazonSocial, RutRazonSocialDv, NombrerazonSocial, NombreAdministradora, Direccion, Comuna, Region, RepresentanteLegal, RutRepresentanteLegal, RutRepresentanteLegalDv, NumeroCuenta, TipoCuenta, Banco, CorreoContacto, VendedorId, PorcentajeComision, EmailNotificacion,FechaCreacion,MinimoGarantizadoComision,Giro) VALUES (@RutRazonSocial, @RutRazonSocialDv, @NombrerazonSocial, @NombreAdministradora, @Direccion, @Comuna, @Region, @RepresentanteLegal, @RutRepresentanteLegal, @RutRepresentanteLegalDv, @NumeroCuenta, @TipoCuenta, @Banco, @CorreoContacto, @VendedorId, @PorcentajeComision, @EmailNotificacion,@FechaCreacion,@MinimoGarantizadoComision,@Giro)";
                db.Execute(query, convenioModel);
            }
            return convenioModel;
        }

        /// <summary>
        /// Actualiza un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="convenioModel"></param>
        /// <returns>booleano indicando si la operación fue exitosa o no</returns>
        public bool ActualizarConvenio(ConvenioModel convenioModel)
        {
            bool result = false;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"UPDATE Dbo.Convenio SET  NombrerazonSocial=@NombrerazonSocial, NombreAdministradora=@NombreAdministradora, Direccion=@Direccion, Comuna=@Comuna, Region=@Region, RepresentanteLegal=@RepresentanteLegal, RutRepresentanteLegal=@RutRepresentanteLegal, RutRepresentanteLegalDv=@RutRepresentanteLegalDv, NumeroCuenta=@NumeroCuenta, TipoCuenta=@TipoCuenta, Banco=@Banco, CorreoContacto=@CorreoContacto, VendedorId=@VendedorId, PorcentajeComision=@PorcentajeComision, EmailNotificacion=@EmailNotificacion, MinimoGarantizadoComision = @MinimoGarantizadoComision  ,Giro  = @Giro  WHERE RutRazonSocial = @RutRazonSocial ";
                int i = db.Execute(query, convenioModel);
                result = i >= 0;
            }
            return result;
        }
        /// <summary>
        /// Elimina un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="rutRazonSocial"></param>
        /// <returns>booleano indicando si la operación fue exitosa o no</returns>
        public bool EliminarConvenio(int rutRazonSocial)
        {
            bool result = false;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"DELETE FROM Dbo.Convenio WHERE RutRazonSocial = @RutRazonSocial ";
                int i = db.Execute(query, new { RutRazonSocial = rutRazonSocial });
                result = i >= 1;
            }
            return result;
        }


        public bool AsociarUsuarioAdministradaor(ConvenioModel convenioModel)
        {
            bool result = false;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"UPDATE Dbo.Convenio SET  RutAdministrador = @RutAdministrador WHERE RutRazonSocial = @RutRazonSocial ";
                int i = db.Execute(query, convenioModel);
                result = i >= 0;
            }
            return result;
        }
    }
}

