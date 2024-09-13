






/**
* (c)2013-2023 CodeBase Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*13-12-2023,Generador de Código, Clase Inicial 
*/


using AutoMapper;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Http;
using Cl.Intertrade.ActivPay.Helpers.Base;
using Cl.Intertrade.ActivPay.Entities.Uf;
using Cl.Intertrade.ActivPay.Request.Uf;
using Cl.Intertrade.ActivPay.Result.Uf;
using Cl.Intertrade.ActivPay.Repository.Uf;

namespace Cl.Intertrade.ActivPay.Data.Uf
{
	/// <summary>
	/// Esta Clase Uf  permite gestionar reglas de negocio asociados a la entidad Uf
	/// </summary>
	public partial class UfService : IUfService
	{	
        private ISettingsConfig settings;
        private IUfRepository ufRepository;
        private ILogger<UfService> logger;
        private IMapper mapper;
        public UfService(IUfRepository ufRepository, ISettingsConfig settings, ILogger<UfService> logger, IMapper mapper)
        {
            this.ufRepository = ufRepository;
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
		/// <returns>Objeto UfResult con información del resultado de la operación</returns>
		public ListadoUfResult ObtenerUfs()
		{
			ListadoUfResult listadoUfResult = new ListadoUfResult();
            listadoUfResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
				var ufs = ufRepository.ObtenerUfs();
                listadoUfResult.Ufs = new List<UfResult>();

                if (ufs != null)
                {
                    listadoUfResult.Ufs = mapper.Map<IList<UfResult>>(ufs);
                    listadoUfResult.StatusCode = StatusCodes.Status200OK;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"UfService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoUfResult;
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="fechaUf"></param>
/// <returns>Objeto UfResult con información del resultado de la operación</returns>
		public ListadoUfResult BuscarUfs(DateTime fechaUf )
		{
			ListadoUfResult listadoUfResult = new ListadoUfResult();
            listadoUfResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
				var ufs = ufRepository.BuscarUfs(fechaUf);
                listadoUfResult.Ufs = new List<UfResult>();

                if (ufs != null)
                {
                    listadoUfResult.Ufs = mapper.Map<IList<UfResult>>(ufs);
                    listadoUfResult.StatusCode = StatusCodes.Status200OK;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"UfService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoUfResult;
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="fechaUf"></param>
/// <returns>Objeto UfResult con información del resultado de la operación</returns>
		public UfResult ObtenerUf(DateTime fechaUf )
        {
			UfResult ufResult = new UfResult();
            ufResult.StatusCode = StatusCodes.Status202Accepted;
			try
			{
				var uf = ufRepository.ObtenerUf(fechaUf);
                if (uf!=null)
                {
                    ufResult = mapper.Map<UfResult>(uf);
                    ufResult.StatusCode = StatusCodes.Status200OK;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"UfService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return ufResult;
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="ufModel"></param>
		/// <returns>Objeto UfResult con información del resultado de la operación</returns>
		public UfResult CrearUf(UfRequest ufRequest)
		{
			UfResult ufResult = new UfResult();
            ufResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {
				var uf = mapper.Map<UfModel>(ufRequest);
                uf = ufRepository.CrearUf(uf);
                if (uf != null)
                {
                    ufResult = mapper.Map<UfResult>(uf);
                    ufResult.StatusCode = StatusCodes.Status201Created;
                }
			}
			catch (Exception e)
            {
                logger.LogError($"UfService: {e.Message}, {e.StackTrace}");
                ufResult.Errores = new List<string>();
                ufResult.Errores.Add(e.Message);
                ufResult.StatusCode = StatusCodes.Status500InternalServerError;
             
            }
            return ufResult;
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="ufModel"></param>
		/// <returns>Objeto UfResult con información del resultado de la operación</returns>
		public UfResult ActualizarUf(UfRequest ufRequest)
		{
			UfResult ufResult = new UfResult();
            ufResult.StatusCode = StatusCodes.Status202Accepted;
			try
			{
				var uf = mapper.Map<UfModel>(ufRequest);
                var result = ufRepository.ActualizarUf(uf);
                if (result)
                {
                    ufResult.StatusCode = StatusCodes.Status204NoContent;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"UfService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return ufResult;
		}
		
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="ufModel"></param>
		/// <returns>Objeto UfResult con información del resultado de la operación</returns>
		public UfResult EliminarUf(DateTime fechaUf )
        {
			UfResult ufResult = new UfResult();
            ufResult.StatusCode = StatusCodes.Status202Accepted;
			try
			{
				var result = ufRepository.EliminarUf(fechaUf);
                if (result)
                {
                    ufResult.StatusCode = StatusCodes.Status204NoContent;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"UfService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return ufResult;
        }
	}
}

