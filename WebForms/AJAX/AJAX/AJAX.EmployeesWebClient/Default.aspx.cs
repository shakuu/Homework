using System;
using System.Linq;
using System.Threading;
using System.Web.UI.WebControls;

using AJAX.Data;

namespace AJAX.EmployeesWebClient
{
    public partial class Default : System.Web.UI.Page
    {
        public void OnEmployeeSelect(object sender, EventArgs e)
        {
            var id = (int)this.EmployeesGridView.SelectedDataKey.Value;

            var db = new NorthwindEntities();
            var orders = db.Orders.Where(order => order.EmployeeID == id).ToList();

            this.EmployeeOrdersGridView.DataSource = orders;
            this.EmployeeOrdersGridView.DataBind();

            Thread.Sleep(2000);
        }
    }
}