using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsIntroPartTwo.WebFormsClient
{
    public partial class _Default : Page
    {
        private LinkedList<ListItem> labels = new LinkedList<ListItem>();

        protected override void OnPreInit(EventArgs e)
        {
            var label = new ListItem();
            label.Text = "1. OnPreInit";

            this.labels.AddLast(label);
        }

        protected override void OnInit(EventArgs e)
        {
            var label = new ListItem();
            label.Text = "2. OnInit";

            this.labels.AddLast(label);
        }

        protected override void OnInitComplete(EventArgs e)
        {
            var label = new ListItem();
            label.Text = "3. OnInitComplete";

            this.labels.AddLast(label);
        }

        protected override void OnPreLoad(EventArgs e)
        {
            var label = new ListItem();
            label.Text = "4. OnPreLoad";

            this.labels.AddLast(label);
        }

        protected override void OnLoad(EventArgs e)
        {
            var label = new ListItem();
            label.Text = "5. OnLoad";

            this.labels.AddLast(label);
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            var label = new ListItem();
            label.Text = "6. OnLoadComplete";

            this.labels.AddLast(label);
        }

        protected override void OnPreRender(EventArgs e)
        {
            var label = new ListItem();
            label.Text = "7. OnPreRender";

            this.labels.AddLast(label);
        }

        protected override void OnPreRenderComplete(EventArgs e)
        {
            var label = new ListItem();
            label.Text = "8. OnPreRenderComplete";

            this.labels.AddLast(label);
        }

        protected override void OnSaveStateComplete(EventArgs e)
        {
            var label = new ListItem();
            label.Text = "9. OnSaveStateComplete";

            this.labels.AddLast(label);

            this.ExecutingAssembly.Text = $"Executing assembly location: {Assembly.GetExecutingAssembly().Location}";
            foreach (var lbl in this.labels)
            {
                this.PrintList.Items.Add(lbl);
            }
        }

        protected override void OnUnload(EventArgs e)
        {
            // no OnRender ? 
            // Too Late to print inside OnUnload
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ButtonPrintName_Click(object sender, EventArgs e)
        {
            this.NameLabel.Text = string.Format($"Hello {this.Name.Text}!");
        }
    }
}