using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.IO;
using System.Reflection;

using ExamPrep.Data;
using ExamPrep.Data.Common.Factories;
using ExamPrep.Data.Common.Repositories;
using ExamPrep.Data.Common.Repositories.Contracts;
using ExamPrep.Data.Common.SampleModels;
using ExamPrep.Data.Common.UnitsOfWork;
using ExamPrep.Data.Common.UnitsOfWork.Contracts;

using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Modules;

namespace ExamPrep.Testing
{
    public class SampleModelsModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(ctx =>
                ctx.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface());

            this.Bind<DbContext>().To<SampleModelContext>().InSingletonScope();
            this.Bind<IUnitOfWork>().To<EfUnitOfWork>().Named("EfUnitOfWork");

            this.Bind(typeof(IRepository<>)).To(typeof(EfGenericRepository<>));

            this.Bind<ISampleModelFactory>().ToFactory().InSingletonScope();
            this.Bind<IUnitOfWorkFactory>().ToFactory().InSingletonScope();
        }
    }
}
