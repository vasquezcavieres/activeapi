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
using Cl.Intertrade.ActivPay.Entities.DetalleTransferencia;
using Cl.Intertrade.ActivPay.Request.DetalleTransferencia;
using Cl.Intertrade.ActivPay.Result.DetalleTransferencia;
using Cl.Intertrade.ActivPay.Repository.DetalleTransferencia;

namespace Cl.Intertrade.ActivPay.Data.DetalleTransferencia
{
	/// <summary>
	/// Esta Clase DetalleTransferencia  permite gestionar reglas de negocio asociados a la entidad DetalleTransferencia
	/// </summary>
	public partial class DetalleTransferenciaService : IDetalleTransferenciaService
	{	
        private ISettingsConfig settings;
        private IDetalleTransferenciaRepository detalleTransferenciaRepository;
        private ILogger<DetalleTransferenciaService> logger;
        private IMapper mapper;
        public DetalleTransferenciaService(IDetalleTransferenciaRepository detalleTransferenciaRepository, ISettingsConfig settings, ILogger<DetalleTransferenciaService> logger, IMapper mapper)
        {
            this.detalleTransferenciaRepository = detalleTransferenciaRepository;
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
		/// <returns>Objeto DetalleTransferenciaResult con información del resultado de la operación</returns>
		public ListadoDetalleTransferenciaResult ObtenerDetalleTransferencias()
		{
			ListadoDetalleTransferenciaResult listadoDetalleTransferenciaResult = new ListadoDetalleTransferenciaResult();
            listadoDetalleTransferenciaResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
				var detalleTransferencias = detalleTransferenciaRepository.ObtenerDetalleTransferencias();
                listadoDetalleTransferenciaResult.DetalleTransferencias = new List<DetalleTransferenciaResult>();

                if (detalleTransferencias != null)
                {
                    listadoDetalleTransferenciaResult.DetalleTransferencias = mapper.Map<IList<DetalleTransferenciaResult>>(detalleTransferencias);
                    listadoDetalleTransferenciaResult.StatusCode = StatusCodes.Status200OK;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"DetalleTransferenciaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoDetalleTransferenciaResult;
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="transferenciaId"></param>
/// <param name="rutRazonSocial"></param>
/// <returns>Objeto DetalleTransferenciaResult con información del resultado de la operación</returns>
		public ListadoDetalleTransferenciaResult BuscarDetalleTransferencias(int transferenciaId , int rutRazonSocial )
		{
			ListadoDetalleTransferenciaResult listadoDetalleTransferenciaResult = new ListadoDetalleTransferenciaResult();
            listadoDetalleTransferenciaResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
				var detalleTransferencias = detalleTransferenciaRepository.BuscarDetalleTransferencias(transferenciaId, rutRazonSocial);
                listadoDetalleTransferenciaResult.DetalleTransferencias = new List<DetalleTransferenciaResult>();

                if (detalleTransferencias != null)
                {
                    listadoDetalleTransferenciaResult.DetalleTransferencias = mapper.Map<IList<DetalleTransferenciaResult>>(detalleTransferencias);
                    listadoDetalleTransferenciaResult.StatusCode = StatusCodes.Status200OK;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"DetalleTransferenciaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoDetalleTransferenciaResult;
		}


        public ListadoDetalleTransferenciaResult BuscarDetalleTransferencias(int transferenciaId)
        {
            ListadoDetalleTransferenciaResult listadoDetalleTransferenciaResult = new ListadoDetalleTransferenciaResult();
            listadoDetalleTransferenciaResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
                var detalleTransferencias = detalleTransferenciaRepository.BuscarDetalleTransferencias(transferenciaId);
                listadoDetalleTransferenciaResult.DetalleTransferencias = new List<DetalleTransferenciaResult>();

                if (detalleTransferencias != null)
                {
                    listadoDetalleTransferenciaResult.DetalleTransferencias = mapper.Map<IList<DetalleTransferenciaResult>>(detalleTransferencias);
                    listadoDetalleTransferenciaResult.StatusCode = StatusCodes.Status200OK;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"DetalleTransferenciaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoDetalleTransferenciaResult;
        }


        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="transferenciaId"></param>
        /// <param name="rutRazonSocial"></param>
        /// <returns>Objeto DetalleTransferenciaResult con información del resultado de la operación</returns>
        public DetalleTransferenciaResult ObtenerDetalleTransferencia(int transferenciaId , int rutRazonSocial )
        {
			DetalleTransferenciaResult detalleTransferenciaResult = new DetalleTransferenciaResult();
            detalleTransferenciaResult.StatusCode = StatusCodes.Status202Accepted;
			try
			{
				var detalleTransferencia = detalleTransferenciaRepository.ObtenerDetalleTransferencia(transferenciaId, rutRazonSocial);
                if (detalleTransferencia!=null)
                {
                    detalleTransferenciaResult = mapper.Map<DetalleTransferenciaResult>(detalleTransferencia);
                    detalleTransferenciaResult.StatusCode = StatusCodes.Status200OK;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"DetalleTransferenciaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return detalleTransferenciaResult;
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="detalleTransferenciaModel"></param>
		/// <returns>Objeto DetalleTransferenciaResult con información del resultado de la operación</returns>
		public DetalleTransferenciaResult CrearDetalleTransferencia(DetalleTransferenciaRequest detalleTransferenciaRequest)
		{
			DetalleTransferenciaResult detalleTransferenciaResult = new DetalleTransferenciaResult();
            detalleTransferenciaResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {
				var detalleTransferencia = mapper.Map<DetalleTransferenciaModel>(detalleTransferenciaRequest);
                detalleTransferencia = detalleTransferenciaRepository.CrearDetalleTransferencia(detalleTransferencia);
                if (detalleTransferencia != null)
                {
                    detalleTransferenciaResult = mapper.Map<DetalleTransferenciaResult>(detalleTransferencia);
                    detalleTransferenciaResult.StatusCode = StatusCodes.Status201Created;
                }
			}
			catch (Exception e)
            {
                logger.LogError($"DetalleTransferenciaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return detalleTransferenciaResult;
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="detalleTransferenciaModel"></param>
		/// <returns>Objeto DetalleTransferenciaResult con información del resultado de la operación</returns>
		public DetalleTransferenciaResult ActualizarDetalleTransferencia(DetalleTransferenciaRequest detalleTransferenciaRequest)
		{
			DetalleTransferenciaResult detalleTransferenciaResult = new DetalleTransferenciaResult();
            detalleTransferenciaResult.StatusCode = StatusCodes.Status202Accepted;
			try
			{
				var detalleTransferencia = mapper.Map<DetalleTransferenciaModel>(detalleTransferenciaRequest);
                var result = detalleTransferenciaRepository.ActualizarDetalleTransferencia(detalleTransferencia);
                if (result)
                {
                    detalleTransferenciaResult.StatusCode = StatusCodes.Status204NoContent;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"DetalleTransferenciaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return detalleTransferenciaResult;
		}
		
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="detalleTransferenciaModel"></param>
		/// <returns>Objeto DetalleTransferenciaResult con información del resultado de la operación</returns>
		public DetalleTransferenciaResult EliminarDetalleTransferencia(int transferenciaId , int rutRazonSocial )
        {
			DetalleTransferenciaResult detalleTransferenciaResult = new DetalleTransferenciaResult();
            detalleTransferenciaResult.StatusCode = StatusCodes.Status202Accepted;
			try
			{
				var result = detalleTransferenciaRepository.EliminarDetalleTransferencia(transferenciaId, rutRazonSocial);
                if (result)
                {
                    detalleTransferenciaResult.StatusCode = StatusCodes.Status204NoContent;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"DetalleTransferenciaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return detalleTransferenciaResult;
        }
	}
}

