
namespace Cl.Intertrade.ActivPay.Helpers.Base
{
    public class MongoDatabaseProfile : IMongoDatabaseProfile
    {
        public string CollectionName { get; set; }
        public string CollectionAcceso { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IMongoDatabaseProfile
    {
        string CollectionName { get; set; }
        string CollectionAcceso { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
