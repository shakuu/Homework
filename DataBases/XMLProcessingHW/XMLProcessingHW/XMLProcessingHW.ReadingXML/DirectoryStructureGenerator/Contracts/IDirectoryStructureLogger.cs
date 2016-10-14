namespace XMLProcessingHW.ReadingXML.DirectoryStructureGenerator.Contracts
{
    public interface IDirectoryStructureLogger
    {
        void EndScope();

        void LogElement(string elementName, string elementText, bool isNewScope = false);
    }
}
