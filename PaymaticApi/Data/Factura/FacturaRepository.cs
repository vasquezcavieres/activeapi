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
using Cl.Intertrade.ActivPay.Entities.Factura;
using System.Collections.Generic;
using System.Linq;
using DapperQueryBuilder;
using DTEBoxCliente;
using Cl.Intertrade.ActivPay.Controllers.Factura;
using Cl.Intertrade.ActivPay.Data.Factura;
using static Dapper.SqlMapper;
using Amazon.S3;
using Amazon.S3.Model;

namespace Cl.Intertrade.ActivPay.Repository.Factura
{
    /// <summary>
    /// Esta Clase Factura  permite gestionar la interacción con la base de datos para la tabla Factura
    /// </summary>
    public partial class FacturaRepository : DBBaseHelper, IFacturaRepository
    {
        private ILogger<FacturaRepository> logger;
        public FacturaRepository(ISettingsConfig settings,ILogger<FacturaRepository> logger) : base(settings)
        {
            this.logger = logger;
            this.settingsConfig = settings;
        }

        /// <summary>
        /// Consulta todos los elementos existentes
        /// </summary>
        /// <returns>Una lista de objetos</returns>
        public IList<FacturaModel> ObtenerFacturas()
        {
            IList<FacturaModel> result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"Select NumeroFactura, FechaCreacion, MontoNeto, Iva, MontoTotal, RutRazonSocial, Estado  FROM Dbo.Factura";
                result = db.Query<FacturaModel>(query).AsList();
            }
            return result;
        }
        /// <summary>
        /// Consulta una colección de elementos según parámetros de busqueda
        /// </summary>
        /// <param name="numeroFactura"></param>
        /// <returns>Una lista de objetos para la busqueda especificada</returns>
        public IList<FacturaModel> BuscarFacturas(int numeroFactura)
        {
            IList<FacturaModel> result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"Select NumeroFactura, FechaCreacion, MontoNeto, Iva, MontoTotal, RutRazonSocial, Estado  FROM Dbo.Factura WHERE  NumeroFactura = @NumeroFactura ";
                result = db.Query<FacturaModel>(query, new { NumeroFactura = numeroFactura }).AsList();
            }
            return result;
        }
        /// <summary>
        /// Consulta un único elemento según clave especificada
        /// </summary>
        /// <param name="numeroFactura"></param>
        /// <returns>Un objeto de persistencia para la clave especificada</returns>
        public FacturaModel ObtenerFactura(int numeroFactura)
        {
            FacturaModel result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"Select NumeroFactura, FechaCreacion, MontoNeto, Iva, MontoTotal, RutRazonSocial, Estado  FROM Dbo.Factura WHERE  NumeroFactura = @NumeroFactura ";
                result = db.QueryFirstOrDefault<FacturaModel>(query, new { NumeroFactura = numeroFactura });
            }
            return result;
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="facturaModel"></param>
        /// <returns>El mismo objeto de entrada, modifica si es necesario</returns>
        public FacturaModel CrearFactura(FacturaModel facturaModel)
        {
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"INSERT INTO Dbo.Factura  (NumeroFactura, FechaCreacion, MontoNeto, Iva, MontoTotal, RutRazonSocial, Estado) VALUES (@NumeroFactura, @FechaCreacion, @MontoNeto, @Iva, @MontoTotal, @RutRazonSocial, @Estado)";
                db.Execute(query, facturaModel);
            }
            return facturaModel;
        }

        /// <summary>
        /// Actualiza un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="facturaModel"></param>
        /// <returns>booleano indicando si la operación fue exitosa o no</returns>
        public bool ActualizarFactura(FacturaModel facturaModel)
        {
            bool result = false;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"UPDATE Dbo.Factura SET FechaCreacion=@FechaCreacion, MontoNeto=@MontoNeto, Iva=@Iva, MontoTotal=@MontoTotal, RutRazonSocial=@RutRazonSocial, Estado=@Estado WHERE NumeroFactura = @NumeroFactura ";
                int i = db.Execute(query, facturaModel);
                result = i >= 0;
            }
            return result;
        }
        /// <summary>
        /// Elimina un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="numeroFactura"></param>
        /// <returns>booleano indicando si la operación fue exitosa o no</returns>
        public bool EliminarFactura(int numeroFactura)
        {
            bool result = false;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                string query = @"DELETE FROM Dbo.Factura WHERE NumeroFactura = @NumeroFactura ";
                int i = db.Execute(query, new { NumeroFactura = numeroFactura });
                result = i >= 1;
            }
            return result;
        }

        public IList<FacturaModel> BuscarFacturas(FacturaModel facturaModel)
        {
            IList<FacturaModel> result;
            using (IDbConnection db = new SqlConnection(GetDatabase()))
            {
                var query = db.QueryBuilder($"Select NumeroFactura, FechaCreacion, MontoNeto, Iva, MontoTotal, RutRazonSocial, Estado,CodigoEdificio,NombreEdificio  FROM Dbo.Factura WHERE 1=1");
                if (facturaModel.NumeroFactura > 0)
                {
                    query.Append($" And NumeroFactura = {facturaModel.NumeroFactura} ");
                }
                if (facturaModel.RutRazonSocial > 0)
                {
                    query.Append($" And RutRazonSocial = {facturaModel.RutRazonSocial} ");
                }
                if (!string.IsNullOrEmpty(facturaModel.CodigoEdificio))
                {
                    query.Append($" And CodigoEdificio = {facturaModel.CodigoEdificio} ");
                }

                if (facturaModel.FechaDesde > DateTime.MinValue)
                {
                    query.Append($" And FechaCreacion >= {facturaModel.FechaDesde} ");
                }

                if (facturaModel.FechaHasta > DateTime.MinValue)
                {
                    query.Append($" And FechaCreacion <= {facturaModel.FechaHasta} ");
                }

               // string query = @"Select NumeroFactura, FechaCreacion, MontoNeto, Iva, MontoTotal, RutRazonSocial, Estado  FROM Dbo.Factura WHERE  NumeroFactura = @NumeroFactura ";
               // result = db.Query<FacturaModel>(query).AsList();
                result = query.Query<FacturaModel>().AsList();
            }
            return result;
        }



        //CAD: TODO
        //REMOVER ACCION DE WEB, PROCESO SE DEBE EJECUTAR DESL AMAQUINA QUE LLEGA AL SERVICIO DE GDE EXPRES

        public FacturaModel AnularFactura(FacturaModel facturaModel)
        {
           // Recuperar();

            try
            {
                // ﻿Emitir Nota de Crédito que anula Factura

                var factura = ObtenerFactura(facturaModel.NumeroFactura);
                if (factura != null)
                {
                    #region DTE

                    #region Dependencias
                    // - DTEBOXClienteNET20.dll
                    // - LiquidTechnologies.Runtime.Net20.dll
                    // - DTEDocumentoNET20.dll
                    #endregion

                    //Codigo para Api de Integracion version 2
                    #region DTE

                    DocumentoDTE.SiiDte.DTEDefType dte = new DocumentoDTE.SiiDte.DTEDefType();
                    dte.DTE_Choice = new DocumentoDTE.SiiDte.DTE_Choice();

                    //Documento
                    dte.DTE_Choice.Documento = new DocumentoDTE.SiiDte.Documento();
                    DocumentoDTE.SiiDte.Documento doc = dte.DTE_Choice.Documento;

                    //Documento/Encabezado
                    doc.Encabezado = new DocumentoDTE.SiiDte.Encabezado();
                    doc.Encabezado.IdDoc = new DocumentoDTE.SiiDte.IdDoc();

                    //Documento/Encabezado/IdDoc
                    doc.Encabezado.IdDoc.TipoDTE = DocumentoDTE.SiiDte.Enumerations.DTEType.n61;
                    doc.Encabezado.IdDoc.Folio = 3;// numero de NOTA DE CREDITO
                    doc.Encabezado.IdDoc.FchEmis = new LiquidTechnologies.Runtime.Net20.XmlDateTime(DateTime.Now); // input en front

                    //Documento/Encabezado/Emisor
                    doc.Encabezado.Emisor = new DocumentoDTE.SiiDte.Emisor();
                    doc.Encabezado.Emisor.RUTEmisor = settingsConfig.RutEmisorFactura;// "77815152-9";
                    doc.Encabezado.Emisor.RznSoc = settingsConfig.RazonSocialFactura;// "Pago Activo servicios Financieros Spa.";
                    doc.Encabezado.Emisor.GiroEmis = settingsConfig.GiroEmisorFactura;// "Otras actividades de servicios financieros";//web  especificaciones
                    doc.Encabezado.Emisor.CmnaOrigen = settingsConfig.ComunaOrigenFactura;// "Huechuraba";
                    doc.Encabezado.Emisor.CiudadOrigen = settingsConfig.CiudadOrigenFactura;// "SANTIAGO";
                    doc.Encabezado.Emisor.DirOrigen = settingsConfig.DireccionOrigenFactura;// "Palacio Riesco 4441, Huechuraba, Santiago";
                    doc.Encabezado.Emisor.Acteco.Add(649900);

                    //Documento/Encabezado/Receptor
                    doc.Encabezado.Receptor = new DocumentoDTE.SiiDte.Receptor();
                    doc.Encabezado.Receptor.RUTRecep = "53326105-1";
                    doc.Encabezado.Receptor.RznSocRecep = "Condominio Viñedos de Rancagua";
                    doc.Encabezado.Receptor.GiroRecep = "Condominio";  // TODO : COLOCAR GIRO EN LA WEB 
                    doc.Encabezado.Receptor.CmnaRecep = "Rancagua";
                    doc.Encabezado.Receptor.CiudadRecep = "Rancagua";
                    doc.Encabezado.Receptor.DirRecep = "Avda. Bombero Villalobos 01231, Rancagua";

                    doc.Encabezado.Totales = new DocumentoDTE.SiiDte.Totales();
                    doc.Encabezado.Totales.MntTotal = 1163406;
                    doc.Encabezado.Totales.MntNeto = 977652;
                    doc.Encabezado.Totales.MntExe = 0;
                    doc.Encabezado.Totales.IVA = 185754;

                    //Documento/Detalle
                    DocumentoDTE.SiiDte.Detalle det = new DocumentoDTE.SiiDte.Detalle();
                    det.NroLinDet = 1;
                    det.NmbItem = "Comisión servicio Activpay";
                    det.MontoItem = 977652;
                    det.DscItem = "Comisión servicio Activpay";
                    det.QtyItem = 1;
                    det.PrcItem = 977652;

                    //Documento/Detalle/CdgItem
                    DocumentoDTE.SiiDte.CdgItem cdgItem = new DocumentoDTE.SiiDte.CdgItem();
                    cdgItem.TpoCodigo = "INT";
                    cdgItem.VlrCodigo = "BUR-BURSTA";
                    det.CdgItem.Add(cdgItem);

                    doc.Detalle.Add(det);

                    //Documento/Referencia
                    DocumentoDTE.SiiDte.Referencia reference = new DocumentoDTE.SiiDte.Referencia();
                    reference.NroLinRef = 1;
                    reference.TpoDocRef = "33"; //1-3 char  (33)FACTURA ELECTRONICA
                    reference.FolioRef = "3"; //FOLIO FACTURA
                    reference.FchRef = new LiquidTechnologies.Runtime.Net20.XmlDateTime(new DateTime(2024,7, 23));//FECHA DE FACTURA
                    reference.CodRef = DocumentoDTE.SiiDte.Enumerations.Referencia_CodRef.n1;//1 => ANULACION
                    doc.Referencia.Add(reference);

                    #endregion

                    #region Llamada al servicio

                    DTEBoxCliente.Ambiente ambiente = DTEBoxCliente.Ambiente.Produccion;
                    DateTime fechaResolucion = new DateTime(2014, 8, 22); //ESTA ES FIJA
                    int numeroResolucion = 80;//FIJO
                    DTEBoxCliente.TipoPdf417 tipoPdf417 = DTEBoxCliente.TipoPdf417.Fuente;
                    bool generarFolio = false;


                    string apiURL = "http://192.168.0.64/api/Core.svc/Core";
                    string apiAuth = "2ec64694-829f-4a6e-b369-dc8936320e09";

                    DTEBoxCliente.Servicio servicio = new DTEBoxCliente.Servicio(apiURL, apiAuth);

                    //Si desea generar previamente el xml use esta línea
                    //string xml = servicio.ToXML(dte);

                    DTEBoxCliente.ResultadoEnvioDte resultado = servicio.EnviarDocumento(
                        dte,
                        ambiente,
                        fechaResolucion,
                        numeroResolucion,
                        tipoPdf417,
                        generarFolio);

                    #endregion

                    #region Procesar resultado

                    //Si la respuesta es correcta
                    if (resultado.ResultadoServicio.Estado == DTEBoxCliente.EstadoResultado.Ok)
                    {
                        //Usar el data que viene en el resultado de la llamada
                        string ted = resultado.TED; //Xml que representa el elemento TED generado
                                                    //Si tipoPdf417 = DTEBoxCliente.TipoPdf417.Fuente viene el código, 
                                                    // si es DTEBoxCliente.TipoPdf417.Grafico, Entonces arreglo de bytes codigificado en base64, 
                                                    // usar método result.Pdf417ComoArregloBytes();
                        string pdf417 = resultado.Pdf417;

                        //Código de usuario a partir de aquí
                    }
                    else //Si la llamada no fue satisfactoria
                    {
                        //Descripción del error, actuar acorde
                        string description = resultado.ResultadoServicio.Descripcion;
                    }

                    #endregion

                    #endregion
                }
                else
                {
                    facturaModel.Errores = new List<string>();
                    facturaModel.Errores.Add($"Factura N° {facturaModel.NumeroFactura} no Existe.");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return facturaModel;
        }

        public async Task<FacturaModel> ObtenerNotaCredito(FacturaModel facturaModel)
        {
            try
            {
                facturaModel.PdfNotaCredito = await Recuperar(facturaModel);

                if (facturaModel.PdfNotaCredito != null)
                { 
                    facturaModel.Base64NotaCredito = Convert.ToBase64String(facturaModel.PdfNotaCredito); 
                }
                else
                {
                    facturaModel.Errores = new List<string>();
                    facturaModel.Errores.Add($"Nota De Cédito N° {facturaModel.NumeroFactura} no Existe.");
                }    
            }
            catch (Exception ex)
            {
                throw ex;              
            }
          
            return facturaModel;           
        }


        public async Task<byte[]> Recuperar(FacturaModel facturaModel)
        {
            byte[] pdf = null;
            try
            {
                // Create a GetObject request
                var request = new GetObjectRequest
                {
                    BucketName = settingsConfig.AWSProfile.BucketName,
                    Key = $"Nota_Credito_{facturaModel.NumeroNotaCredito}.pdf",
                };

                //var s3Client = new AmazonS3Client(settingsConfig.AWSProfile.AccessKey, settingsConfig.AWSProfile.SecretKey, Amazon.RegionEndpoint.USEast1);
                //// Issue request and remember to dispose of the response
                //var response = await s3Client.GetObjectAsync(request);
                //using (MemoryStream ms = new MemoryStream())
                //{
                //    response.ResponseStream.CopyTo(ms);
                //    pdf = ms.ToArray();
                //}

                DTEBoxCliente.Ambiente ambiente = DTEBoxCliente.Ambiente.Produccion;
                string rut = settingsConfig.RutEmisorFactura;
                DTEBoxCliente.TipoDocumento tipoDocumento = DTEBoxCliente.TipoDocumento.TIPO_61;
                GrupoBusqueda grupo = GrupoBusqueda.Emitidos;
                long folio = facturaModel.NumeroNotaCredito;

                string apiURL = settingsConfig.UrlApi;
                string apiAuth = settingsConfig.TokenProduccion;

                DTEBoxCliente.Servicio service = new DTEBoxCliente.Servicio(apiURL, apiAuth);
                DTEBoxCliente.ResultadoRecuperarPdf resultado = service.RecuperarPdf(ambiente, grupo, rut, (int)tipoDocumento, folio);


                //Si la respuesta es correcta
                if (resultado.ResultadoServicio.Estado == DTEBoxCliente.EstadoResultado.Ok)
                {
                    //Usar los datos que viene en el resultado de la llamada
                    pdf = resultado.Datos;

                     File.WriteAllBytes($"C:\\NOTA_CREDITO_FOLIO_{folio}.pdf", pdf);

                    //Código de usuario a partir de aquí
                }
                else //Si la llamada no fue satisfactoria
                {
                    //Descripción del error, actuar acorde
                    string description = resultado.ResultadoServicio.Descripcion;
                    logger.LogError($"ERROR RECUPERA NOTA DE CREDITO => {description}");
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"ERROR RECUPERA NOTA DE CREDITO => { ex.Message}");
                throw ex;
            }

            return pdf;
        }

    }
}

