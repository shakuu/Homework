using System;

using WebFormsMvp;

namespace WebFormsDataBinding.WebClient.App_Start.Factories
{
    public interface ICustomPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, IView viewInstance);
    }
}
