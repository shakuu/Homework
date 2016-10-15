namespace JSONProcessingHW.Logic.ConfigurationReaders.Contracts
{
    public interface IConfigurationReader
    {
        string ReadConfiguration(string key);
    }
}
