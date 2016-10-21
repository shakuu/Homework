namespace ADONET.Homework.Logic.ConfigurationProviders.Contracts
{
    public interface IConfigurationProvider
    {
        string ReadConfiguration(string key);
    }
}
