namespace Examples.AbstractFactory
{
    public class AbstractFactoryImplementationA : IAbstractFactory
    {
        public ITypeA CreateInstanceOfTypeA()
        {
            return new TypeAImplmentationA();
        }

        public ITypeB CreateInstanceOfTypeB()
        {
            return new TypeBImplmentationA();
        }
    }
}
