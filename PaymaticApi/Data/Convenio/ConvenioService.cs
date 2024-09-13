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
using Cl.Intertrade.ActivPay.Entities.Convenio;
using Cl.Intertrade.ActivPay.Request.Convenio;
using Cl.Intertrade.ActivPay.Result.Convenio;
using Cl.Intertrade.ActivPay.Repository.Convenio;
using Cl.Intertrade.ActivPay.Repository.CicloTransferencia;
using Cl.Intertrade.ActivPay.Entities.CicloTransferencia;

namespace Cl.Intertrade.ActivPay.Data.Convenio
{
    /// <summary>
    /// Esta Clase Convenio  permite gestionar reglas de negocio asociados a la entidad Convenio
    /// </summary>
    public partial class ConvenioService : IConvenioService
    {
        private ISettingsConfig settings;
        private IConvenioRepository convenioRepository;
        private ICicloTransferenciaRepository cicloTransferenciaRepository;
        private ILogger<ConvenioService> logger;
        private IMapper mapper;
        public ConvenioService(IConvenioRepository convenioRepository, ISettingsConfig settings, ILogger<ConvenioService> logger, IMapper mapper, ICicloTransferenciaRepository cicloTransferenciaRepository)
        {
            this.convenioRepository = convenioRepository;
            this.mapper = mapper;
            this.settings = settings;
            this.logger = logger;
            this.cicloTransferenciaRepository = cicloTransferenciaRepository;
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <returns>Objeto ConvenioResult con información del resultado de la operación</returns>
		public ListadoConvenioResult ObtenerConvenios()
		{
			ListadoConvenioResult listadoConvenioResult = new ListadoConvenioResult();
            listadoConvenioResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
				var convenios = convenioRepository.ObtenerConvenios();
                listadoConvenioResult.Convenios = new List<ConvenioResult>();

                if (convenios != null)
                {
                    listadoConvenioResult.Convenios = mapper.Map<IList<ConvenioResult>>(convenios);
                    listadoConvenioResult.StatusCode = StatusCodes.Status200OK;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"ConvenioService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoConvenioResult;
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="rutRazonSocial"></param>
/// <returns>Objeto ConvenioResult con información del resultado de la operación</returns>
		public ListadoConvenioResult BuscarConvenios(int rutRazonSocial )
		{
			ListadoConvenioResult listadoConvenioResult = new ListadoConvenioResult();
            listadoConvenioResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
				var convenios = convenioRepository.BuscarConvenios(rutRazonSocial);
                listadoConvenioResult.Convenios = new List<ConvenioResult>();

                if (convenios != null)
                {
                    listadoConvenioResult.Convenios = mapper.Map<IList<ConvenioResult>>(convenios);
                    listadoConvenioResult.StatusCode = StatusCodes.Status200OK;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"ConvenioService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoConvenioResult;
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="rutRazonSocial"></param>
/// <returns>Objeto ConvenioResult con información del resultado de la operación</returns>
		public ConvenioResult ObtenerConvenio(int rutRazonSocial )
        {
			ConvenioResult convenioResult = new ConvenioResult();
            convenioResult.StatusCode = StatusCodes.Status202Accepted;
			try
			{
				var convenio = convenioRepository.ObtenerConvenio(rutRazonSocial);
                if (convenio!=null)
                {
                    convenioResult = mapper.Map<ConvenioResult>(convenio);
                    convenioResult.StatusCode = StatusCodes.Status200OK;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"ConvenioService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return convenioResult;
        }

        public ConvenioResult ObtenerConvenioPorEdificio(string codigoEdificio)
        {
            ConvenioResult convenioResult = new ConvenioResult();
            convenioResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {
                var convenio = convenioRepository.ObtenerConvenioPorEdificio(codigoEdificio);
                if (convenio != null)
                {
                    convenioResult = mapper.Map<ConvenioResult>(convenio);
                    convenioResult.StatusCode = StatusCodes.Status200OK;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"ConvenioService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return convenioResult;
        }

        public ConvenioResult ObtenerConvenioPorAdministrador(string rutAdministrador)
        {
            ConvenioResult convenioResult = new ConvenioResult();
            convenioResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {
                var convenio = convenioRepository.ObtenerConvenioPorAdministrador(Convert.ToInt32(rutAdministrador));
                if (convenio != null)
                {
                    convenioResult = mapper.Map<ConvenioResult>(convenio);
                    convenioResult.StatusCode = StatusCodes.Status200OK;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"ConvenioService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return convenioResult;
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="convenioModel"></param>
        /// <returns>Objeto ConvenioResult con información del resultado de la operación</returns>
        public ConvenioResult CrearConvenio(ConvenioRequest convenioRequest)
		{
			ConvenioResult convenioResult = new ConvenioResult();
            convenioResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {
				var convenio = mapper.Map<ConvenioModel>(convenioRequest);
                convenio.FechaCreacion = DateTime.Now;
                convenio = convenioRepository.CrearConvenio(convenio);
                if (convenio != null)
                {
                    //creamos cicloTransferencia
                    CicloTransferenciaModel cicloTransferenciaModel = new CicloTransferenciaModel();
                    cicloTransferenciaModel.CodigoConvenio = convenioRequest.RutRazonSocial;
                    cicloTransferenciaModel.CreadoPor = "ADMIN";
                    cicloTransferenciaModel.FechaCreacion = DateTime.Now;

                    cicloTransferenciaModel =  cicloTransferenciaRepository.CrearCicloTransferencia(cicloTransferenciaModel);

                    if (cicloTransferenciaRepository != null)
                    {
                        convenioResult = mapper.Map<ConvenioResult>(convenio);
                        convenioResult.StatusCode = StatusCodes.Status201Created;
                    }
                }
			}
			catch (Exception e)
            {
                logger.LogError($"ConvenioService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return convenioResult;
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="convenioModel"></param>
		/// <returns>Objeto ConvenioResult con información del resultado de la operación</returns>
		public ConvenioResult ActualizarConvenio(ConvenioRequest convenioRequest)
		{
			ConvenioResult convenioResult = new ConvenioResult();
            convenioResult.StatusCode = StatusCodes.Status202Accepted;
			try
			{
				var convenio = mapper.Map<ConvenioModel>(convenioRequest);
                var result = convenioRepository.ActualizarConvenio(convenio);
                if (result)
                {
                    convenioResult.StatusCode = StatusCodes.Status202Accepted;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"ConvenioService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return convenioResult;
		}

        public ConvenioResult AsociarUsuarioAdministradaor(ConvenioRequest convenioRequest)
        {
            ConvenioResult convenioResult = new ConvenioResult();
            convenioResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {
                var convenio = mapper.Map<ConvenioModel>(convenioRequest);
                var result = convenioRepository.AsociarUsuarioAdministradaor(convenio);
                if (result)
                {
                    convenioResult.StatusCode = StatusCodes.Status202Accepted;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"ConvenioService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return convenioResult;
        }

        /// <summary>
        /// Agrega un elemento desde el medio de persistencia
        /// </summary>
        /// <param name="convenioModel"></param>
        /// <returns>Objeto ConvenioResult con información del resultado de la operación</returns>
        public ConvenioResult EliminarConvenio(int rutRazonSocial )
        {
			ConvenioResult convenioResult = new ConvenioResult();
            convenioResult.StatusCode = StatusCodes.Status202Accepted;
			try
			{
				var result = convenioRepository.EliminarConvenio(rutRazonSocial);
                if (result)
                {
                    convenioResult.StatusCode = StatusCodes.Status204NoContent;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"ConvenioService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return convenioResult;
        }
	}
}

