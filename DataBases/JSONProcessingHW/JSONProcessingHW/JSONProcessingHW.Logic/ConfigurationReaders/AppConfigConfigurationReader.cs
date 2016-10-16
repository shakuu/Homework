using System;
using System.Configuration;

using JSONProcessingHW.Logic.ConfigurationReaders.Contracts;

namespace JSONProcessingHW.Logic.ConfigurationReaders
{
    public class AppConfigConfigurationReader : IConfigurationReader
    {
        public string ReadConfiguration(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            var configValue = ConfigurationManager.AppSettings[key];
            if (configValue == null)
            {
                throw new ArgumentException($"{key} was not found.");
            }

            return configValue;
        }
    }
}
