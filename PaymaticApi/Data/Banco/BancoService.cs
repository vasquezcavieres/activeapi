






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
using Cl.Intertrade.ActivPay.Entities.Banco;
using Cl.Intertrade.ActivPay.Request.Banco;
using Cl.Intertrade.ActivPay.Result.Banco;
using Cl.Intertrade.ActivPay.Repository.Banco;

namespace Cl.Intertrade.ActivPay.Data.Banco
{
	/// <summary>
	/// Esta Clase Banco  permite gestionar reglas de negocio asociados a la entidad Banco
	/// </summary>
	public partial class BancoService : IBancoService
	{	
        private ISettingsConfig settings;
        private IBancoRepository bancoRepository;
        private ILogger<BancoService> logger;
        private IMapper mapper;
        public BancoService(IBancoRepository bancoRepository, ISettingsConfig settings, ILogger<BancoService> logger, IMapper mapper)
        {
            this.bancoRepository = bancoRepository;
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
		/// <returns>Objeto BancoResult con información del resultado de la operación</returns>
		public ListadoBancoResult ObtenerBancos()
		{
			ListadoBancoResult listadoBancoResult = new ListadoBancoResult();
            listadoBancoResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
				var bancos = bancoRepository.ObtenerBancos();
                listadoBancoResult.Bancos = new List<BancoResult>();

                if (bancos != null)
                {
                    listadoBancoResult.Bancos = mapper.Map<IList<BancoResult>>(bancos);
                    listadoBancoResult.StatusCode = StatusCodes.Status200OK;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"BancoService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoBancoResult;
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <returns>Objeto BancoResult con información del resultado de la operación</returns>
		public ListadoBancoResult BuscarBancos()
		{
			ListadoBancoResult listadoBancoResult = new ListadoBancoResult();
            listadoBancoResult.StatusCode = StatusCodes.Status204NoContent;
            try
            {
				var bancos = bancoRepository.BuscarBancos();
                listadoBancoResult.Bancos = new List<BancoResult>();

                if (bancos != null)
                {
                    listadoBancoResult.Bancos = mapper.Map<IList<BancoResult>>(bancos);
                    listadoBancoResult.StatusCode = StatusCodes.Status200OK;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"BancoService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return listadoBancoResult;
		}

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <returns>Objeto BancoResult con información del resultado de la operación</returns>
		public BancoResult ObtenerBanco()
        {
			BancoResult bancoResult = new BancoResult();
            bancoResult.StatusCode = StatusCodes.Status202Accepted;
			try
			{
				var banco = bancoRepository.ObtenerBanco("");
                if (banco!=null)
                {
                    bancoResult = mapper.Map<BancoResult>(banco);
                    bancoResult.StatusCode = StatusCodes.Status200OK;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"BancoService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return bancoResult;
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="bancoModel"></param>
		/// <returns>Objeto BancoResult con información del resultado de la operación</returns>
		public BancoResult CrearBanco(BancoRequest bancoRequest)
		{
			BancoResult bancoResult = new BancoResult();
            bancoResult.StatusCode = StatusCodes.Status202Accepted;
            try
            {
				var banco = mapper.Map<BancoModel>(bancoRequest);
                banco = bancoRepository.CrearBanco(banco);
                if (banco != null)
                {
                    bancoResult = mapper.Map<BancoResult>(banco);
                    bancoResult.StatusCode = StatusCodes.Status201Created;
                }
			}
			catch (Exception e)
            {
                logger.LogError($"BancoService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return bancoResult;
        }

		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="bancoModel"></param>
		/// <returns>Objeto BancoResult con información del resultado de la operación</returns>
		public BancoResult ActualizarBanco(BancoRequest bancoRequest)
		{
			BancoResult bancoResult = new BancoResult();
            bancoResult.StatusCode = StatusCodes.Status202Accepted;
			try
			{
				var banco = mapper.Map<BancoModel>(bancoRequest);
                var result = bancoRepository.ActualizarBanco(banco);
                if (result)
                {
                    bancoResult.StatusCode = StatusCodes.Status204NoContent;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"BancoService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return bancoResult;
		}
		
		/// <summary>
		/// Agrega un elemento desde el medio de persistencia
		/// </summary>
		/// <param name="bancoModel"></param>
		/// <returns>Objeto BancoResult con información del resultado de la operación</returns>
		public BancoResult EliminarBanco()
        {
			BancoResult bancoResult = new BancoResult();
            bancoResult.StatusCode = StatusCodes.Status202Accepted;
			try
			{
				var result = bancoRepository.EliminarBanco();
                if (result)
                {
                    bancoResult.StatusCode = StatusCodes.Status204NoContent;
                }
			}
            catch (Exception e)
            {
                logger.LogError($"BancoService: {e.Message}, {e.StackTrace}");
                throw;
            }
            return bancoResult;
        }
	}
}

