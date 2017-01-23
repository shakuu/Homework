using System;

using WebFormsMvp;

namespace WebFormsIntroduction.WebFormsClient.App_Start.PresenterFactories
{
    public interface ICustomPresenterFactory
    {
        IPresenter CreatePresenter(Type presenterType, IView viewInstance);
    }
}
