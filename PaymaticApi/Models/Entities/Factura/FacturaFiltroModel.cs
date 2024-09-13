using Cl.Intertrade.ActivPay.Entities.Factura;

namespace ActivPayApi.Models.Entities.Factura
{
    public class FacturaFiltroModel
    {
        public IList<Anio> Anios { get; set; }
    }

    public class Anio 
    {
        public string NombreAnio { get; set; }
        public IList<Mes> Meses { get; set; }        
    }

    public class Mes
    {
        string NombreMes { get; set; }
        public IList<FacturaModel> Facturas { get; set; }
    }
}
