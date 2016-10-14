using System.Collections.Generic;

namespace XMLProcessingHW.XMLWritingLogic.Contracts
{
    public interface IXmlContentGenerator
    {
        IEnumerable<IXmlContent> GeneratedContent { get; }
    }
}
