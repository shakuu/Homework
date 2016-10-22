using Ninject;
using Ninject.Modules;

using ADONET.Homework.Logic.CommandProviders;
using ADONET.Homework.Logic.CommandProviders.Contracts;
using ADONET.Homework.Logic.ConnectionProviders;
using ADONET.Homework.Logic.ConnectionProviders.Contracts;
using ADONET.Homework.Logic.DataMappers;
using ADONET.Homework.Logic.DataMappers.Contracts;
using ADONET.Homework.Logic.Factories;
using ADONET.Homework.Logic.Factories.Contracts;
using ADONET.Homework.Logic.ImageServices;
using ADONET.Homework.Logic.ImageServices.Contracts;
using ADONET.Homework.Logic.QueryEngines;
using ADONET.Homework.Logic.QueryEngines.Contract;
using ADONET.Homework.Logic.QueryServices;
using ADONET.Homework.Logic.QueryServices.Contracts;

namespace ADONET.Homework.ConsoleClient.Bindings
{
    public class NinjectBindings : NinjectModule
    {
        private const string NinjectSqlServer = "SqlServer";
        private const string NinjectSQLite = "SQLite";
        private const string NinjectMySql = "MySql";
        private const string NinjectOleDb = "Ole";

        public override void Load()
        {
            this.Bind<IDbFactory>().To<DbFactory>();

            this.Bind<IConnectionProvider>().To<DefaultSqlServerConnectionProvider>().Named(NinjectBindings.NinjectSqlServer)
                .WithConstructorArgument("decoratedProvider", ctx => ctx.Kernel.Get<SqlServerConnectionProvider>());

            this.Bind<IConnectionProvider>().To<DefaultOleDbConnectionProvider>().Named(NinjectBindings.NinjectOleDb)
                .WithConstructorArgument("decoratedProvider", ctx => ctx.Kernel.Get<OleDbConnectionProvider>());

            this.Bind<IConnectionProvider>().To<DefaultMySqlConnectionProvider>().Named(NinjectBindings.NinjectMySql)
               .WithConstructorArgument("decoratedProvider", ctx => ctx.Kernel.Get<MySqlConnectionProvider>());

            this.Bind<IConnectionProvider>().To<DefaultSQLiteConnectionProvider>().Named(NinjectBindings.NinjectSQLite)
               .WithConstructorArgument("decoratedProvider", ctx => ctx.Kernel.Get<SQLiteConnectionProvider>());

            this.Bind<ICommandProvider>().To<SqlCommandProvider>().Named(NinjectBindings.NinjectSqlServer);
            this.Bind<ICommandProvider>().To<OleDbCommandProvider>().Named(NinjectBindings.NinjectOleDb);
            this.Bind<ICommandProvider>().To<MySqlCommandProvider>().Named(NinjectBindings.NinjectMySql);
            this.Bind<ICommandProvider>().To<SQLiteCommandProvider>().Named(NinjectBindings.NinjectSQLite);

            this.Bind<IDataObjectMapper>().To<DataObjectMapper>();
            this.Bind<IQueryService>().To<QueryService>();

            this.Bind<IImageService>().To<ImageService>();

            this.Bind<IQueryEngine>().To<SimpleQueryEngine>()
                .WithConstructorArgument("connectionProvider", ctx => ctx.Kernel.Get<IConnectionProvider>(NinjectBindings.NinjectSqlServer))
                .WithConstructorArgument("queryService", ctx => ctx.Kernel.Get<IQueryService>())
                .WithConstructorArgument("dataHandler", ctx => ctx.Kernel.Get<IDataObjectMapper>());
        }
    }
}
