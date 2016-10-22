namespace Examples.FactoryMethod
{
    public class SubClassTypeB : BaseClass
    {
        public SubClassTypeB()
        {
            this.InitializeDependencies();
        }

        protected override void InitializeDependencies()
        {
            base.dependency = new DependencyImplementationTypeB();
        }
    }
}
