using System;

namespace XMLProcessingHW.ReadingXML.DirectoryStructureGenerators.Contracts
{
    public interface IDirectoryStructureLogger : IDisposable
    {
        void EndScope();

        void LogElement(string elementName, string elementText, bool isNewScope = false);
    }
}
