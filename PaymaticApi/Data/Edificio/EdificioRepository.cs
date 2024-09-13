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
using Cl.Intertrade.ActivPay.Entities.Edificio;
using System.Collections.Generic;
using System.Linq;

namespace Cl.Intertrade.ActivPay.Repository.Edificio
{
    /// <summary>
    /// Esta Clase Edificio  permite gestionar la interacción con la base de datos para la tabla Edificio
    /// </summary>
    public partial class EdificioRepository : DBBaseHelper, IEdificioRepository
    {
        public EdificioRepository(ISettingsConfig settings) : base(settings)
        {
            this.settingsConfig = settings;
        }

        /// <summary>
        /// Consulta todos los elementos existentes
        /// </summary>
        /// <returns>Una lista de objetos</returns>
        public IList<EdificioModel> ObtenerEdificios()
        {
            IList<EdificioModel> result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"Select CodigoEdificio, CodigoArea, Nombre, CodigoPais, Pais, Direccion, Ciudad, Comuna, CentroCosto, RutRazonSocial,MaquinasInstaladas,NumeroCuenta,TipoCuenta,Banco,CorreoContacto,EmailNotificacion,
                                CodigoBanco,CodigoTipoCuenta as 'codigoTipoAbono',PorcentajeComision,MinimoGarantizadoComision,Giro 
                                FROM Dbo.Edificio where pais = 'Chile'
                                AND CodigoEdificio like '%act%' ";
                result = db.Query<EdificioModel>(query).AsList();
            }
            return result;
        }

