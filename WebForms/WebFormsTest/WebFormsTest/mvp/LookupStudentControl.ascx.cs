using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace WebFormsTest.mvp
{
    [PresenterBinding(typeof(LookupStudentPresenter))]
    public partial class LookupStudentControl : MvpUserControl<LookupStudentModel>, ILookupStudentView
    {
        #region ILookupStudentView Members

        public event EventHandler<FindStudentEventArgs> Finding;
        public event EventHandler<GetAllStudentsArgs> GetAll;

        #endregion

        protected void FindClick(object sender, EventArgs e)
        {
            int? id = string.IsNullOrEmpty(studentId.Text)
                          ? (int?)null
                          : Convert.ToInt32(studentId.Text);
            OnFinding(id);
        }

        private void OnFinding(int? id)
        {
            GridView1.Visible = false;
            results.Visible = true;
            Finding(this, new FindStudentEventArgs { Id = id });
        }

        protected void Page_Load(object sender, EventArgs e) { }

        protected void FindAll(object sender, EventArgs e)
        {
            results.Visible = false;
            GridView1.Visible = true;
            GetAll(this, new GetAllStudentsArgs());
        }
    }
}