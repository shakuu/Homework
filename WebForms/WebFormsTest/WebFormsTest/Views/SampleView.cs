using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;
using WebFormsTest.Models;

namespace WebFormsTest.Views
{
    public interface ISampleView : IView<SampleModel>
    {
        event EventHandler<GetAllEventArgs> Finding;
    }

    public class GetAllEventArgs : EventArgs
    {
        public ICollection<SampleModel> AllSampleModels { get; set; }
    }
}