        public IList<EdificioModel> ObtenerEdificiosAsociados()
        {
            IList<EdificioModel> result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"Select e.CodigoEdificio, e.CodigoArea, e.Nombre, e.CodigoPais, e.Pais, e.Direccion, e.Ciudad, e.Comuna, e.CentroCosto, e.RutRazonSocial,e.MaquinasInstaladas,e.NumeroCuenta,
                                e.TipoCuenta,e.CodigoTipoCuenta,e.CodigoBanco,e.Banco,e.CorreoContacto,e.EmailNotificacion ,e.PorcentajeComision,e.MinimoGarantizadoComision,e.Giro
                                FROM Dbo.Edificio e 
                                INNER JOIN Convenio c ON  e.RutRazonSocial = c.RutRazonSocial
                                WHERE Pais = 'Chile'
                                AND CodigoEdificio like '%act%' ";
                result = db.Query<EdificioModel>(query).AsList();
            }
            return result;
        }


        /// <summary>
        /// Consulta una colección de elementos según parámetros de busqueda
        /// </summary>
        /// <param name="codigoEdificio"></param>
        /// <returns>Una lista de objetos para la busqueda especificada</returns>
        public IList<EdificioModel> BuscarEdificios(string codigoEdificio)
        {
            IList<EdificioModel> result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"Select CodigoEdificio, CodigoArea, Nombre, CodigoPais, Pais, Direccion, Ciudad, Comuna, CentroCosto, RutRazonSocial,MaquinasInstaladas,NumeroCuenta,TipoCuenta,Banco,CorreoContacto,
                                 EmailNotificacion,CodigoBanco,CodigoTipoCuenta as 'codigoTipoAbono',PorcentajeComision,MinimoGarantizadoComision,Giro   FROM Dbo.Edificio WHERE  CodigoEdificio = @CodigoEdificio ";
                result = db.Query<EdificioModel>(query, new { CodigoEdificio = codigoEdificio }).AsList();
            }
            return result;
        }

        public IList<EdificioModel> BuscarEdificiosConvenio( int razonSocial)
        {
            IList<EdificioModel> result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"Select CodigoEdificio, CodigoArea, Nombre, CodigoPais, Pais, Direccion, Ciudad, Comuna, CentroCosto, RutRazonSocial ,MaquinasInstaladas,NumeroCuenta,TipoCuenta,Banco,CorreoContacto,EmailNotificacion,
                                CodigoBanco,CodigoTipoCuenta as 'codigoTipoAbono' ,PorcentajeComision,MinimoGarantizadoComision,Giro FROM Dbo.Edificio WHERE  RutRazonSocial = @RutRazonSocial ";
                result = db.Query<EdificioModel>(query, new { RutRazonSocial = razonSocial }).AsList();
            }
            return result;
        }

        /// <summary>
        /// Consulta un único elemento según clave especificada
        /// </summary>
        /// <param name="codigoEdificio"></param>
        /// <returns>Un objeto de persistencia para la clave especificada</returns>
        public EdificioModel ObtenerEdificio(string codigoEdificio)
        {
            EdificioModel result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"Select CodigoEdificio, CodigoArea, Nombre, CodigoPais, Pais, Direccion, Ciudad, Comuna, CentroCosto, RutRazonSocial,MaquinasInstaladas,NumeroCuenta,TipoCuenta,Banco,CorreoContacto,EmailNotificacion,
                                CodigoBanco,CodigoTipoCuenta as 'codigoTipoAbono',PorcentajeComision,MinimoGarantizadoComision,Giro   FROM Dbo.Edificio WHERE  CodigoEdificio = @CodigoEdificio ";
                result = db.QueryFirstOrDefault<EdificioModel>(query, new { CodigoEdificio = codigoEdificio });
            }
            return result;
        }

        public EdificioModel ObtenerEdificioComunidad(int rutComunidad)
        {
            EdificioModel result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"Select CodigoEdificio, CodigoArea, Nombre, CodigoPais, Pais, Direccion, Ciudad, Comuna, CentroCosto, RutRazonSocial,MaquinasInstaladas,NumeroCuenta,TipoCuenta,Banco,CorreoContacto,EmailNotificacion,
                                CodigoBanco,CodigoTipoCuenta as 'codigoTipoAbono',RutComunidad,PorcentajeComision,MinimoGarantizadoComision,Giro   FROM Dbo.Edificio WHERE  RutComunidad = @RutComunidad ";
                result = db.QueryFirstOrDefault<EdificioModel>(query, new { RutComunidad = rutComunidad });
            }
            return result;
        }


        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="edificioModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        public EdificioModel CrearEdificio(EdificioModel edificioModel)
        {
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"INSERT INTO Dbo.Edificio  (CodigoEdificio, CodigoArea, Nombre, CodigoPais, Pais, Direccion, Ciudad, Comuna, CentroCosto, RutRazonSocial,MaquinasInstaladas,NumeroCuenta,CodigoTipoCuenta,TipoCuenta,CodigoBanco,Banco,CorreoContacto,EmailNotificacion,PorcentajeComision,MinimoGarantizadoComision,Giro) 
                                VALUES (@CodigoEdificio, @CodigoArea, @Nombre, @CodigoPais, @Pais, @Direccion, @Ciudad, @Comuna, @CentroCosto, @RutRazonSocial,@MaquinasInstaladas,@NumeroCuenta,@CodigoTipoCuenta,@TipoCuenta,@CodigoBanco,@Banco,@CorreoContacto,@EmailNotificacion,@PorcentajeComision,@MinimoGarantizadoComision,@Giro)";
                db.Execute(query, edificioModel);
            }
            return edificioModel;
        }

        /// <summary>
        /// Actualiza un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="edificioModel"></param>
        /// <returns>booleano indicando si la operación fue exitosa o no</returns>
        public bool ActualizarEdificio(EdificioModel edificioModel)
        {
            bool result = false;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"UPDATE Dbo.Edificio SET CodigoArea=@CodigoArea, Nombre=@Nombre, CodigoPais=@CodigoPais, Pais=@Pais, Direccion=@Direccion, Ciudad=@Ciudad, 
                                Comuna=@Comuna, CentroCosto=@CentroCosto, RutRazonSocial=@RutRazonSocial,MaquinasInstaladas=@MaquinasInstaladas, NumeroCuenta=@NumeroCuenta,
                                CodigoTipoCuenta=@CodigoTipoCuenta,TipoCuenta=@TipoCuenta,CodigoBanco=@CodigoBanco,Banco=@Banco,CorreoContacto=@CorreoContacto,EmailNotificacion=@EmailNotificacion
                                ,PorcentajeComision=@PorcentajeComision,MinimoGarantizadoComision=@MinimoGarantizadoComision,Giro=@Giro
                                WHERE CodigoEdificio = @CodigoEdificio ";
                int i = db.Execute(query, edificioModel);
                result = i >= 0;
            }
            return result;
        }
        /// <summary>
        /// Elimina un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="codigoEdificio"></param>
        /// <returns>booleano indicando si la operación fue exitosa o no</returns>
        public bool EliminarEdificio(string codigoEdificio)
        {
            bool result = false;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"DELETE FROM Dbo.Edificio WHERE CodigoEdificio = @CodigoEdificio ";
                int i = db.Execute(query, new { CodigoEdificio = codigoEdificio });
                result = i >= 1;
            }
            return result;
        }

        public bool AsociarEdificio(EdificioModel edificioModel)
        {
            bool result = false;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"UPDATE Dbo.Edificio SET RutRazonSocial=@RutRazonSocial WHERE CodigoEdificio = @CodigoEdificio ";
                int i = db.Execute(query, edificioModel);
                result = i >= 0;
            }
            return result;
        }

        public bool AsociarEdificioComunidad(EdificioModel edificioModel)
        {
            bool result = false;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"UPDATE Dbo.Edificio SET RutComunidad=@RutComunidad WHERE CodigoEdificio = @CodigoEdificio ";
                int i = db.Execute(query, edificioModel);
                result = i >= 0;
            }
            return result;
        }

        public bool DesAsociarEdificio(EdificioModel edificioModel)
        {
            bool result = false;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"UPDATE Dbo.Edificio SET RutRazonSocial=null WHERE RutRazonSocial = @RutRazonSocial ";
                int i = db.Execute(query, edificioModel);
                result = i >= 0;
            }
            return result;
        }
    }
}

