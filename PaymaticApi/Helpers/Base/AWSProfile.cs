namespace Cl.Intertrade.ActivPay.Helpers.Base
{
    public interface IAWSProfile
    {
        string AccessKey { get; set; }
        string BucketName { get; set; }
        string PublicUrl { get; set; }
        string SecretKey { get; set; }
    }

    public class AWSProfile : IAWSProfile
    {
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string BucketName { get; set; }
        public string PublicUrl { get; set; }
    }
}
