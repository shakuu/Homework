using JSONProcessingHW.Logic.Models.Contracts;

namespace JSONProcessingHW.Logic
{
    public interface IDataParser
    {
        void CreateHtml<ModelType>(string inputXmlFile, string outputHtmlFile)
            where ModelType : ITitleUrlModel, new();
    }
}
