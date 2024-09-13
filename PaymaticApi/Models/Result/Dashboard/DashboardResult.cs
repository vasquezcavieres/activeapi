using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Cl.Intertrade.ActivPayApi.Models.Result.Dashboard
{
    public class DashboardResult
    {
        [JsonPropertyName("ventasTotales")]
        public decimal VentasTotales { get; set; }
        [JsonPropertyName("comisiones")]
        public decimal Comisiones { get; set; }
        [JsonPropertyName("montosTransferir")]
        public decimal MontosTransferir { get; set; }

        [JsonPropertyName("statusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("fechaDesde")]
        public DateTime? FechaDesde { get; set; }

        [JsonPropertyName("fechaHasta")]
        public DateTime? FechaHasta { get; set; }
    }
}
