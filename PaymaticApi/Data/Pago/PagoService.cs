






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


using AutoMapper;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Http;
using Cl.Intertrade.ActivPay.Helpers.Base;
using Cl.Intertrade.ActivPay.Entities.Pago;
using Cl.Intertrade.ActivPay.Request.Pago;
using Cl.Intertrade.ActivPay.Result.Pago;
using Cl.Intertrade.ActivPay.Repository.Pago;

namespace Cl.Intertrade.ActivPay.Data.Pago
{
    /// <summary>
    /// Esta Clase Pago  permite gestionar reglas de negocio asociados a la entidad Pago
    /// </summary>
    public partial class PagoService : IPagoService
    {
        private ISettingsConfig settings;
        private IPagoRepository pagoRepository;
        private ILogger<PagoService> logger;
        private IMapper mapper;
        public PagoService(IPagoRepository pagoRepository, ISettingsConfig settings, ILogger<PagoService> logger, IMapper mapper)
        {
            this.pagoRepository = pagoRepository;
            this.mapper = mapper;
            this.settings = settings;
            this.logger = logger;
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <returns>Objeto PagoResult con información del resultado de la operación</returns>
        public ListadoPagoResult ObtenerPagos(PagoRequest pagoRequest)
        {
            ListadoPagoResult listadoPagoResult = new ListadoPagoResult();
            listadoPagoResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
                var pagoModel = mapper.Map<PagoModel>(pagoRequest);
                var pagos = pagoRepository.ObtenerPagos(pagoModel);
                listadoPagoResult.Pagos = new List<PagoResult>();

                if (pagos != null)
                {
                    listadoPagoResult.Pagos = mapper.Map<IList<PagoResult>>(pagos);
                    listadoPagoResult.StatusCode = StatusCodes.Status200OK;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"PagoService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoPagoResult;
        }

  

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="pagoId"></param>
        /// <returns>Objeto PagoResult con información del resultado de la operación</returns>
        public ListadoPagoResult BuscarPagos(string pagoId)
        {
            ListadoPagoResult listadoPagoResult = new ListadoPagoResult();
            listadoPagoResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
                var pagos = pagoRepository.BuscarPagos(pagoId);
                listadoPagoResult.Pagos = new List<PagoResult>();

                if (pagos != null)
                {
                    listadoPagoResult.Pagos = mapper.Map<IList<PagoResult>>(pagos);
                    listadoPagoResult.StatusCode = StatusCodes.Status200OK;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"PagoService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoPagoResult;
        }

        public ListadoPagoResult BuscarPagosEdificio(string codigoEdificio)
        {
            ListadoPagoResult listadoPagoResult = new ListadoPagoResult();
            listadoPagoResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
                var pagos = pagoRepository.BuscarPagosEdificio(codigoEdificio);
                listadoPagoResult.Pagos = new List<PagoResult>();

                if (pagos != null)
                {
                    listadoPagoResult.Pagos = mapper.Map<IList<PagoResult>>(pagos);
                    listadoPagoResult.StatusCode = StatusCodes.Status200OK;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"PagoService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoPagoResult;
        }

        public ListadoPagoResult BuscarPagosConvenio(string codigoConvenio)
        {
            ListadoPagoResult listadoPagoResult = new ListadoPagoResult();
            listadoPagoResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
                var pagos = pagoRepository.BuscarPagosConvenio(codigoConvenio);
                listadoPagoResult.Pagos = new List<PagoResult>();

                if (pagos != null)
                {
                    listadoPagoResult.Pagos = mapper.Map<IList<PagoResult>>(pagos);
                    listadoPagoResult.StatusCode = StatusCodes.Status200OK;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"PagoService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoPagoResult;
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="pagoId"></param>
        /// <returns>Objeto PagoResult con información del resultado de la operación</returns>
        public PagoResult ObtenerPago(string pagoId)
        {
            PagoResult pagoResult = new PagoResult();
            pagoResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {
                var pago = pagoRepository.ObtenerPago(pagoId);
                if (pago != null)
                {
                    pagoResult = mapper.Map<PagoResult>(pago);
                    pagoResult.StatusCode = StatusCodes.Status200OK;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"PagoService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return pagoResult;
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="pagoModel"></param>
        /// <returns>Objeto PagoResult con información del resultado de la operación</returns>
        public PagoResult CrearPago(PagoRequest pagoRequest)
        {
            PagoResult pagoResult = new PagoResult();
            pagoResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {
                var pago = mapper.Map<PagoModel>(pagoRequest);
                pago = pagoRepository.CrearPago(pago);
                if (pago != null)
                {
                    pagoResult = mapper.Map<PagoResult>(pago);
                    pagoResult.StatusCode = StatusCodes.Status201Created;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"PagoService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return pagoResult;
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="pagoModel"></param>
        /// <returns>Objeto PagoResult con información del resultado de la operación</returns>
        public PagoResult ActualizarPago(PagoRequest pagoRequest)
        {
            PagoResult pagoResult = new PagoResult();
            pagoResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {
                var pago = mapper.Map<PagoModel>(pagoRequest);
                var result = pagoRepository.ActualizarPago(pago);
                if (result)
                {
                    pagoResult.StatusCode = StatusCodes.Status204NoContent;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"PagoService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return pagoResult;
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="pagoModel"></param>
        /// <returns>Objeto PagoResult con información del resultado de la operación</returns>
        public PagoResult EliminarPago(string pagoId)
        {
            PagoResult pagoResult = new PagoResult();
            pagoResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {
                var result = pagoRepository.EliminarPago(pagoId);
                if (result)
                {
                    pagoResult.StatusCode = StatusCodes.Status204NoContent;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"PagoService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return pagoResult;
        }
    }
}

