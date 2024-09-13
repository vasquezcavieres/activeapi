
namespace Cl.Intertrade.ActivPay.Helpers.Base
{
    public class DapperProfile : IDapperProfile
    {
        public string ConnectionString { get; set; }
    }

    public interface IDapperProfile
    {
        string ConnectionString { get; set; }
    }
}
