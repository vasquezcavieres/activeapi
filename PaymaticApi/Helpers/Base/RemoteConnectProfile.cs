
namespace Cl.Intertrade.ActivPay.Helpers.Base
{
    public class RemoteConnectProfile : IRemoteConnectProfile
    {
        public string UrlDriver { get; set; }
        public string UrlJimpisoft { get; set; }
        public string UrlPromotions { get; set; }
        public string UrlClub { get; set; }
        public JimpisoftConfiguration JimpisoftConfiguration { get; set; }
    }

    public interface IRemoteConnectProfile
    {
        string UrlDriver { get; set; }
        string UrlJimpisoft { get; set; }
        string UrlPromotions { get; set; }
        string UrlClub { get; set; }
        JimpisoftConfiguration JimpisoftConfiguration { get; set; }
    }

    public class JimpisoftConfiguration
    {
        public string Username { get; set;}
        public string Password { get; set; }
    }
}
