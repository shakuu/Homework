namespace Examples.AbstractFactory
{
    public class AbstractFactoryImplementationB : IAbstractFactory
    {
        public ITypeA CreateInstanceOfTypeA()
        {
            return new TypeAImplmentationB();
        }

        public ITypeB CreateInstanceOfTypeB()
        {
            return new TypeBImplmentationB();
        }
    }
}
