namespace Examples.FactoryMethod
{
    public abstract class BaseClass
    {
        protected IDependency dependency;

        protected abstract void InitializeDependencies();
    }
}
