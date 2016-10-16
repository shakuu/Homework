namespace JSONProcessingHW.Logic.FIleSystemProvider.Contracts
{
    public interface IFileWriter
    {
        void WriteToFile(string fileName, string content);
    }
}
