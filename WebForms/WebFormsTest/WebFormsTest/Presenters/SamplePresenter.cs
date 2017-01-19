using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;
using WebFormsTest.Views;

namespace WebFormsTest.Presenters
{
    public class SamplePresenter : Presenter<ISampleView>
    {
        public SamplePresenter(ISampleView view) : base(view)
        {
        }
    }
}