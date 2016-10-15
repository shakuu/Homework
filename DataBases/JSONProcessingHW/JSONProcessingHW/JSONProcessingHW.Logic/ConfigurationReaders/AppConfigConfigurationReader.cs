using System.Configuration;

using JSONProcessingHW.Logic.ConfigurationReaders.Contracts;

namespace JSONProcessingHW.Logic.ConfigurationReaders
{
    public class AppConfigConfigurationReader : IConfigurationReader
    {
        public string ReadConfiguration(string key)
        {
            var configValue = ConfigurationManager.AppSettings[key];
            return configValue;
        }
    }
}
