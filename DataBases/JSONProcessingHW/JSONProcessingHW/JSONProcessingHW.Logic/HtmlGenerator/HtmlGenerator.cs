using System.Collections.Generic;
using System.Text;

using JSONProcessingHW.Logic.HtmlGenerator.Contracts;
using JSONProcessingHW.Logic.Models.Contracts;

namespace JSONProcessingHW.Logic.HtmlGenerator
{
    public class HtmlGenerator : IHtmlGenerator
    {
        private const string OpenList = "<ul>";
        private const string CloseList = "</ul>";
        private const string ItemTemplate = "<li><a href=\"{1}\">{0}</a></li>";

        public string GenerateHtml(IEnumerable<IModel> data)
        {
            var html = new StringBuilder();
            html.AppendLine(HtmlGenerator.OpenList);

            foreach (var model in data)
            {
                html.AppendLine(string.Format(HtmlGenerator.ItemTemplate, model.Title, model.Url));
            }

            html.AppendLine(HtmlGenerator.CloseList);
            return html.ToString();
        }
    }
}
