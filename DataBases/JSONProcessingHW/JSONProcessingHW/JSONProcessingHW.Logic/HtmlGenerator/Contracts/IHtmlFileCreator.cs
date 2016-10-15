namespace JSONProcessingHW.Logic.HtmlGenerator.Contracts
{
    public interface IHtmlFileCreator
    {
        void CreateHtmlFile(string fileName, string title, string content);
    }
}
