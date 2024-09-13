/**
* (c)2013-2023 CodeBase Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*11-12-2023,Generador de Código, Clase Inicial 
*/


using AutoMapper;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Http;
using Cl.Intertrade.ActivPay.Helpers.Base;
using Cl.Intertrade.ActivPay.Entities.TipoAbono;
using Cl.Intertrade.ActivPay.Request.TipoAbono;
using Cl.Intertrade.ActivPay.Result.TipoAbono;
using Cl.Intertrade.ActivPay.Repository.TipoAbono;

namespace Cl.Intertrade.ActivPay.Data.TipoAbono
{
	/// <summary>
	/// Esta Clase TipoAbono  permite gestionar reglas de negocio asociados a la entidad TipoAbono
	/// </summary>
	public partial class TipoAbonoService : ITipoAbonoService
	{	
        private ISettingsConfig settings;
        private ITipoAbonoRepository tipoAbonoRepository;
        private ILogger<TipoAbonoService> logger;
        private IMapper mapper;
        public TipoAbonoService(ITipoAbonoRepository tipoAbonoRepository, ISettingsConfig settings, ILogger<TipoAbonoService> logger, IMapper mapper)
        {
            this.tipoAbonoRepository = tipoAbonoRepository;
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
		/// <returns>Objeto TipoAbonoResult con información del resultado de la operación</returns>
		public ListadoTipoAbonoResult ObtenerTipoAbonos()
		{
			ListadoTipoAbonoResult listadoTipoAbonoResult = new ListadoTipoAbonoResult();
            listadoTipoAbonoResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
				var tipoAbonos = tipoAbonoRepository.ObtenerTipoAbonos();
                listadoTipoAbonoResult.TipoAbonos = new List<TipoAbonoResult>();

                if (tipoAbonos != null)
                {
                    listadoTipoAbonoResult.TipoAbonos = mapper.Map<IList<TipoAbonoResult>>(tipoAbonos);
                    listadoTipoAbonoResult.StatusCode = StatusCodes.Status200OK;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"TipoAbonoService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoTipoAbonoResult;
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <returns>Objeto TipoAbonoResult con información del resultado de la operación</returns>
		public ListadoTipoAbonoResult BuscarTipoAbonos()
		{
			ListadoTipoAbonoResult listadoTipoAbonoResult = new ListadoTipoAbonoResult();
            listadoTipoAbonoResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
				var tipoAbonos = tipoAbonoRepository.BuscarTipoAbonos();
                listadoTipoAbonoResult.TipoAbonos = new List<TipoAbonoResult>();

                if (tipoAbonos != null)
                {
                    listadoTipoAbonoResult.TipoAbonos = mapper.Map<IList<TipoAbonoResult>>(tipoAbonos);
                    listadoTipoAbonoResult.StatusCode = StatusCodes.Status200OK;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"TipoAbonoService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoTipoAbonoResult;
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <returns>Objeto TipoAbonoResult con información del resultado de la operación</returns>
		public TipoAbonoResult ObtenerTipoAbono()
        {
			TipoAbonoResult tipoAbonoResult = new TipoAbonoResult();
            tipoAbonoResult.StatusCode = StatusCodes.Status202Accepted;
			try
			{
				var tipoAbono = tipoAbonoRepository.ObtenerTipoAbono("");
                if (tipoAbono!=null)
                {
                    tipoAbonoResult = mapper.Map<TipoAbonoResult>(tipoAbono);
                    tipoAbonoResult.StatusCode = StatusCodes.Status200OK;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"TipoAbonoService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return tipoAbonoResult;
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="tipoAbonoModel"></param>
		/// <returns>Objeto TipoAbonoResult con información del resultado de la operación</returns>
		public TipoAbonoResult CrearTipoAbono(TipoAbonoRequest tipoAbonoRequest)
		{
			TipoAbonoResult tipoAbonoResult = new TipoAbonoResult();
            tipoAbonoResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {
				var tipoAbono = mapper.Map<TipoAbonoModel>(tipoAbonoRequest);
                tipoAbono = tipoAbonoRepository.CrearTipoAbono(tipoAbono);
                if (tipoAbono != null)
                {
                    tipoAbonoResult = mapper.Map<TipoAbonoResult>(tipoAbono);
                    tipoAbonoResult.StatusCode = StatusCodes.Status201Created;
                }
			}
			catch (Exception e)
            {
                logger.LogError($"TipoAbonoService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return tipoAbonoResult;
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="tipoAbonoModel"></param>
		/// <returns>Objeto TipoAbonoResult con información del resultado de la operación</returns>
		public TipoAbonoResult ActualizarTipoAbono(TipoAbonoRequest tipoAbonoRequest)
		{
			TipoAbonoResult tipoAbonoResult = new TipoAbonoResult();
            tipoAbonoResult.StatusCode = StatusCodes.Status202Accepted;
			try
			{
				var tipoAbono = mapper.Map<TipoAbonoModel>(tipoAbonoRequest);
                var result = tipoAbonoRepository.ActualizarTipoAbono(tipoAbono);
                if (result)
                {
                    tipoAbonoResult.StatusCode = StatusCodes.Status204NoContent;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"TipoAbonoService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return tipoAbonoResult;
		}
		
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="tipoAbonoModel"></param>
		/// <returns>Objeto TipoAbonoResult con información del resultado de la operación</returns>
		public TipoAbonoResult EliminarTipoAbono()
        {
			TipoAbonoResult tipoAbonoResult = new TipoAbonoResult();
            tipoAbonoResult.StatusCode = StatusCodes.Status202Accepted;
			try
			{
				var result = tipoAbonoRepository.EliminarTipoAbono();
                if (result)
                {
                    tipoAbonoResult.StatusCode = StatusCodes.Status204NoContent;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"TipoAbonoService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return tipoAbonoResult;
        }
	}
}

