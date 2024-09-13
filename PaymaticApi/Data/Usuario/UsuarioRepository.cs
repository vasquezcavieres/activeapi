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
using Cl.Intertrade.ActivPay.Entities.Usuario;
using System.Collections.Generic;
using System.Linq;
using Cl.Intertrade.ActivPay.Entities.Acceso;

namespace Cl.Intertrade.ActivPay.Repository.Usuario
{ 
	/// <summary>
	/// Esta Clase Usuario  permite gestionar la interacción con la base de datos para la tabla Usuario
	/// </summary>
	public partial class UsuarioRepository : DBBaseHelper, IUsuarioRepository
	{	

			public UsuarioRepository(ISettingsConfig settings) : base(settings)
			{
				this.settingsConfig = settings;
			}

		/// <summary>
		/// Consulta todos los elementos existentes
		/// </summary>
		/// <returns>Una lista de objetos</returns>
		public IList<UsuarioModel> ObtenerUsuarios( )
		{
			IList<UsuarioModel> result;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"Select TokenUsuario, RutUsuario, RutUsuarioDv, CodigoPais, Pais, CodigoRol, Nombres, Apellidos, Email, Telefono, Clave, UltimaClave, DebeCambiarClave, FechaCreacion, FechaActualizacion, Activo  FROM Dbo.Usuario where CodigoPais = 'CL' AND CodigoRol IN('ADMINISTRADOR_CONVENIO','COMUNIDAD')";
				result = db.Query<UsuarioModel>(query).AsList();
			}
			return result;       
		}

        public IList<UsuarioModel> ObtenerUsuariosComunidad()
        {
            IList<UsuarioModel> result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"Select TokenUsuario, RutUsuario, RutUsuarioDv, CodigoPais, Pais, CodigoRol, Nombres, Apellidos, Email, Telefono, Clave, UltimaClave, DebeCambiarClave, FechaCreacion, FechaActualizacion, Activo  FROM Dbo.Usuario where CodigoPais = 'CL' AND CodigoRol = 'COMUNIDAD'";
                result = db.Query<UsuarioModel>(query).AsList();
            }
            return result;
        }

        public IList<UsuarioModel> ObtenerUsuariosAdministradorConvenio()
        {
            IList<UsuarioModel> result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"Select TokenUsuario, RutUsuario, RutUsuarioDv, CodigoPais, Pais, CodigoRol, Nombres, Apellidos, Email, Telefono, Clave, UltimaClave, DebeCambiarClave, FechaCreacion, FechaActualizacion, Activo  FROM Dbo.Usuario where CodigoPais = 'CL' AND CodigoRol = 'ADMINISTRADOR_CONVENIO'";
                result = db.Query<UsuarioModel>(query).AsList();
            }
            return result;
        }
        

        /// <summary>
        /// Consulta una colección de elementos según parámetros de busqueda
        /// </summary>
        /// <param name="tokenUsuario"></param>
        /// <returns>Una lista de objetos para la busqueda especificada</returns>
        public IList<UsuarioModel> BuscarUsuarios( string tokenUsuario)
		{
			IList<UsuarioModel> result;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"Select TokenUsuario, RutUsuario, RutUsuarioDv, CodigoPais, Pais, CodigoRol, Nombres, Apellidos, Email, Telefono, Clave, UltimaClave, DebeCambiarClave, FechaCreacion, FechaActualizacion, Activo  FROM Dbo.Usuario WHERE  TokenUsuario = @TokenUsuario ";
				result = db.Query<UsuarioModel>(query, new { TokenUsuario=tokenUsuario }).AsList();
			}
			return result;       
		}
		/// <summary>
        /// Consulta un único elemento según clave especificada
        /// </summary>
        /// <param name="tokenUsuario"></param>
/// <returns>Un objeto de persistencia para la clave especificada</returns>
		public UsuarioModel ObtenerUsuario(string tokenUsuario)
		{
			UsuarioModel result;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"Select TokenUsuario, RutUsuario, RutUsuarioDv, u.CodigoPais, u.Pais, CodigoRol, Nombres, Apellidos, Email, Telefono, Clave, UltimaClave,
                                 DebeCambiarClave, FechaCreacion, FechaActualizacion, Activo, e.CodigoEdificio
                                 FROM Dbo.Usuario u
                                 left join Edificio e on u.RutUsuario = e.rutComunidad
                                 WHERE  TokenUsuario = @TokenUsuario ";
				result = db.QueryFirstOrDefault<UsuarioModel>(query, new { TokenUsuario=tokenUsuario });
			}
			return result;                        
		}

        public UsuarioModel ObtenerUsuarioEmail(string email)
        {
            UsuarioModel result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"Select TokenUsuario, RutUsuario, RutUsuarioDv, CodigoPais, Pais, CodigoRol, Nombres, Apellidos, Email, Telefono, Clave, UltimaClave, DebeCambiarClave, FechaCreacion, FechaActualizacion, Activo  FROM Dbo.Usuario WHERE  email = @email  and codigoPais = 'CL'";
                result = db.QueryFirstOrDefault<UsuarioModel>(query, new { Email = email });
            }
            return result;
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="usuarioModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        public UsuarioModel CrearUsuario(UsuarioModel usuarioModel)
		{
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
		string query = @"INSERT INTO Dbo.Usuario  (TokenUsuario, RutUsuario, RutUsuarioDv, CodigoPais, Pais, CodigoRol, Nombres, Apellidos, Email, Telefono, Clave, UltimaClave, DebeCambiarClave, FechaCreacion, FechaActualizacion, Activo) VALUES (@TokenUsuario, @RutUsuario, @RutUsuarioDv, @CodigoPais, @Pais, @CodigoRol, @Nombres, @Apellidos, @Email, @Telefono, @Clave, @UltimaClave, @DebeCambiarClave, @FechaCreacion, @FechaActualizacion, @Activo)";
		db.Execute(query, usuarioModel);
						}
			return usuarioModel;
		}

		/// <summary>
		/// Actualiza un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="usuarioModel"></param>
		/// <returns>booleano indicando si la operación fue exitosa o no</returns>
		public bool ActualizarUsuario(UsuarioModel usuarioModel)
		{
			bool result = false;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"UPDATE Dbo.Usuario SET TokenRecuperacion = @TokenRecuperacion, RutUsuario=@RutUsuario, RutUsuarioDv=@RutUsuarioDv, CodigoPais=@CodigoPais, Pais=@Pais, CodigoRol=@CodigoRol, Nombres=@Nombres, Apellidos=@Apellidos, Email=@Email, Telefono=@Telefono, Clave=@Clave, UltimaClave=@UltimaClave, DebeCambiarClave=@DebeCambiarClave, FechaCreacion=@FechaCreacion, FechaActualizacion=@FechaActualizacion, Activo=@Activo WHERE TokenUsuario = @TokenUsuario ";
				int i = db.Execute(query, usuarioModel);
                result = i >= 0;
			}
			return result;
		}
		/// <summary>
		/// Elimina un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="tokenUsuario"></param>
