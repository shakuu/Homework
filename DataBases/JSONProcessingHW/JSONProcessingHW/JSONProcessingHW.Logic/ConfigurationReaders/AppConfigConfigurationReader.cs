using System.Configuration;

namespace JSONProcessingHW.Logic.ConfigurationReaders
{
    public class AppConfigConfigurationReader
    {
        public string ReaderConfiguration(string key)
        {
            var configValue = ConfigurationManager.AppSettings[key];
            return configValue;
        }
    }
}
