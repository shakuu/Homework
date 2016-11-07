using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

using ExamPrep.Data.Utils.XmlDeserializers.Contracs;

namespace ExamPrep.Data.Utils.XmlDeserializers
{
    public class XmlParser : IXmlParser
    {
        public IEnumerable<TModel> Deserialize<TModel>(string fileName, string rootElement)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("File not found!", fileName);
            }

            var serializer = new XmlSerializer(typeof(List<TModel>), new XmlRootAttribute(rootElement));
            IEnumerable<TModel> result;
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                result = (IEnumerable<TModel>)serializer.Deserialize(fs);
            }

            return result;
        }
    }
}
