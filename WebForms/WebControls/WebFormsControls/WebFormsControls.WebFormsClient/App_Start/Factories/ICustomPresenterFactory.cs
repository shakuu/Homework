using System;

using WebFormsMvp;

namespace WebFormsControls.WebFormsClient.App_Start.Factories
{
    public interface ICustomPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, IView viewInstance);
    }
}
