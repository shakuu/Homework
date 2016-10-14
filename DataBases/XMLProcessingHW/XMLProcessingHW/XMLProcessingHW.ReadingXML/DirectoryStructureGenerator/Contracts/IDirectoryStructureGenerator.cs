namespace XMLProcessingHW.ReadingXML.DirectoryStructureGenerators.Contracts
{
    public interface IDirectoryStructureGenerator
    {
        void GenerateDirectoryStructure(string rootDirectory, IDirectoryStructureLogger logger);
    }
}
