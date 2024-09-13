






/**
* (c)2013-2023 CodeBase Todos los Derechos Reservados.
*
* El uso de este programa y/o la documentación asociada, ya sea en forma
* de fuentes o archivos binarios, con o sin modificaciones,
* esta sujeto a la licencia descrita en LICENCIA.TXT.
**/


/*
	*14-11-2023,Generador de Código, Clase Inicial 
*/


using AutoMapper;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Http;
using Cl.Intertrade.ActivPayApi.Entities.ArchivoPagoProveedores;
using Cl.Intertrade.ActivPayApi.Request.ArchivoPagoProveedores;
using Cl.Intertrade.ActivPayApi.Result.ArchivoPagoProveedores;
using Cl.Intertrade.ActivPayApi.Repository.ArchivoPagoProveedores;
using Cl.Intertrade.ActivPay.Helpers.Base;

namespace Cl.Intertrade.ActivPayApi.Data.ArchivoPagoProveedores
{
	/// <summary>
	/// Esta Clase ArchivoPagoProveedores  permite gestionar reglas de negocio asociados a la entidad ArchivoPagoProveedores
	/// </summary>
	public partial class ArchivoPagoProveedoresService : IArchivoPagoProveedoresService
	{	
        private ISettingsConfig settings;
        private IArchivoPagoProveedoresRepository archivoPagoProveedoresRepository;
        private ILogger<ArchivoPagoProveedoresService> logger;
        private IMapper mapper;
        public ArchivoPagoProveedoresService(IArchivoPagoProveedoresRepository archivoPagoProveedoresRepository, ISettingsConfig settings, ILogger<ArchivoPagoProveedoresService> logger, IMapper mapper)
        {
            this.archivoPagoProveedoresRepository = archivoPagoProveedoresRepository;
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
		/// <returns>Objeto ArchivoPagoProveedoresResult con información del resultado de la operación</returns>
		public ListadoArchivoPagoProveedoresResult ObtenerArchivoPagoProveedoress()
		{
			ListadoArchivoPagoProveedoresResult listadoArchivoPagoProveedoresResult = new ListadoArchivoPagoProveedoresResult();
            listadoArchivoPagoProveedoresResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
				var archivoPagoProveedoress = archivoPagoProveedoresRepository.ObtenerArchivoPagoProveedoress();
                listadoArchivoPagoProveedoresResult.ArchivoPagoProveedoress = new List<ArchivoPagoProveedoresResult>();

                if (archivoPagoProveedoress != null)
                {
                    listadoArchivoPagoProveedoresResult.ArchivoPagoProveedoress = mapper.Map<IList<ArchivoPagoProveedoresResult>>(archivoPagoProveedoress);
                    listadoArchivoPagoProveedoresResult.StatusCode = StatusCodes.Status200OK;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"ArchivoPagoProveedoresService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoArchivoPagoProveedoresResult;
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <returns>Objeto ArchivoPagoProveedoresResult con información del resultado de la operación</returns>
		public ListadoArchivoPagoProveedoresResult BuscarArchivoPagoProveedoress()
		{
			ListadoArchivoPagoProveedoresResult listadoArchivoPagoProveedoresResult = new ListadoArchivoPagoProveedoresResult();
            listadoArchivoPagoProveedoresResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
				var archivoPagoProveedoress = archivoPagoProveedoresRepository.BuscarArchivoPagoProveedoress();
                listadoArchivoPagoProveedoresResult.ArchivoPagoProveedoress = new List<ArchivoPagoProveedoresResult>();

                if (archivoPagoProveedoress != null)
                {
                    listadoArchivoPagoProveedoresResult.ArchivoPagoProveedoress = mapper.Map<IList<ArchivoPagoProveedoresResult>>(archivoPagoProveedoress);
                    listadoArchivoPagoProveedoresResult.StatusCode = StatusCodes.Status200OK;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"ArchivoPagoProveedoresService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoArchivoPagoProveedoresResult;
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <returns>Objeto ArchivoPagoProveedoresResult con información del resultado de la operación</returns>
		public ArchivoPagoProveedoresResult ObtenerArchivoPagoProveedores(int numeroArchivo)
        {
			ArchivoPagoProveedoresResult archivoPagoProveedoresResult = new ArchivoPagoProveedoresResult();
            archivoPagoProveedoresResult.StatusCode = StatusCodes.Status202Accepted;
			try
			{
				var archivoPagoProveedores = archivoPagoProveedoresRepository.ObtenerArchivoPagoProveedores(numeroArchivo);
                if (archivoPagoProveedores!=null)
                {
                    archivoPagoProveedoresResult = mapper.Map<ArchivoPagoProveedoresResult>(archivoPagoProveedores);
                    archivoPagoProveedoresResult.StatusCode = StatusCodes.Status200OK;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"ArchivoPagoProveedoresService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return archivoPagoProveedoresResult;
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="archivoPagoProveedoresModel"></param>
		/// <returns>Objeto ArchivoPagoProveedoresResult con información del resultado de la operación</returns>
		public ArchivoPagoProveedoresResult CrearArchivoPagoProveedores(ArchivoPagoProveedoresRequest archivoPagoProveedoresRequest)
		{
			ArchivoPagoProveedoresResult archivoPagoProveedoresResult = new ArchivoPagoProveedoresResult();
            archivoPagoProveedoresResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {
				var archivoPagoProveedores = mapper.Map<ArchivoPagoProveedoresModel>(archivoPagoProveedoresRequest);
                archivoPagoProveedores = archivoPagoProveedoresRepository.CrearArchivoPagoProveedores(archivoPagoProveedores);
                if (archivoPagoProveedores != null)
                {
                    archivoPagoProveedoresResult = mapper.Map<ArchivoPagoProveedoresResult>(archivoPagoProveedores);
                    archivoPagoProveedoresResult.StatusCode = StatusCodes.Status201Created;
                }
			}
			catch (Exception e)
            {
                logger.LogError($"ArchivoPagoProveedoresService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return archivoPagoProveedoresResult;
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="archivoPagoProveedoresModel"></param>
		/// <returns>Objeto ArchivoPagoProveedoresResult con información del resultado de la operación</returns>
		public ArchivoPagoProveedoresResult ActualizarArchivoPagoProveedores(ArchivoPagoProveedoresRequest archivoPagoProveedoresRequest)
		{
			ArchivoPagoProveedoresResult archivoPagoProveedoresResult = new ArchivoPagoProveedoresResult();
            archivoPagoProveedoresResult.StatusCode = StatusCodes.Status202Accepted;
			try
			{
				var archivoPagoProveedores = mapper.Map<ArchivoPagoProveedoresModel>(archivoPagoProveedoresRequest);
                var result = archivoPagoProveedoresRepository.ActualizarArchivoPagoProveedores(archivoPagoProveedores);
                if (result)
                {
                    archivoPagoProveedoresResult.StatusCode = StatusCodes.Status204NoContent;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"ArchivoPagoProveedoresService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return archivoPagoProveedoresResult;
		}
		
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="archivoPagoProveedoresModel"></param>
		/// <returns>Objeto ArchivoPagoProveedoresResult con información del resultado de la operación</returns>
		public ArchivoPagoProveedoresResult EliminarArchivoPagoProveedores()
        {
			ArchivoPagoProveedoresResult archivoPagoProveedoresResult = new ArchivoPagoProveedoresResult();
            archivoPagoProveedoresResult.StatusCode = StatusCodes.Status202Accepted;
			try
			{
				var result = archivoPagoProveedoresRepository.EliminarArchivoPagoProveedores();
                if (result)
                {
                    archivoPagoProveedoresResult.StatusCode = StatusCodes.Status204NoContent;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"ArchivoPagoProveedoresService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return archivoPagoProveedoresResult;
        }
	}
}