/// <returns>booleano indicando si la operación fue exitosa o no</returns>
		public bool EliminarUsuario(string tokenUsuario)
		{
			bool result = false;
			using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
				string query = @"DELETE FROM Dbo.Usuario WHERE TokenUsuario = @TokenUsuario ";
                int i = db.Execute(query, new { TokenUsuario=tokenUsuario });
				result = i >= 1;
			}
			return result;
		}

        public UsuarioModel Login(UsuarioModel usuarioModel)
        {
            UsuarioModel result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"Select TokenUsuario, RutUsuario, RutUsuarioDv, CodigoPais, Pais, CodigoRol, Nombres, Apellidos, Email, Telefono, Clave, UltimaClave, DebeCambiarClave, FechaCreacion, FechaActualizacion, Activo,TokenRecuperacion  FROM Dbo.Usuario WHERE  Email = @Email and  Clave = @Clave ";
                result = db.QueryFirstOrDefault<UsuarioModel>(query, new { Email = usuarioModel.Email , Clave = usuarioModel.Clave });
            }
            return result;
        }


        public bool EliminarAccesoTokenUsuario(string token)
        {
            bool result = false;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"DELETE Acceso WHERE TokenUsuario=@TokenUsuario";
                int i = db.Execute(query, new { TokenUsuario = token });
                result = i >= 0;
            }
            return result;
        }

        public AccesoModel CrearAcceso(AccesoModel accesoModel)
        {
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"INSERT INTO Dbo.Acceso  (Id, RutUsuario, DvUsuario, Nombres, Apellidos, Email, Telefono, TokenAcceso, TokenUsuario, TokenRefresco, CodigoPais, Pais,FechaCreacion,CodigoRol) VALUES (@Id, @RutUsuario, @DvUsuario, @Nombres, @Apellidos, @Email, @Telefono, @TokenAcceso, @TokenUsuario, @TokenRefresco, @CodigoPais,@Pais, @FechaCreacion,@CodigoRol)";
                db.Execute(query, accesoModel);
            }
            return accesoModel;
        }

        public AccesoModel ObtenerAcceso(string token)
        {
            AccesoModel result = null;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"Select Id, RutUsuario, DvUsuario, Nombres, Apellidos, Email, Telefono, TokenAcceso, TokenUsuario, TokenRefresco, CodigoPais,Pais, FechaCreacion ,CodigoRol from acceso Where TokenAcceso=@TokenAcceso";
                result = db.QueryFirstOrDefault<AccesoModel>(query, new { TokenAcceso = token });
            }
            return result;
        }
        public AccesoModel ObtenerAccesoTokenUsuario(string token)
        {
            AccesoModel result = null;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"Select TokenAcceso, TokenUsuario, CodigoRol, RutUsuario,RutUsuarioDv,Nombres,Apellidos, Email,Telefono,DebeCambiarClave, FechaCreacion FROM Acceso Where TokenUsuario=@TokenUsuario";
                result = db.QueryFirstOrDefault<AccesoModel>(query, new { TokenUsuario = token });
            }
            return result;
        }


        public UsuarioModel ObtenerUsuarioRecuperado(string token)
        {
            UsuarioModel result = null;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"Select TokenUsuario, RutUsuario, RutUsuarioDv, CodigoPais, Pais, CodigoRol, Nombres, Apellidos, Email, Telefono, Clave, UltimaClave, DebeCambiarClave, FechaCreacion, FechaActualizacion, Activo,TokenRecuperacion  FROM Usuario Where TokenRecuperacion=@TokenRecuperacion";
                result = db.QueryFirstOrDefault<UsuarioModel>(query, new { TokenRecuperacion = token });
            }
            return result;
        }

        public bool ActualizarClave(UsuarioModel usuarioModel)
        {
            bool result = false;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"UPDATE Usuario SET TokenRecuperacion = @TokenRecuperacion, Clave = @Clave, UltimaClave=@UltimaClave,DebeCambiarClave=@DebeCambiarClave,FechaActualizacion=@FechaActualizacion WHERE TokenUsuario=@TokenUsuario";
                int i = db.Execute(query, usuarioModel);
                result = i >= 0;
            }
            return result;
        }


    }
}

