using System;

namespace Validation.WebClient
{
    public partial class Default : System.Web.UI.Page
    {
        public void OnGenderSelectionChanged(object sender, EventArgs e)
        {
            var selectedIndex = this.GenderSelect.SelectedIndex;
            if (selectedIndex == 0)
            {
                this.Cars.Visible = true;
                this.Coffee.Visible = false;
            }
            else
            {
                this.Coffee.Visible = true;
                this.Cars.Visible = false;
            }
        }
    }
}