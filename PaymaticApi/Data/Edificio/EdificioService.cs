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
using Cl.Intertrade.ActivPay.Entities.Edificio;
using Cl.Intertrade.ActivPay.Request.Edificio;
using Cl.Intertrade.ActivPay.Result.Edificio;
using Cl.Intertrade.ActivPay.Repository.Edificio;
using Cl.Intertrade.ActivPay.Repository.Convenio;
using Cl.Intertrade.ActivPay.Repository.Pago;
using Microsoft.OpenApi.Validations;
using Cl.Intertrade.ActivPay.Data.Banco;
using Cl.Intertrade.ActivPay.Repository.Banco;
using Cl.Intertrade.ActivPay.Repository.TipoAbono;

namespace Cl.Intertrade.ActivPay.Data.Edificio
{
    /// <summary>
    /// Esta Clase Edificio  permite gestionar reglas de negocio asociados a la entidad Edificio
    /// </summary>
    public partial class EdificioService : IEdificioService
    {
        private ISettingsConfig settings;
        private IEdificioRepository edificioRepository;
        private ILogger<EdificioService> logger;
        private IMapper mapper;
        private IConvenioRepository convenioRepository;
        private IPagoRepository pagoRepository;
        private IBancoRepository bancoRepository;
        private ITipoAbonoRepository tipoAbonoRepository;
        public EdificioService(IEdificioRepository edificioRepository, ISettingsConfig settings, ILogger<EdificioService> logger, IMapper mapper, 
            IConvenioRepository convenioRepository, IPagoRepository pagoRepository, ITipoAbonoRepository tipoAbonoRepository, IBancoRepository bancoRepository)
        {
            this.edificioRepository = edificioRepository;
            this.mapper = mapper;
            this.settings = settings;
            this.logger = logger;
            this.convenioRepository = convenioRepository;
            this.pagoRepository = pagoRepository;
            this.bancoRepository = bancoRepository;
            this.tipoAbonoRepository = tipoAbonoRepository;
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <returns>Objeto EdificioResult con información del resultado de la operación</returns>
        public ListadoEdificioResult ObtenerEdificios()
        {
            ListadoEdificioResult listadoEdificioResult = new ListadoEdificioResult();
            listadoEdificioResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
                var edificios = edificioRepository.ObtenerEdificios();
                listadoEdificioResult.Edificios = new List<EdificioResult>();

                if (edificios != null)
                {
                    listadoEdificioResult.Edificios = mapper.Map<IList<EdificioResult>>(edificios);
                    listadoEdificioResult.StatusCode = StatusCodes.Status200OK;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"EdificioService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoEdificioResult;
        }

        public ListadoEdificioResult ObtenerEdificiosAsociados()
        {
            ListadoEdificioResult listadoEdificioResult = new ListadoEdificioResult();
            listadoEdificioResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
                var edificios = edificioRepository.ObtenerEdificiosAsociados();
                listadoEdificioResult.Edificios = new List<EdificioResult>();

                if (edificios != null)
                {
                    listadoEdificioResult.Edificios = mapper.Map<IList<EdificioResult>>(edificios);
                    listadoEdificioResult.StatusCode = StatusCodes.Status200OK;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"EdificioService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoEdificioResult;
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="codigoEdificio"></param>
        /// <returns>Objeto EdificioResult con información del resultado de la operación</returns>
        public ListadoEdificioResult BuscarEdificios(string codigoEdificio)
        {
            ListadoEdificioResult listadoEdificioResult = new ListadoEdificioResult();
            listadoEdificioResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
                var edificios = edificioRepository.BuscarEdificios(codigoEdificio);
                listadoEdificioResult.Edificios = new List<EdificioResult>();

                if (edificios != null)
                {
                    listadoEdificioResult.Edificios = mapper.Map<IList<EdificioResult>>(edificios);
                    listadoEdificioResult.StatusCode = StatusCodes.Status200OK;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"EdificioService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoEdificioResult;
        }

        public ListadoEdificioResult BuscarEdificiosConvenio(int rutRazonSocial)
        {
            ListadoEdificioResult listadoEdificioResult = new ListadoEdificioResult();
            listadoEdificioResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
                var edificios = edificioRepository.BuscarEdificiosConvenio(rutRazonSocial);
                listadoEdificioResult.Edificios = new List<EdificioResult>();

                if (edificios != null)
                {
                    var convenio = convenioRepository.ObtenerConvenio(rutRazonSocial);
                    listadoEdificioResult.Edificios = mapper.Map<IList<EdificioResult>>(edificios);
                    if (listadoEdificioResult.Edificios.Count > 0)
                    {
                        foreach (var unEdificio in listadoEdificioResult.Edificios)
                        {
                            var pagos = pagoRepository.BuscarPagosEdificio(unEdificio.CodigoEdificio);
                            unEdificio.Ventas = pagos.Sum(c => c.MontoPago);
                            unEdificio.Comisiones = (unEdificio.Ventas * convenio.PorcentajeComision) < convenio.MinimoGarantizadoComision ? convenio.MinimoGarantizadoComision : (unEdificio.Ventas * convenio.PorcentajeComision);
                            unEdificio.MontoTransferir = unEdificio.Ventas - unEdificio.Comisiones;
                        }
                    }

                    listadoEdificioResult.StatusCode = StatusCodes.Status200OK;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"EdificioService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoEdificioResult;
        }

        public ListadoEdificioResult BuscarEdificiosConvenio(EdificioRequest edificioRequest)
        {
            ListadoEdificioResult listadoEdificioResult = new ListadoEdificioResult();
            listadoEdificioResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
                var edificios = edificioRepository.BuscarEdificiosConvenio(edificioRequest.RutRazonSocial);
                listadoEdificioResult.Edificios = new List<EdificioResult>();

                if (edificios != null)
                {
                    var convenio = convenioRepository.ObtenerConvenio(edificioRequest.RutRazonSocial);
                    listadoEdificioResult.Edificios = mapper.Map<IList<EdificioResult>>(edificios);
                    if (listadoEdificioResult.Edificios.Count > 0)
                    {
                        foreach (var unEdificio in listadoEdificioResult.Edificios)
                        {
                            var edificioModel = new EdificioModel();
                            edificioModel.CodigoEdificio = unEdificio.CodigoEdificio;
                            edificioModel.FechaDesde = edificioRequest.FechaDesde;
                            edificioRequest.FechaHasta = edificioRequest.FechaHasta;

                            var pagos = pagoRepository.ObtenerPagosEdificio(edificioModel);
                            unEdificio.Ventas = pagos.Sum(c => c.MontoPago);
                            unEdificio.Comisiones = (unEdificio.Ventas * convenio.PorcentajeComision) < convenio.MinimoGarantizadoComision ? convenio.MinimoGarantizadoComision : (unEdificio.Ventas * convenio.PorcentajeComision);
                            unEdificio.MontoTransferir = unEdificio.Ventas - unEdificio.Comisiones;
                        }
                    }

                    listadoEdificioResult.StatusCode = StatusCodes.Status200OK;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"EdificioService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoEdificioResult;
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="codigoEdificio"></param>
        /// <returns>Objeto EdificioResult con información del resultado de la operación</returns>
        public EdificioResult ObtenerEdificio(string codigoEdificio)
        {
            EdificioResult edificioResult = new EdificioResult();
            edificioResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {
                var edificio = edificioRepository.ObtenerEdificio(codigoEdificio);
                if (edificio != null)
                {
                    edificioResult = mapper.Map<EdificioResult>(edificio);
                    edificioResult.StatusCode = StatusCodes.Status200OK;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"EdificioService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return edificioResult;
        }

        public EdificioResult ObtenerEdificioComunidad(int rutComunidad)
        {
            EdificioResult edificioResult = new EdificioResult();
            edificioResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {
                var edificio = edificioRepository.ObtenerEdificioComunidad(rutComunidad);
                if (edificio != null)
                {
                    edificioResult = mapper.Map<EdificioResult>(edificio);
                    edificioResult.StatusCode = StatusCodes.Status200OK;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"EdificioService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return edificioResult;
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="edificioModel"></param>
        /// <returns>Objeto EdificioResult con información del resultado de la operación</returns>
        public EdificioResult CrearEdificio(EdificioRequest edificioRequest)
        {
            EdificioResult edificioResult = new EdificioResult();
            edificioResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {
                var edificio = mapper.Map<EdificioModel>(edificioRequest);
                var banco = bancoRepository.ObtenerBanco(edificioRequest.Banco);                
                edificio.CodigoBanco = banco.CodigoBanco;
                edificio.Banco = banco.Nombre;

                var tipoAbono = tipoAbonoRepository.ObtenerTipoAbono(edificioRequest.TipoCuenta);
                edificio.TipoCuenta = tipoAbono.Nombre;
                edificio.CodigoTipoCuenta = tipoAbono.CodigoTipoAbono;

                edificio = edificioRepository.CrearEdificio(edificio);
                if (edificio != null)
                {
                    edificioResult = mapper.Map<EdificioResult>(edificio);
                    edificioResult.StatusCode = StatusCodes.Status201Created;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"EdificioService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return edificioResult;
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="edificioModel"></param>
        /// <returns>Objeto EdificioResult con información del resultado de la operación</returns>
        public EdificioResult ActualizarEdificio(EdificioRequest edificioRequest)
        {
            EdificioResult edificioResult = new EdificioResult();
            edificioResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {
                var edificio = mapper.Map<EdificioModel>(edificioRequest);
                var result = edificioRepository.ActualizarEdificio(edificio);
                if (result)
                {
                    edificioResult.StatusCode = StatusCodes.Status204NoContent;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"EdificioService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return edificioResult;
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="edificioModel"></param>
        /// <returns>Objeto EdificioResult con información del resultado de la operación</returns>
        public EdificioResult EliminarEdificio(string codigoEdificio)
        {
            EdificioResult edificioResult = new EdificioResult();
            edificioResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {
                var result = edificioRepository.EliminarEdificio(codigoEdificio);
                if (result)
                {
                    edificioResult.StatusCode = StatusCodes.Status204NoContent;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"EdificioService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return edificioResult;
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="edificioModel"></param>
        /// <returns>Objeto EdificioResult con información del resultado de la operación</returns>
        public EdificioResult AsociarEdificios(int rutRazonSocial, List<EdificioRequest> edificiosRequest)
        {
            EdificioResult edificioResult = new EdificioResult();
            edificioResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {

                var estado =  edificioRepository.DesAsociarEdificio(new EdificioModel() { RutRazonSocial = rutRazonSocial });
                if (estado)
                {
                    foreach (var unEdificio in edificiosRequest)
                    {
                        var edificio = mapper.Map<EdificioModel>(unEdificio);
                        edificio.RutRazonSocial = rutRazonSocial;
                        var respuesta = edificioRepository.AsociarEdificio(edificio);
                    }

                    edificioResult.StatusCode = StatusCodes.Status201Created;
                }
                else
                {
                    edificioResult.StatusCode = StatusCodes.Status400BadRequest;
                }


            }
            catch (Exception e)
            {
                logger.LogError($"EdificioService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return edificioResult;
        }

    }
}

