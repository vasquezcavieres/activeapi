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


using AutoMapper;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Http;
using Cl.Intertrade.ActivPay.Helpers.Base;
using Cl.Intertrade.ActivPay.Entities.Transferencia;
using Cl.Intertrade.ActivPay.Request.Transferencia;
using Cl.Intertrade.ActivPay.Result.Transferencia;
using Cl.Intertrade.ActivPay.Repository.Transferencia;
using Cl.Intertrade.ActivPay.Repository.Pago;
using Cl.Intertrade.ActivPay.Entities.DetalleTransferencia;
using Cl.Intertrade.ActivPay.Repository.Banco;
using Cl.Intertrade.ActivPay.Repository.DetalleTransferencia;
using Cl.Intertrade.ActivPay.Repository.Edificio;
using Cl.Intertrade.ActivPay.Repository.TipoAbono;
using Cl.Intertrade.ActivPay.Repository.Uf;
using Cl.Intertrade.ActivPayApi.Entities.ArchivoPagoProveedores;
using Cl.Intertrade.ActivPayApi.Repository.ArchivoPagoProveedores;
using Newtonsoft.Json;
using System.Data;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon.S3.Model;
using Cl.Intertrade.ActivPay.Entities.Factura;

namespace Cl.Intertrade.ActivPay.Data.Transferencia
{
	/// <summary>
	/// Esta Clase Transferencia  permite gestionar reglas de negocio asociados a la entidad Transferencia
	/// </summary>
	public partial class TransferenciaService : ITransferenciaService
	{	
        private ISettingsConfig settings;
        private ITransferenciaRepository transferenciaRepository;
        private IPagoRepository pagoRepository;
        private IEdificioRepository edificioRepository;
        private IUfRepository ufRepository;
        private IBancoRepository bancoRepository;
        private ITipoAbonoRepository tipoAbonoRepository;
        private IDetalleTransferenciaRepository detalleTransferenciaRepository;
        private IArchivoPagoProveedoresRepository archivoPagoProveedoresRepository;
        private ILogger<TransferenciaService> logger;
        private IMapper mapper;
        private decimal IVA = 0.19m;
        private decimal PORCENTAJE_COMISION = 0.07M;
        public TransferenciaService(ITransferenciaRepository transferenciaRepository, ISettingsConfig settings, ILogger<TransferenciaService> logger, IMapper mapper,
            IPagoRepository pagoRepository, IEdificioRepository edificioRepository, IBancoRepository bancoRepository, ITipoAbonoRepository tipoAbonoRepository, IUfRepository ufRepository,
            IDetalleTransferenciaRepository detalleTransferenciaRepository, IArchivoPagoProveedoresRepository archivoPagoProveedoresRepository)
        {
            this.transferenciaRepository = transferenciaRepository;
            this.mapper = mapper;
            this.settings = settings;
            this.logger = logger;
            this.pagoRepository = pagoRepository;
            this.edificioRepository = edificioRepository;
            this.bancoRepository = bancoRepository;
            this.tipoAbonoRepository = tipoAbonoRepository;
            this.ufRepository = ufRepository;
            this.detalleTransferenciaRepository = detalleTransferenciaRepository;
            this.archivoPagoProveedoresRepository = archivoPagoProveedoresRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public ListadoTransferenciaResult ObtenerTransferencias(TransferenciaRequest transferenciaRequest)
        {
            ListadoTransferenciaResult listadoTransferenciaResult = new ListadoTransferenciaResult();
            listadoTransferenciaResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
                var transferenciaModel = mapper.Map<TransferenciaModel>(transferenciaRequest);
                var transferencias = transferenciaRepository.ObtenerTransferencias(transferenciaModel);
                listadoTransferenciaResult.Transferencias = new List<TransferenciaResult>();

                if (transferencias != null)
                {
                    listadoTransferenciaResult.Transferencias = mapper.Map<IList<TransferenciaResult>>(transferencias);
                    listadoTransferenciaResult.StatusCode = StatusCodes.Status200OK;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"TransferenciaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoTransferenciaResult;
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <returns>Objeto TransferenciaResult con información del resultado de la operación</returns>
        public ListadoTransferenciaResult ObtenerTransferencias()
		{
			ListadoTransferenciaResult listadoTransferenciaResult = new ListadoTransferenciaResult();
            listadoTransferenciaResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
				var transferencias = transferenciaRepository.ObtenerTransferencias();
                listadoTransferenciaResult.Transferencias = new List<TransferenciaResult>();

                if (transferencias != null)
                {
                    listadoTransferenciaResult.Transferencias = mapper.Map<IList<TransferenciaResult>>(transferencias);
                    listadoTransferenciaResult.StatusCode = StatusCodes.Status200OK;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"TransferenciaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoTransferenciaResult;
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="transferenciaId"></param>
/// <returns>Objeto TransferenciaResult con información del resultado de la operación</returns>
		public ListadoTransferenciaResult BuscarTransferencias(int transferenciaId )
		{
			ListadoTransferenciaResult listadoTransferenciaResult = new ListadoTransferenciaResult();
            listadoTransferenciaResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
				var transferencias = transferenciaRepository.BuscarTransferencias(transferenciaId);
                listadoTransferenciaResult.Transferencias = new List<TransferenciaResult>();

                if (transferencias != null)
                {
                    listadoTransferenciaResult.Transferencias = mapper.Map<IList<TransferenciaResult>>(transferencias);
                    listadoTransferenciaResult.StatusCode = StatusCodes.Status200OK;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"TransferenciaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoTransferenciaResult;
		}

        public ListadoTransferenciaResult BuscarTransferenciasPorConvenio(int codigoConvenio)
        {
            ListadoTransferenciaResult listadoTransferenciaResult = new ListadoTransferenciaResult();
            listadoTransferenciaResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
                IList<TransferenciaModel> transferencias = new List<TransferenciaModel>();

                if (codigoConvenio == 0)
                {
                    transferencias = transferenciaRepository.ObtenerTransferencias();
                }
                else
                {
                    transferencias = transferenciaRepository.BuscarTransferenciasPorConvenio(codigoConvenio);
                }
                
                listadoTransferenciaResult.Transferencias = new List<TransferenciaResult>();

                if (transferencias != null)
                {
                    listadoTransferenciaResult.Transferencias = mapper.Map<IList<TransferenciaResult>>(transferencias);
                    listadoTransferenciaResult.StatusCode = StatusCodes.Status200OK;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"TransferenciaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoTransferenciaResult;
        }

        public ListadoTransferenciaResult BuscarTransferenciasPorEdificio(string codigoEdificio)
        {
            ListadoTransferenciaResult listadoTransferenciaResult = new ListadoTransferenciaResult();
            listadoTransferenciaResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
                IList<TransferenciaModel> transferencias = new List<TransferenciaModel>(); 
                transferencias = transferenciaRepository.BuscarTransferenciasPorEdificio(codigoEdificio);
                
                if (transferencias != null)
                {
                    listadoTransferenciaResult.Transferencias = mapper.Map<IList<TransferenciaResult>>(transferencias);
                    listadoTransferenciaResult.StatusCode = StatusCodes.Status200OK;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"TransferenciaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoTransferenciaResult;
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="transferenciaId"></param>
        /// <returns>Objeto TransferenciaResult con información del resultado de la operación</returns>
        public TransferenciaResult ObtenerTransferencia(int transferenciaId )
        {
			TransferenciaResult transferenciaResult = new TransferenciaResult();
            transferenciaResult.StatusCode = StatusCodes.Status202Accepted;
			try
			{
				var transferencia = transferenciaRepository.ObtenerTransferencia(transferenciaId);
                if (transferencia!=null)
                {
                    transferenciaResult = mapper.Map<TransferenciaResult>(transferencia);
                    transferenciaResult.StatusCode = StatusCodes.Status200OK;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"TransferenciaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return transferenciaResult;
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="transferenciaModel"></param>
		/// <returns>Objeto TransferenciaResult con información del resultado de la operación</returns>
		public TransferenciaResult CrearTransferencia(TransferenciaRequest transferenciaRequest)
		{
			TransferenciaResult transferenciaResult = new TransferenciaResult();
            transferenciaResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {
				var transferencia = mapper.Map<TransferenciaModel>(transferenciaRequest);
                transferencia = transferenciaRepository.CrearTransferencia(transferencia);
                if (transferencia != null)
                {
                    transferenciaResult = mapper.Map<TransferenciaResult>(transferencia);
                    transferenciaResult.StatusCode = StatusCodes.Status201Created;
                }
			}
			catch (Exception e)
            {
                logger.LogError($"TransferenciaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return transferenciaResult;
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="transferenciaModel"></param>
		/// <returns>Objeto TransferenciaResult con información del resultado de la operación</returns>
		public TransferenciaResult ActualizarTransferencia(TransferenciaRequest transferenciaRequest)
		{
			TransferenciaResult transferenciaResult = new TransferenciaResult();
            transferenciaResult.StatusCode = StatusCodes.Status202Accepted;
			try
			{
				var transferencia = mapper.Map<TransferenciaModel>(transferenciaRequest);
                var result = transferenciaRepository.ActualizarTransferencia(transferencia);
                if (result)
                {
                    transferenciaResult.StatusCode = StatusCodes.Status204NoContent;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"TransferenciaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return transferenciaResult;
		}
		
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="transferenciaModel"></param>
		/// <returns>Objeto TransferenciaResult con información del resultado de la operación</returns>
		public TransferenciaResult EliminarTransferencia(int transferenciaId )
        {
			TransferenciaResult transferenciaResult = new TransferenciaResult();
            transferenciaResult.StatusCode = StatusCodes.Status202Accepted;
			try
			{
				var result = transferenciaRepository.EliminarTransferencia(transferenciaId);
                if (result)
                {
                    transferenciaResult.StatusCode = StatusCodes.Status204NoContent;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"TransferenciaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return transferenciaResult;
        }

        public TransferenciaResult AprobarTransferencia(int transferenciaId)
        {
            TransferenciaResult transferenciaResult = new TransferenciaResult();
            transferenciaResult.StatusCode = StatusCodes.Status400BadRequest;
            try
            {
                var result = transferenciaRepository.AprobarTransferencia(transferenciaId);
                if (result)
                {
                    transferenciaResult.StatusCode = StatusCodes.Status202Accepted;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"TransferenciaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return transferenciaResult;
        }

        public async Task<TransferenciaResult> ProcesoTransferencia()
        {
            List<TransferenciaModel> listadoTransferecnias = new List<TransferenciaModel>();
            TransferenciaResult transferenciaResult = new TransferenciaResult();
            transferenciaResult.StatusCode = StatusCodes.Status400BadRequest;
            try
            {
                var pagos = pagoRepository.BuscarPagosProcesoTrasnferencia();
                if (pagos != null && pagos.Count > 0)
                {
                    var UF_AL_DIA = ufRepository.ObtenerUf();
                    var pagosByEdificio = pagos.GroupBy(c => c.CodigoEdificio);

                    foreach (var unEdificio in pagosByEdificio)
                    {
                        var edificio = edificioRepository.ObtenerEdificio(unEdificio.First().CodigoEdificio);
                        var banco = bancoRepository.ObtenerBanco(edificio.CodigoBanco);
                        var tipoCuenta = tipoAbonoRepository.ObtenerTipoAbono(edificio.CodigoTipoAbono);

                        TransferenciaModel transferenciaModel = new TransferenciaModel();
                        transferenciaModel.CodigoConvenio = edificio.RutRazonSocial;
                        transferenciaModel.RutRazonSocial = edificio.RutRazonSocial;
                        transferenciaModel.RutRazonSocialDv = ""; // unEdificio.RutRazonSocialDv;
                        transferenciaModel.FechaTransferencia = DateTime.Now;

                        var minimoGarantizado = edificio.MaquinasInstaladas * (0.5m * UF_AL_DIA.Valor);
                        var montoPorcentajeVentas = unEdificio.ToList().Sum(c => c.MontoPago) * PORCENTAJE_COMISION;//SIEMPRE ES 7%

                        transferenciaModel.CostoComision = minimoGarantizado > montoPorcentajeVentas ? minimoGarantizado : montoPorcentajeVentas;
                        transferenciaModel.IvaCostoComision = transferenciaModel.CostoComision * IVA;
                        transferenciaModel.TotalTransferencia = unEdificio.ToList().Sum(c => c.MontoPago) - transferenciaModel.CostoComision - transferenciaModel.IvaCostoComision;
                        transferenciaModel.MontoTransferencia = transferenciaModel.TotalTransferencia;

                        //si la transferencia es menos a cero, no se realiza la transferencia
                        //La Comision es con IVA

                        transferenciaModel.NumeroPagos = unEdificio.ToList().Count;
                        transferenciaModel.CodigoConvenio = edificio.RutRazonSocial;
                        transferenciaModel.NumeroCuenta = edificio.NumeroCuenta;
                        transferenciaModel.TipoCuenta = tipoCuenta.Nombre;
                        transferenciaModel.CodigoTipoCuenta = tipoCuenta.CodigoTipoAbono;
                        transferenciaModel.Banco = banco.Nombre;
                        transferenciaModel.CodigoBanco = banco.CodigoBanco;
                        transferenciaModel.EmailNotificacion = edificio.EmailNotificacion;
                        transferenciaModel.Estado = "EN PROCESO";
                        transferenciaModel.Facturada = false;
                        transferenciaModel.CodigoEdificio = edificio.CodigoEdificio;
                        transferenciaModel.NombreEdificio = edificio.Nombre;
                        transferenciaModel = transferenciaRepository.CrearTransferencia(transferenciaModel);

                        if (transferenciaModel != null)
                        {
                            foreach (var unPago in unEdificio.ToList())
                            {
                                DetalleTransferenciaModel detalleTransferenciaModel = new DetalleTransferenciaModel();
                                detalleTransferenciaModel.TransferenciaId = transferenciaModel.TransferenciaId;
                                detalleTransferenciaModel.RutRazonSocial = edificio.RutRazonSocial;
                                detalleTransferenciaModel.PagoId = unPago.PagoId;
                                detalleTransferenciaModel.FechaTransferencia = DateTime.Now;
                                detalleTransferenciaModel.MontoPago = unPago.MontoPago;
                                detalleTransferenciaModel.CostoComision = unPago.MontoPago * PORCENTAJE_COMISION;
                                detalleTransferenciaModel.MontoTransferencia = unPago.MontoPago - detalleTransferenciaModel.CostoComision;
                                detalleTransferenciaModel = detalleTransferenciaRepository.CrearDetalleTransferencia(detalleTransferenciaModel);
                            }

                            listadoTransferecnias.Add(transferenciaModel);
                        }
                    }

                    var resultadoCreaArchivo = await CrearArchivoPagoProveedor(listadoTransferecnias);
                    if (resultadoCreaArchivo)
                    { 
                        transferenciaResult.StatusCode = StatusCodes.Status200OK;
                    }
                    else {
                        transferenciaResult.Errores = new List<string>();
                        transferenciaResult.Errores.Add("Problemas al crear Archvio transferencias");
                    }
                }
                else
                {
                    transferenciaResult.Errores = new List<string>();
                    transferenciaResult.Errores.Add("Problemas al crear Archvio transferencias, No se encontraron Pagos");

                }
            }
            catch (Exception e)
            {
                logger.LogError($"TransferenciaService: {e.Message}, {e.StackTrace}");
                transferenciaResult.Errores = new List<string>();
                transferenciaResult.Errores.Add($"Problemas al crear Archvio transferencias, ERROR : {e.Message}");
            }
            return transferenciaResult;
        }

        public async Task<bool> CrearArchivoPagoProveedor(List<TransferenciaModel> listadoTransferecnias)
        {
            bool respuesta = false;
            try
            {
                var persons = listadoTransferecnias;
                DataTable table = (DataTable)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(persons), (typeof(DataTable)));
                var nombreArchivo = $"excel_trans_{DateTime.Now.ToShortDateString().Replace("/","_")}.xlsx";
                                    
                MemoryStream memoryStream = new MemoryStream();
                
                using (SpreadsheetDocument document = SpreadsheetDocument.Create(memoryStream, SpreadsheetDocumentType.Workbook))
                {
                    WorkbookPart workbookPart = document.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();

                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    var sheetData = new SheetData();
                    worksheetPart.Worksheet = new Worksheet(sheetData);

                    Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                    Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet1" };

                    sheets.Append(sheet);

                    foreach (var item in listadoTransferecnias)
                    {
                        Row newRow = new Row();
                        Cell cell = new Cell();
                        cell.DataType = CellValues.Number;
                        cell.CellValue = new CellValue("2");//TIPO REGISTRO
                        newRow.AppendChild(cell);

                        //RUT
                        cell = new Cell();
                        cell.DataType = CellValues.String;
                        cell.CellValue = new CellValue(item.CodigoConvenio.ToString());
                        newRow.AppendChild(cell);

                        //NOMBRE
                        cell = new Cell();
                        cell.DataType = CellValues.String;
                        cell.CellValue = new CellValue(item.NombreEdificio);
                        newRow.AppendChild(cell);

                        //N° CUENTA
                        cell = new Cell();
                        cell.DataType = CellValues.String;
                        cell.CellValue = new CellValue(item.NumeroCuenta);
                        newRow.AppendChild(cell);

                        //MONTO A  APGAR
                        cell = new Cell();
                        cell.DataType = CellValues.String;
                        cell.CellValue = new CellValue(item.MontoTransferencia);
                        newRow.AppendChild(cell);

                        //CODIGO TIPO CUENTA
                        cell = new Cell();
                        cell.DataType = CellValues.String;
                        cell.CellValue = new CellValue(item.CodigoTipoCuenta);
                        newRow.AppendChild(cell);

                        //CODIGO BANCO
                        cell = new Cell();
                        cell.DataType = CellValues.String;
                        cell.CellValue = new CellValue(item.CodigoBanco);
                        newRow.AppendChild(cell);

                        //EMAIL
                        cell = new Cell();
                        cell.DataType = CellValues.String;
                        cell.CellValue = new CellValue(item.EmailNotificacion);
                        newRow.AppendChild(cell);

                        //GLOSA
                        cell = new Cell();
                        cell.DataType = CellValues.String;
                        cell.CellValue = new CellValue("PAGO PROVEEDOR");
                        newRow.AppendChild(cell);

                        sheetData.AppendChild(newRow);
                    }
                    workbookPart.Workbook.Save();
                }

                var urlDocumento = await GuardarArchivo(memoryStream, nombreArchivo);

                ArchivoPagoProveedoresModel archivoPagoProveedoresModel = new ArchivoPagoProveedoresModel();
                archivoPagoProveedoresModel.FechaCreacion = DateTime.Now;
                archivoPagoProveedoresModel.NombreArchivo = nombreArchivo;
                archivoPagoProveedoresModel.RutaArchivo = urlDocumento;
                archivoPagoProveedoresModel.NumeroTransferencias = listadoTransferecnias.Count;
                archivoPagoProveedoresModel = archivoPagoProveedoresRepository.CrearArchivoPagoProveedores(archivoPagoProveedoresModel);

                respuesta = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;

        }

        public async Task<string> GuardarArchivo(MemoryStream memoryStream, string nombreArchivo)
        {
            string urlDocumento = string.Empty;
            try
            {
                //var nombreArchivo = $"excel_trans_{DateTime.Now.ToShortDateString()}.xlsx";
                var s3Client = new AmazonS3Client(settings.AWSProfile.AccessKey, settings.AWSProfile.SecretKey, Amazon.RegionEndpoint.USEast1);
                if (memoryStream != null)
                {
                   
                    var fileTransferUtility = new TransferUtility(s3Client);
                    var uploadRequest = new TransferUtilityUploadRequest
                    {
                        InputStream = memoryStream,
                        Key = nombreArchivo,
                        BucketName = settings.AWSProfile.BucketName,
                        ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    };
                    fileTransferUtility.Upload(uploadRequest);
                    Console.WriteLine($"Archivo cargado en S3 -  {nombreArchivo}");
                    urlDocumento = $"{settings.AWSProfile.PublicUrl}/{nombreArchivo}";
                }

                byte[] pdf = null;
                // Create a GetObject request
                var request = new GetObjectRequest
                {
                    BucketName = settings.AWSProfile.BucketName,
                    Key = nombreArchivo,
                };

              ///  var s3Client = new AmazonS3Client(settingsConfig.AWSProfile.AccessKey, settingsConfig.AWSProfile.SecretKey, Amazon.RegionEndpoint.USEast1);
                // Issue request and remember to dispose of the response
                var response = await s3Client.GetObjectAsync(request);
                using (MemoryStream ms = new MemoryStream())
                {
                    response.ResponseStream.CopyTo(ms);
                    pdf = ms.ToArray();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en S3 -  {ex.Message}");
                return null;
            }

            return urlDocumento;
        }



    }
}

