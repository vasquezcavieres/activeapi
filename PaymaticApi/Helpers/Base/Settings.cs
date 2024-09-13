using Cl.Intertrade.ActivPay.Helpers.Base;
using System;

namespace Cl.Intertrade.ActivPay.Helpers.Base
{
    public interface ISettingsConfig
    {
        public SendgridProfile SendgridProfile { get; set; }
        public MongoDatabaseProfile MongoDatabaseProfile { get; set; }
        public DapperProfile DapperProfile { get; set; }

        public AWSProfile AWSProfile { get; set; }

        public string UrlApi { get; set; }
        public string TokenProduccion { get; set; }
        public string RazonSocialFactura { get; set; }
        public string RutEmisorFactura { get; set; }
        public string GiroEmisorFactura { get; set; }
        public string CiudadOrigenFactura { get; set; }
        public string ComunaOrigenFactura { get; set; }
        public string DireccionOrigenFactura { get; set; }
        public string Acteco { get; set; }
    }


    public class SettingsConfig : ISettingsConfig
    {
        public MongoDatabaseProfile MongoDatabaseProfile { get; set; }
        public DapperProfile DapperProfile { get; set; }
        public RemoteConnectProfile RemoteConnectProfile { get; set; }
        public SendgridProfile SendgridProfile { get; set; }

        public AWSProfile AWSProfile { get; set; }

        public string UrlApi { get; set; }
        public string TokenProduccion { get; set; }
        public string RazonSocialFactura { get; set; }
        public string RutEmisorFactura { get; set; }
        public string GiroEmisorFactura { get; set; }
        public string CiudadOrigenFactura { get; set; }
        public string ComunaOrigenFactura { get; set; }
        public string DireccionOrigenFactura { get; set; }
        public string Acteco { get; set; }

    }

}
