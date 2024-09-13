using System.Security.Authentication;

namespace Cl.Intertrade.ActivPay.Helpers.Base
{
    public class DBBaseHelper : BaseHelper
    {
        protected ISettingsConfig settingsConfig = null;

        public DBBaseHelper(ISettingsConfig settingsConfig)
        {
            this.settingsConfig = settingsConfig;
        }

        public IDapperProfile GetDBConnectionInfo()
        {
            return settingsConfig.DapperProfile;
        }

        public string GetDatabase()
        {
            return GetDBConnectionInfo().ConnectionString;
        }


    }
}