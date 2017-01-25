using System;

namespace WebFormsControls.WebFormsClient
{
    public partial class StudentRegistration : System.Web.UI.Page
    {
        protected void OnSubmit(object sender, EventArgs e)
        {
            this.RegisterTitle.Visible = true;
            this.RegisteredName.Visible = true;
            this.RegisteredName.Text = this.FirstName.Text + " " + this.LastName.Text;
        }
    }
}