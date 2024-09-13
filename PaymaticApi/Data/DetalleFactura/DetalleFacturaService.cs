






/**
* (c)2013-2023 CodeBase Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*25-10-2023,Generador de Código, Clase Inicial 
*/


using AutoMapper;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Http;
using Cl.Intertrade.ActivPay.Helpers.Base;
using Cl.Intertrade.ActivPay.Entities.DetalleFactura;
using Cl.Intertrade.ActivPay.Request.DetalleFactura;
using Cl.Intertrade.ActivPay.Result.DetalleFactura;
using Cl.Intertrade.ActivPay.Repository.DetalleFactura;

namespace Cl.Intertrade.ActivPay.Data.DetalleFactura
{
	/// <summary>
	/// Esta Clase DetalleFactura  permite gestionar reglas de negocio asociados a la entidad DetalleFactura
	/// </summary>
	public partial class DetalleFacturaService : IDetalleFacturaService
	{	
        private ISettingsConfig settings;
        private IDetalleFacturaRepository detalleFacturaRepository;
        private ILogger<DetalleFacturaService> logger;
        private IMapper mapper;
        public DetalleFacturaService(IDetalleFacturaRepository detalleFacturaRepository, ISettingsConfig settings, ILogger<DetalleFacturaService> logger, IMapper mapper)
        {
            this.detalleFacturaRepository = detalleFacturaRepository;
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
		/// <returns>Objeto DetalleFacturaResult con información del resultado de la operación</returns>
		public ListadoDetalleFacturaResult ObtenerDetalleFacturas()
		{
			ListadoDetalleFacturaResult listadoDetalleFacturaResult = new ListadoDetalleFacturaResult();
            listadoDetalleFacturaResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
				var detalleFacturas = detalleFacturaRepository.ObtenerDetalleFacturas();
                listadoDetalleFacturaResult.DetalleFacturas = new List<DetalleFacturaResult>();

                if (detalleFacturas != null)
                {
                    listadoDetalleFacturaResult.DetalleFacturas = mapper.Map<IList<DetalleFacturaResult>>(detalleFacturas);
                    listadoDetalleFacturaResult.StatusCode = StatusCodes.Status200OK;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"DetalleFacturaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoDetalleFacturaResult;
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="numeroFactura"></param>
/// <param name="transferenciaId"></param>
/// <returns>Objeto DetalleFacturaResult con información del resultado de la operación</returns>
		public ListadoDetalleFacturaResult BuscarDetalleFacturas(int numeroFactura  )
		{
			ListadoDetalleFacturaResult listadoDetalleFacturaResult = new ListadoDetalleFacturaResult();
            listadoDetalleFacturaResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
				var detalleFacturas = detalleFacturaRepository.BuscarDetalleFacturas(numeroFactura);
                listadoDetalleFacturaResult.DetalleFacturas = new List<DetalleFacturaResult>();

                if (detalleFacturas != null)
                {
                    listadoDetalleFacturaResult.DetalleFacturas = mapper.Map<IList<DetalleFacturaResult>>(detalleFacturas);
                    listadoDetalleFacturaResult.StatusCode = StatusCodes.Status200OK;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"DetalleFacturaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoDetalleFacturaResult;
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="numeroFactura"></param>
/// <param name="transferenciaId"></param>
/// <returns>Objeto DetalleFacturaResult con información del resultado de la operación</returns>
		public DetalleFacturaResult ObtenerDetalleFactura(int numeroFactura , int transferenciaId )
        {
			DetalleFacturaResult detalleFacturaResult = new DetalleFacturaResult();
            detalleFacturaResult.StatusCode = StatusCodes.Status202Accepted;
			try
			{
				var detalleFactura = detalleFacturaRepository.ObtenerDetalleFactura(numeroFactura, transferenciaId);
                if (detalleFactura!=null)
                {
                    detalleFacturaResult = mapper.Map<DetalleFacturaResult>(detalleFactura);
                    detalleFacturaResult.StatusCode = StatusCodes.Status200OK;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"DetalleFacturaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return detalleFacturaResult;
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="detalleFacturaModel"></param>
		/// <returns>Objeto DetalleFacturaResult con información del resultado de la operación</returns>
		public DetalleFacturaResult CrearDetalleFactura(DetalleFacturaRequest detalleFacturaRequest)
		{
			DetalleFacturaResult detalleFacturaResult = new DetalleFacturaResult();
            detalleFacturaResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {
				var detalleFactura = mapper.Map<DetalleFacturaModel>(detalleFacturaRequest);
                detalleFactura = detalleFacturaRepository.CrearDetalleFactura(detalleFactura);
                if (detalleFactura != null)
                {
                    detalleFacturaResult = mapper.Map<DetalleFacturaResult>(detalleFactura);
                    detalleFacturaResult.StatusCode = StatusCodes.Status201Created;
                }
			}
			catch (Exception e)
            {
                logger.LogError($"DetalleFacturaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return detalleFacturaResult;
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="detalleFacturaModel"></param>
		/// <returns>Objeto DetalleFacturaResult con información del resultado de la operación</returns>
		public DetalleFacturaResult ActualizarDetalleFactura(DetalleFacturaRequest detalleFacturaRequest)
		{
			DetalleFacturaResult detalleFacturaResult = new DetalleFacturaResult();
            detalleFacturaResult.StatusCode = StatusCodes.Status202Accepted;
			try
			{
				var detalleFactura = mapper.Map<DetalleFacturaModel>(detalleFacturaRequest);
                var result = detalleFacturaRepository.ActualizarDetalleFactura(detalleFactura);
                if (result)
                {
                    detalleFacturaResult.StatusCode = StatusCodes.Status204NoContent;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"DetalleFacturaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return detalleFacturaResult;
		}
		
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="detalleFacturaModel"></param>
		/// <returns>Objeto DetalleFacturaResult con información del resultado de la operación</returns>
		public DetalleFacturaResult EliminarDetalleFactura(int numeroFactura , int transferenciaId )
        {
			DetalleFacturaResult detalleFacturaResult = new DetalleFacturaResult();
            detalleFacturaResult.StatusCode = StatusCodes.Status202Accepted;
			try
			{
				var result = detalleFacturaRepository.EliminarDetalleFactura(numeroFactura, transferenciaId);
                if (result)
                {
                    detalleFacturaResult.StatusCode = StatusCodes.Status204NoContent;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"DetalleFacturaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return detalleFacturaResult;
        }
	}
}

