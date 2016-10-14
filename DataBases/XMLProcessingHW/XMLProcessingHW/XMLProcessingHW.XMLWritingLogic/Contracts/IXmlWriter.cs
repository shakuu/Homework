using System.Collections.Generic;

namespace XMLProcessingHW.XMLWritingLogic.Contracts
{
    public interface IXmlWriter
    {
        void WriteToFile(string fileName, IEnumerable<IXmlContent> contentToWrite);
    }
}
