namespace XMLProcessingHW.ReadingXML.DirectoryStructureGenerator.Contracts
{
    public interface IDirectoryStructureGenerator
    {
        void GenerateDirectoryStructure(string rootDirectory, IDirectoryStructureLogger logger);
    }
}
