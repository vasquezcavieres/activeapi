using Cl.Intertrade.ActivPay.Result.Factura;

namespace ActivPayApi.Models.Result.Factura
{
    public class FacturaFiltroResult
    {
        public int StatusCode { get; set; }
        public IList<Anio> Anios { get; set; }
    }

    public class Anio
    {
        public string NombreAnio { get; set; }
        public IList<Mes> Meses { get; set; }
    }

    public class Mes
    {
        public string NombreMes { get; set; }
        public List<FacturaResult> Facturas { get; set; }
    }
}
