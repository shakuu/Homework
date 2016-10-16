using System;
using System.Xml;

using JSONProcessingHW.Logic.Parsers.Contracts;

using Newtonsoft.Json;

namespace JSONProcessingHW.Logic.Parsers
{
    public class XmlToJsonConverter : IXmlToJsonConverter
    {
        public string ConvertXmlToJson(XmlDocument xmlDocument)
        {
            if (xmlDocument == null)
            {
                throw new ArgumentNullException(nameof(xmlDocument));
            }

            var json = JsonConvert.SerializeXmlNode(xmlDocument);
            return json;
        }
    }
}
