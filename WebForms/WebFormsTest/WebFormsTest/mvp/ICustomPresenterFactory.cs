using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace WebFormsTest.mvp
{
    public interface ICustomPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, Type viewType, IView viewInstance);
    }
}
