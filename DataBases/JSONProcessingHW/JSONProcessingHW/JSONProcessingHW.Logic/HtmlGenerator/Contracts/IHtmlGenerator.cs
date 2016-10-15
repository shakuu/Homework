using System.Collections.Generic;

using JSONProcessingHW.Logic.Models.Contracts;

namespace JSONProcessingHW.Logic.HtmlGenerator.Contracts
{
    public interface IHtmlGenerator
    {
        string GenerateHtml(IEnumerable<IModel> data);
    }
}
