using Newtonsoft.Json;

namespace ActivPayApi.Models.Entities.ParidadMonetaria
{
    public class ParidadMonetariaModel
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("autor")]
        public string Autor { get; set; }

        [JsonProperty("fecha")]
        public DateTime Fecha { get; set; }

        [JsonProperty("uf")]
        public Tipo Uf { get; set; }

        [JsonProperty("ivp")]
        public Tipo Ivp { get; set; }

        [JsonProperty("dolar")]
        public Tipo Dolar { get; set; }

        [JsonProperty("dolar_intercambio")]
        public Tipo DolarIntercambio { get; set; }

        [JsonProperty("euro")]
        public Tipo Euro { get; set; }

        [JsonProperty("ipc")]
        public Tipo Ipc { get; set; }

        [JsonProperty("utm")]
        public Tipo Utm { get; set; }

        [JsonProperty("imacec")]
        public Tipo Imacec { get; set; }

        [JsonProperty("tpm")]
        public Tipo Tpm { get; set; }

        [JsonProperty("libra_cobre")]
        public Tipo LibraCobre { get; set; }

        [JsonProperty("tasa_desempleo")]
        public Tipo TasaDesempleo { get; set; }

        [JsonProperty("bitcoin")]
        public Tipo Bitcoin { get; set; }
    }

    public partial class Tipo
    {
        [JsonProperty("codigo")]
        public string Codigo { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("unidad_medida")]
        public string UnidadMedida { get; set; }

        [JsonProperty("fecha")]
        public DateTime Fecha { get; set; }

        [JsonProperty("valor")]
        public double Valor { get; set; }
    }


}