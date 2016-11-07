using System.Collections.Generic;

namespace ExamPrep.Data.Utils.XmlDeserializers.Contracs
{
    public interface IXmlParser
    {
        IEnumerable<TModel> Deserialize<TModel>(string fileName, string rootElement);
    }
}