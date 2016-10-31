using System.Collections.Generic;

namespace SocialNetwork.ConsoleClient.XmlDeserializers.Contracts
{
    public interface IXmlDeserializer
    {
        IEnumerable<TModel> DeserializeTo<TModel>(string fileName, string rootElement);
    }
}
