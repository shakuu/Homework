using System;

using WebFormsMvp;
using WebFormsMvp.Binder;

namespace WebFormsIntroduction.WebFormsClient.App_Start.PresenterFactories
{
    public class WebFormsMvpPresenterFactory : IPresenterFactory
    {
        private readonly ICustomPresenterFactory factory;

        public WebFormsMvpPresenterFactory(ICustomPresenterFactory factory)
        {
            this.factory = factory;
        }

        public IPresenter Create(Type presenterType, Type viewType, IView viewInstance)
        {
            return this.factory.CreatePresenter(presenterType, viewInstance);
        }

        public void Release(IPresenter presenter)
        {
            var disposable = presenter as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}