using System;
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

        public string GenerateHtml(IEnumerable<ITitleUrlModel> data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            var htmlBuilder = new StringBuilder();
            htmlBuilder.AppendLine(HtmlGenerator.OpenList);

            foreach (var model in data)
            {
                htmlBuilder.AppendLine(string.Format(HtmlGenerator.ItemTemplate, model.Title, model.Url));
            }

            htmlBuilder.AppendLine(HtmlGenerator.CloseList);
            return htmlBuilder.ToString();
        }
    }
}
