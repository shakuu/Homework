﻿using Ninject;
using Ninject.Modules;

using ADONET.Homework.Logic.CommandProviders.Contracts;
using ADONET.Homework.Logic.CommandProviders;
using ADONET.Homework.Logic.ConnectionProviders.Contracts;
using ADONET.Homework.Logic.ConnectionProviders;
using ADONET.Homework.Logic.DataMappers.Contracts;
using ADONET.Homework.Logic.DataMappers;
using ADONET.Homework.Logic.QueryEngines.Contract;
using ADONET.Homework.Logic.QueryEngines;
using ADONET.Homework.Logic.QueryServices.Contracts;
using ADONET.Homework.Logic.QueryServices;
using ADONET.Homework.Logic.ImageServices.Contracts;
using ADONET.Homework.Logic.ImageServices;
using ADONET.Homework.Logic.Factories.Contracts;
using ADONET.Homework.Logic.Factories;

namespace ADONET.Homework.ConsoleClient.Bindings
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IDbFactory>().To<DbFactory>();

            this.Bind<IConnectionProvider>().To<DefaultSqlServerConnectionProvider>().Named("SqlServer")
                .WithConstructorArgument("decoratedProvider", ctx => ctx.Kernel.Get<SqlServerConnectionProvider>());

            this.Bind<IConnectionProvider>().To<DefaultOleDbConnectionProvider>().Named("Ole")
                .WithConstructorArgument("decoratedProvider", ctx => ctx.Kernel.Get<OleDbConnectionProvider>());

            this.Bind<IConnectionProvider>().To<DefaultMySqlConnectionProvider>().Named("MySql")
               .WithConstructorArgument("decoratedProvider", ctx => ctx.Kernel.Get<MySqlConnectionProvider>());

            this.Bind<ICommandProvider>().To<SqlCommandProvider>().Named("SqlServer");
            this.Bind<ICommandProvider>().To<OleDbCommandProvider>().Named("Ole");
            this.Bind<ICommandProvider>().To<MySqlCommandProvider>().Named("MySql");
            
            this.Bind<IDataObjectMapper>().To<DataObjectMapper>();
            this.Bind<IQueryService>().To<QueryService>();

            this.Bind<IImageService>().To<ImageService>();

            this.Bind<IQueryEngine>().To<SimpleQueryEngine>()
                .WithConstructorArgument("connectionProvider", ctx => ctx.Kernel.Get<IConnectionProvider>("SqlServer"))
                .WithConstructorArgument("queryService", ctx => ctx.Kernel.Get<IQueryService>())
                .WithConstructorArgument("dataHandler", ctx => ctx.Kernel.Get<IDataObjectMapper>());
        }
    }
}
