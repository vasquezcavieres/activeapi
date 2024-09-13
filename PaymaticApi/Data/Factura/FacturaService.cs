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
using Cl.Intertrade.ActivPay.Entities.Factura;
using Cl.Intertrade.ActivPay.Request.Factura;
using Cl.Intertrade.ActivPay.Result.Factura;
using Cl.Intertrade.ActivPay.Repository.Factura;
using ActivPayApi.Models.Result.Factura;

namespace Cl.Intertrade.ActivPay.Data.Factura
{
    /// <summary>
    /// Esta Clase Factura  permite gestionar reglas de negocio asociados a la entidad Factura
    /// </summary>
    public partial class FacturaService : IFacturaService
    {
        private ISettingsConfig settings;
        private IFacturaRepository facturaRepository;
        private ILogger<FacturaService> logger;
        private IMapper mapper;
        public FacturaService(IFacturaRepository facturaRepository, ISettingsConfig settings, ILogger<FacturaService> logger, IMapper mapper)
        {
            this.facturaRepository = facturaRepository;
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
        /// <returns>Objeto FacturaResult con información del resultado de la operación</returns>
        public ListadoFacturaResult ObtenerFacturas()
        {
            ListadoFacturaResult listadoFacturaResult = new ListadoFacturaResult();
            listadoFacturaResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
                var facturas = facturaRepository.ObtenerFacturas();
                listadoFacturaResult.Facturas = new List<FacturaResult>();

                if (facturas != null)
                {
                    listadoFacturaResult.Facturas = mapper.Map<IList<FacturaResult>>(facturas);
                    listadoFacturaResult.StatusCode = StatusCodes.Status200OK;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"FacturaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoFacturaResult;
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="numeroFactura"></param>
        /// <returns>Objeto FacturaResult con información del resultado de la operación</returns>
        public ListadoFacturaResult BuscarFacturas(int numeroFactura)
        {
            ListadoFacturaResult listadoFacturaResult = new ListadoFacturaResult();
            listadoFacturaResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
                var facturas = facturaRepository.BuscarFacturas(numeroFactura);
                listadoFacturaResult.Facturas = new List<FacturaResult>();

                if (facturas != null)
                {
                    listadoFacturaResult.Facturas = mapper.Map<IList<FacturaResult>>(facturas);
                    listadoFacturaResult.StatusCode = StatusCodes.Status200OK;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"FacturaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoFacturaResult;
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="numeroFactura"></param>
        /// <returns>Objeto FacturaResult con información del resultado de la operación</returns>
        public FacturaResult ObtenerFactura(int numeroFactura)
        {
            FacturaResult facturaResult = new FacturaResult();
            facturaResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {
                var factura = facturaRepository.ObtenerFactura(numeroFactura);
                if (factura != null)
                {
                    facturaResult = mapper.Map<FacturaResult>(factura);
                    facturaResult.StatusCode = StatusCodes.Status200OK;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"FacturaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return facturaResult;
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="facturaModel"></param>
        /// <returns>Objeto FacturaResult con información del resultado de la operación</returns>
        public FacturaResult CrearFactura(FacturaRequest facturaRequest)
        {
            FacturaResult facturaResult = new FacturaResult();
            facturaResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {
                var factura = mapper.Map<FacturaModel>(facturaRequest);
                factura = facturaRepository.CrearFactura(factura);
                if (factura != null)
                {
                    facturaResult = mapper.Map<FacturaResult>(factura);
                    facturaResult.StatusCode = StatusCodes.Status201Created;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"FacturaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return facturaResult;
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="facturaModel"></param>
        /// <returns>Objeto FacturaResult con información del resultado de la operación</returns>
        public FacturaResult ActualizarFactura(FacturaRequest facturaRequest)
        {
            FacturaResult facturaResult = new FacturaResult();
            facturaResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {
                var factura = mapper.Map<FacturaModel>(facturaRequest);
                var result = facturaRepository.ActualizarFactura(factura);
                if (result)
                {
                    facturaResult.StatusCode = StatusCodes.Status204NoContent;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"FacturaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return facturaResult;
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="facturaModel"></param>
        /// <returns>Objeto FacturaResult con información del resultado de la operación</returns>
        public FacturaResult EliminarFactura(int numeroFactura)
        {
            FacturaResult facturaResult = new FacturaResult();
            facturaResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {
                var result = facturaRepository.EliminarFactura(numeroFactura);
                if (result)
                {
                    facturaResult.StatusCode = StatusCodes.Status204NoContent;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"FacturaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return facturaResult;
        }

        public ListadoFacturaResult BuscarFacturas(FacturaRequest facturaRequest)
        {
            ListadoFacturaResult listadoFacturaResult = new ListadoFacturaResult();
            listadoFacturaResult.StatusCode = StatusCodes.Status204NoContent;

            try
            {
                var factura = mapper.Map<FacturaModel>(facturaRequest);
                var facturas = facturaRepository.BuscarFacturas(factura);
                listadoFacturaResult.Facturas = new List<FacturaResult>();

                if (facturas != null)
                {
                    listadoFacturaResult.Facturas = mapper.Map<IList<FacturaResult>>(facturas);
                    listadoFacturaResult.StatusCode = StatusCodes.Status200OK;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"FacturaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoFacturaResult;
        }

        public FacturaResult AnularFactura(FacturaRequest facturaRequest)
        {
            FacturaResult facturaResult = new FacturaResult();
            facturaResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {
                var factura = mapper.Map<FacturaModel>(facturaRequest);
                factura = facturaRepository.AnularFactura(factura);
                if (factura != null && (factura.Errores == null || factura.Errores.Count == 0))
                {
                    facturaResult = mapper.Map<FacturaResult>(factura);
                    facturaResult.StatusCode = StatusCodes.Status201Created;
                }
                else
                {

                    facturaResult = mapper.Map<FacturaResult>(factura);
                    facturaResult.StatusCode = StatusCodes.Status404NotFound;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"FacturaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return facturaResult;
        }

        public async Task<FacturaResult> ObtenerNotaCredito(FacturaRequest facturaRequest)
        {
            FacturaResult facturaResult = new FacturaResult();
            facturaResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {
                var factura = mapper.Map<FacturaModel>(facturaRequest);
                factura = await facturaRepository.ObtenerNotaCredito(factura);
                if (factura != null && (factura.Errores == null || factura.Errores.Count == 0))
                {
                    facturaResult = mapper.Map<FacturaResult>(factura);
                    facturaResult.StatusCode = StatusCodes.Status201Created;
                }
                else
                {

                    facturaResult = mapper.Map<FacturaResult>(factura);
                    facturaResult.StatusCode = StatusCodes.Status404NotFound;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"FacturaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return facturaResult;
        }
    }
}



