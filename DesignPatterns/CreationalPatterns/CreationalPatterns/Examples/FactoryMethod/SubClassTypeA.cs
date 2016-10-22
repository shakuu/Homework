namespace Examples.FactoryMethod
{
    public class SubClassTypeA : BaseClass
    {
        public SubClassTypeA()
        {
            this.InitializeDependencies();
        }

        protected override void InitializeDependencies()
        {
            base.dependency = new DependencyImplementationTypeA();
        }
    }
}
