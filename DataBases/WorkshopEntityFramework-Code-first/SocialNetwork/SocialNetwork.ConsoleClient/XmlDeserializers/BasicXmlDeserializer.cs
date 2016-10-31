using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

using SocialNetwork.ConsoleClient.XmlDeserializers.Contracts;

namespace SocialNetwork.ConsoleClient.XmlDeserializers
{
    public class BasicXmlDeserializer : IXmlDeserializer
    {
        public IEnumerable<TModel> DeserializeTo<TModel>(string fileName, string rootElement)
        {
            var rootAttribute = new XmlRootAttribute(rootElement);
            var serializer = new XmlSerializer(typeof(List<TModel>), rootAttribute);

            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                var result = (IEnumerable<TModel>)serializer.Deserialize(fs);
                return result;
            }
        }
    }
}
