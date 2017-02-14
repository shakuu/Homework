using System;
using System.Collections.Generic;

using UserControls.WebClient.Models;

namespace UserControls.WebClient.UserControls
{
    public partial class LinksUserControl : System.Web.UI.UserControl
    {
        public string FontColor { get; set; }

        public string FontFace { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.FontColor))
            {
                this.FontColor = "black";
            }

            if (string.IsNullOrEmpty(this.FontFace))
            {
                this.FontFace = " 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif";
            }

            var links = new List<LinkItem>()
            {
                new LinkItem("https://www.progress.com/", "The Good"),
                new LinkItem("https://telerikacademy.com/", "The Bad"),
                new LinkItem("http://bgcoder.com/", "The Fugly")
            };

            this.LinksDataList.DataSource = links;
            this.LinksDataList.DataBind();
        }
    }
}