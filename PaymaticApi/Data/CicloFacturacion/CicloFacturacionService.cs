






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
using Cl.Intertrade.ActivPay.Entities.CicloTransferencia;
using Cl.Intertrade.ActivPay.Request.CicloTransferencia;
using Cl.Intertrade.ActivPay.Result.CicloTransferencia;
using Cl.Intertrade.ActivPay.Repository.CicloTransferencia;

namespace Cl.Intertrade.ActivPay.Data.CicloTransferencia
{
	/// <summary>
	/// Esta Clase CicloTransferencia  permite gestionar reglas de negocio asociados a la entidad CicloTransferencia
	/// </summary>
	public partial class CicloTransferenciaService : ICicloTransferenciaService
	{	
        private ISettingsConfig settings;
        private ICicloTransferenciaRepository cicloTransferenciaRepository;
        private ILogger<CicloTransferenciaService> logger;
        private IMapper mapper;
        public CicloTransferenciaService(ICicloTransferenciaRepository CicloTransferenciaRepository, ISettingsConfig settings, ILogger<CicloTransferenciaService> logger, IMapper mapper)
        {
            this.cicloTransferenciaRepository = CicloTransferenciaRepository;
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
		/// <returns>Objeto CicloTransferenciaResult con información del resultado de la operación</returns>
		public ListadoCicloTransferenciaResult ObtenerCicloTransferencias()
		{
			ListadoCicloTransferenciaResult listadoCicloTransferenciaResult = new ListadoCicloTransferenciaResult();
            listadoCicloTransferenciaResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
				var CicloTransferencias = cicloTransferenciaRepository.ObtenerCicloTransferencias();
                listadoCicloTransferenciaResult.CicloTransferencias = new List<CicloTransferenciaResult>();

                if (CicloTransferencias != null)
                {
                    listadoCicloTransferenciaResult.CicloTransferencias = mapper.Map<IList<CicloTransferenciaResult>>(CicloTransferencias);
                    listadoCicloTransferenciaResult.StatusCode = StatusCodes.Status200OK;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"CicloTransferenciaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoCicloTransferenciaResult;
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="creadoPor"></param>
/// <returns>Objeto CicloTransferenciaResult con información del resultado de la operación</returns>
		public ListadoCicloTransferenciaResult BuscarCicloTransferencias(string creadoPor )
		{
			ListadoCicloTransferenciaResult listadoCicloTransferenciaResult = new ListadoCicloTransferenciaResult();
            listadoCicloTransferenciaResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
				var CicloTransferencias = cicloTransferenciaRepository.BuscarCicloTransferencias(creadoPor);
                listadoCicloTransferenciaResult.CicloTransferencias = new List<CicloTransferenciaResult>();

                if (CicloTransferencias != null)
                {
                    listadoCicloTransferenciaResult.CicloTransferencias = mapper.Map<IList<CicloTransferenciaResult>>(CicloTransferencias);
                    listadoCicloTransferenciaResult.StatusCode = StatusCodes.Status200OK;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"CicloTransferenciaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoCicloTransferenciaResult;
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="creadoPor"></param>
/// <returns>Objeto CicloTransferenciaResult con información del resultado de la operación</returns>
		public CicloTransferenciaResult ObtenerCicloTransferencia(string codigoConvenio )
        {
			CicloTransferenciaResult cicloTransferenciaResult = new CicloTransferenciaResult();
            cicloTransferenciaResult.StatusCode = StatusCodes.Status202Accepted;
			try
			{
				var cicloTransferencia = cicloTransferenciaRepository.ObtenerCicloTransferencia(codigoConvenio);
                if (cicloTransferencia!=null)
                {
                    cicloTransferenciaResult = mapper.Map<CicloTransferenciaResult>(cicloTransferencia);
                    cicloTransferenciaResult.DiasTrasnferencias = cicloTransferenciaResult.DiasTransferencia.Split(",").ToList();
                    cicloTransferenciaResult.StatusCode = StatusCodes.Status200OK;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"CicloTransferenciaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return cicloTransferenciaResult;
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="CicloTransferenciaModel"></param>
		/// <returns>Objeto CicloTransferenciaResult con información del resultado de la operación</returns>
		public CicloTransferenciaResult CrearCicloTransferencia(CicloTransferenciaRequest CicloTransferenciaRequest)
		{
			CicloTransferenciaResult CicloTransferenciaResult = new CicloTransferenciaResult();
            CicloTransferenciaResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {
				var CicloTransferencia = mapper.Map<CicloTransferenciaModel>(CicloTransferenciaRequest);
                CicloTransferencia = cicloTransferenciaRepository.CrearCicloTransferencia(CicloTransferencia);
                if (CicloTransferencia != null)
                {
                    CicloTransferenciaResult = mapper.Map<CicloTransferenciaResult>(CicloTransferencia);
                    CicloTransferenciaResult.StatusCode = StatusCodes.Status201Created;
                }
			}
			catch (Exception e)
            {
                logger.LogError($"CicloTransferenciaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return CicloTransferenciaResult;
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="CicloTransferenciaModel"></param>
		/// <returns>Objeto CicloTransferenciaResult con información del resultado de la operación</returns>
		public CicloTransferenciaResult ActualizarCicloTransferencia(CicloTransferenciaRequest cicloTransferenciaRequest)
		{
			CicloTransferenciaResult cicloTransferenciaResult = new CicloTransferenciaResult();
            cicloTransferenciaResult.StatusCode = StatusCodes.Status202Accepted;
			try
			{
				var cicloTransferencia = mapper.Map<CicloTransferenciaModel>(cicloTransferenciaRequest);
                cicloTransferencia.FechaActualizacion = DateTime.Now;
                cicloTransferencia.DiasTransferencia = string.Join(',', cicloTransferenciaRequest.DiasTrasnferencias.Select(c => c));
                var result = cicloTransferenciaRepository.ActualizarCicloTransferencia(cicloTransferencia);
                if (result)
                {
                    cicloTransferenciaResult.StatusCode = StatusCodes.Status202Accepted;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"CicloTransferenciaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return cicloTransferenciaResult;
		}
		
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="CicloTransferenciaModel"></param>
		/// <returns>Objeto CicloTransferenciaResult con información del resultado de la operación</returns>
		public CicloTransferenciaResult EliminarCicloTransferencia(string creadoPor )
        {
			CicloTransferenciaResult CicloTransferenciaResult = new CicloTransferenciaResult();
            CicloTransferenciaResult.StatusCode = StatusCodes.Status202Accepted;
			try
			{
				var result = cicloTransferenciaRepository.EliminarCicloTransferencia(creadoPor);
                if (result)
                {
                    CicloTransferenciaResult.StatusCode = StatusCodes.Status204NoContent;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"CicloTransferenciaService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return CicloTransferenciaResult;
        }
	}
}

