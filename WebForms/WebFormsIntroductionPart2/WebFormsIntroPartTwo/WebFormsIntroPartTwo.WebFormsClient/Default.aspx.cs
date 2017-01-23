using System;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsIntroPartTwo.WebFormsClient
{
    public partial class _Default : Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            var label = new Label();
            label.Text = "1. OnPreInit";

            this.PrintPanel.Controls.Add(label);
        }

        protected override void OnInit(EventArgs e)
        {
            var label = new Label();
            label.Text = "2. OnInit";

            this.PrintPanel.Controls.Add(label);
        }

        protected override void OnInitComplete(EventArgs e)
        {
            var label = new Label();
            label.Text = "3. OnInitComplete";

            this.PrintPanel.Controls.Add(label);
        }

        protected override void OnPreLoad(EventArgs e)
        {
            var label = new Label();
            label.Text = "4. OnPreLoad";

            this.PrintPanel.Controls.Add(label);
        }

        protected override void OnLoad(EventArgs e)
        {
            var label = new Label();
            label.Text = "5. OnLoad";

            this.PrintPanel.Controls.Add(label);
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            var label = new Label();
            label.Text = "6. OnLoadComplete";

            this.PrintPanel.Controls.Add(label);
        }

        protected override void OnPreRender(EventArgs e)
        {
            var label = new Label();
            label.Text = "7. OnPreRender";

            this.PrintPanel.Controls.Add(label);
        }

        protected override void OnPreRenderComplete(EventArgs e)
        {
            var label = new Label();
            label.Text = "8. OnPreRenderComplete";

            this.PrintPanel.Controls.Add(label);
        }

        protected override void OnSaveStateComplete(EventArgs e)
        {
            var label = new Label();
            label.Text = "9. OnSaveStateComplete";

            this.PrintPanel.Controls.Add(label);
        }

        protected override void OnUnload(EventArgs e)
        {
            // no OnRender ? 
            // Too Late to print inside OnUnload
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ExecutingAssembly.Text = $"Executing assembly location: {Assembly.GetExecutingAssembly().Location}";
        }

        protected void ButtonPrintName_Click(object sender, EventArgs e)
        {
            this.NameLabel.Text = string.Format($"Hello {this.Name.Text}!");
        }
    }
}