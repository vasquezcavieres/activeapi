using Cl.Intertrade.ActivPayApi.Models.Request.Dashboard;
using Cl.Intertrade.ActivPayApi.Models.Result.Dashboard;

namespace Cl.Intertrade.ActivPay.ActivPayApi.Data.Dashboard
{
    public interface IDashboardService
    {
        DashboardResult ObtieneDashboard(DashboardRequest dashboardRequest);
        DashboardResult BuscarDashboardNoFacturado(DashboardRequest dashboardRequest);
    }
}