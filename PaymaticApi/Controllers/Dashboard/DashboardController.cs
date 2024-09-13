using Cl.Intertrade.ActivPay.Controllers.Base;
using Cl.Intertrade.ActivPay.Controllers.Edificio;
using Cl.Intertrade.ActivPay.Data.Edificio;
using Cl.Intertrade.ActivPay.Helpers.Base;
using Cl.Intertrade.ActivPay.ActivPayApi.Data.Dashboard;
using Cl.Intertrade.ActivPayApi.Models.Request.Dashboard;
using Cl.Intertrade.ActivPayApi.Models.Result.Dashboard;
using Microsoft.AspNetCore.Mvc;

namespace Cl.Intertrade.ActivPayApi.Controllers.Dashboard
{

    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : BaseController<DashboardController>
    {
        IDashboardService dashboardService;
        public DashboardController(ILogger<DashboardController> logger, IWebHostEnvironment environment, ISettingsConfig settings, IDashboardService dashboardService)
        {
            this.logger = logger;
            this.environment = environment;
            this.settings = settings;
            this.dashboardService = dashboardService;
        }

        [HttpPost("v1/dashboard")]
        public ActionResult GetDashboard(DashboardRequest dashboardRequest)
        {
            DashboardResult result = new DashboardResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.dashboardService.ObtieneDashboard(dashboardRequest);
            }
            catch (Exception e)
            {
                logger.LogError($"Error DashboardController.GetDashboard {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("v1/dashboardNoFacturado")]
        public ActionResult GetDashboardNoFacturado(DashboardRequest dashboardRequest)
        {
            DashboardResult result = new DashboardResult() { StatusCode = StatusCodes.Status204NoContent };
            try
            {
                result = this.dashboardService.BuscarDashboardNoFacturado(dashboardRequest);
            }
            catch (Exception e)
            {
                logger.LogError($"Error DashboardController.GetDashboard {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(result.StatusCode, result);
        }
    }
}
