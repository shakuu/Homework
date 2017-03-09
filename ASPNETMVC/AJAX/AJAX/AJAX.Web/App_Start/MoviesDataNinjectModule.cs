using Ninject.Extensions.Conventions;
using Ninject.Extensions.Conventions.Syntax;
using Ninject.Modules;
using Ninject.Web.Common;

using AJAX.MoviesData;

namespace AJAX.Web.App_Start
{
    public class MoviesDataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(this.BindAllClasses);
        }

        private void BindAllClasses(IFromSyntax binding)
        {
            binding
                .FromAssembliesMatching("*.MoviesData.*")
                .SelectAllClasses()
                .BindDefaultInterface()
                .ConfigureFor<IMoviesDbContext>(c => c.InRequestScope());
        }
    }
}