﻿using System;
using System.Linq;

using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Parameters;

using WebFormsControls.WebFormsClient.App_Start.Factories;

using WebFormsMvp;
using WebFormsMvp.Binder;

using WebFormsControls.RandomNumber;

using WebFormsControls.TicTacToe;
using WebFormsControls.TicTacToe.TicTacToeServices.Contracts;
using WebFormsControls.TicTacToe.TicTacToeServices;
using WebFormsControls.TicTacToe.Factories;

namespace WebFormsControls.WebFormsClient.App_Start.NinjectModules
{
    public class MvpNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IRandomPresenter>().To<RandomPresenter>();
            this.Bind<ITicTacToePresenter>().To<TicTacToePresenter>();
            this.Bind<ITicTacToeService>().To<TicTacToeService>();

            this.Bind<ITicTacToeViewModelFactory>().ToFactory();

            this.Bind<Random>().ToSelf().InSingletonScope();

            this.Bind<IPresenterFactory>().To<WebFormsMvpPresenterFactory>().InSingletonScope();
            this.Bind<ICustomPresenterFactory>().ToFactory().InSingletonScope();
            this.Bind<IPresenter>().ToMethod(this.GetPresenterFactoryMethod)
                .NamedLikeFactoryMethod((ICustomPresenterFactory factory) => factory.GetPresenter(null, null));
        }

        private IPresenter GetPresenterFactoryMethod(IContext context)
        {
            var parameters = context.Parameters.ToList();

            var presenterType = (Type)parameters[0].GetValue(context, null);
            var viewInstance = (IView)parameters[1].GetValue(context, null);

            var ctorViewInstanceParameter = new ConstructorArgument("view", viewInstance);

            return (IPresenter)context.Kernel.Get(presenterType, ctorViewInstanceParameter);
        }
    }
}