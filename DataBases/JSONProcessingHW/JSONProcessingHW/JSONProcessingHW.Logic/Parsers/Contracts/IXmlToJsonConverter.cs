using System.Xml;

namespace JSONProcessingHW.Logic.Parsers.Contracts
{
    public interface IXmlToJsonConverter
    {
        string ConvertXmlToJson(XmlDocument xmlDocument);
    }
}
