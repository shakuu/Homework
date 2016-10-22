namespace Examples.AbstractFactory
{
    public interface IAbstractFactory
    {
        ITypeA CreateInstanceOfTypeA();

        ITypeB CreateInstanceOfTypeB();
    }
}
