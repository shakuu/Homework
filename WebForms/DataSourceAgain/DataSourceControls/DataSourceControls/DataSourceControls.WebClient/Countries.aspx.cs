using System;

namespace DataSourceControls.WebClient
{
    public partial class Countries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void TownsListView_InsertItem()
        {
            var item = new DataSourceControls.Continents.Town();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                var countryIndex = this.CountriesGridView.SelectedIndex;
                var country = this.CountriesGridView.SelectedDataKey;
            }
        }
    }
}