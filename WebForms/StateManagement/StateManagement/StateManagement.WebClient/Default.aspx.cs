using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagement.WebClient
{
    public partial class Default : System.Web.UI.Page
    {
        private const string TaskTwoListSessionObject = "TaskTwoList";

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void OnSubmitText(object sender, EventArgs e)
        {
            var currentList = this.Session[Default.TaskTwoListSessionObject] as List<string> ?? new List<string>();
            currentList.Add(this.TaskTwoContent.Text);
            this.TaskTwoOutput.Text = string.Join(", ", currentList);
            this.Session[Default.TaskTwoListSessionObject] = currentList;
        }
    }
}