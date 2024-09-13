using AutoMapper;
using Cl.Intertrade.ActivPay.Entities.Transferencia;
using Cl.Intertrade.ActivPay.Helpers.Base;
using Cl.Intertrade.ActivPay.Repository.Convenio;
using Cl.Intertrade.ActivPay.Repository.Pago;
using Cl.Intertrade.ActivPay.Repository.Transferencia;
using Cl.Intertrade.ActivPayApi.Models.Request.Dashboard;
using Cl.Intertrade.ActivPayApi.Models.Result.Dashboard;

namespace Cl.Intertrade.ActivPay.ActivPayApi.Data.Dashboard
{
    public class DashboardService : IDashboardService
    {
        private ISettingsConfig settings;
        private ILogger<DashboardService> logger;
        private IMapper mapper;
        private IPagoRepository pagoRepository;
        private ITransferenciaRepository transferenciaRepository;
        private IConvenioRepository convenioRepository;

        public DashboardService(ISettingsConfig settings, ILogger<DashboardService> logger, IMapper mapper, IPagoRepository pagoRepository, ITransferenciaRepository transferenciaRepository, IConvenioRepository convenioRepository)
        {
            this.mapper = mapper;
            this.settings = settings;
            this.logger = logger;
            this.pagoRepository = pagoRepository;
            this.transferenciaRepository = transferenciaRepository;
            this.convenioRepository = convenioRepository;
        }

        public DashboardResult ObtieneDashboard(DashboardRequest dashboardRequest)
        {
            var result = new DashboardResult() { StatusCode = StatusCodes.Status400BadRequest };

            try
            {
                var pagos = pagoRepository.BuscarDashboard(dashboardRequest);
                var transferenciaModel = new TransferenciaModel();
                transferenciaModel.FechaDesde = dashboardRequest.FechaDesde;
                transferenciaModel.FechaHasta = dashboardRequest.FechaDesde;
                var UF_AL_DIA = 36529.83M;

                if (pagos != null)
                {
                    foreach (var unPago in pagos)
                    {
                        var convenio = convenioRepository.ObtenerConvenio(Convert.ToInt32(unPago.CodigoConvenio));
                        var minimoGarantizado = unPago.MaquinasInstaladas * (UF_AL_DIA * 0.25M);
                        result.VentasTotales += unPago.MontoPago;
                        //result.Comisiones += (unPago.MontoPago * convenio.PorcentajeComision) > minimoGarantizado ? (unPago.MontoPago * convenio.PorcentajeComision) : minimoGarantizado;

                    }
                    result.MontosTransferir = result.VentasTotales - result.Comisiones;
                    result.StatusCode = StatusCodes.Status200OK;
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Problemas al ObtenerDashboard , Error : {ex.Message}");

                throw ex;
            }

            return result;
        }


        public DashboardResult BuscarDashboardNoFacturado(DashboardRequest dashboardRequest)
        {
            var result = new DashboardResult() { StatusCode = StatusCodes.Status400BadRequest };

            try
            {
                var convenio = convenioRepository.ObtenerConvenio(dashboardRequest.CodigoConvenio);
                var pagos = pagoRepository.BuscarDashboardNoFacturado(dashboardRequest);
                var UF_AL_DIA = 36529.83M;

                if (pagos != null)
                {
                    foreach (var unPago in pagos)
                    {
                        var minimoGarantizado = 0;// unPago.MaquinasInstaladas * (UF_AL_DIA * 0.25M);
                        result.VentasTotales += unPago.MontoPago;
                        result.Comisiones += (unPago.MontoPago * convenio.PorcentajeComision) > minimoGarantizado ? (unPago.MontoPago * convenio.PorcentajeComision) : minimoGarantizado;
                        
                    }
                    result.MontosTransferir = result.VentasTotales - result.Comisiones;
                    result.StatusCode = StatusCodes.Status200OK;
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Problemas al ObtenerDashboard , Error : {ex.Message}");

                throw ex;
            }

            return result;
        }
    }
}
