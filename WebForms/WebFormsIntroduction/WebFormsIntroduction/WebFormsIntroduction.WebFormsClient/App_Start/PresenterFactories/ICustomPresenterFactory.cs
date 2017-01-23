using System;

using WebFormsMvp;

namespace WebFormsIntroduction.WebFormsClient.App_Start.PresenterFactories
{
    public interface ICustomPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, IView viewInstance);
    }
}
