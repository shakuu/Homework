namespace TemplateMethod
{
    public class InheritingClass : BaseClass
    {
        public override string DoWork()
        {
            return $"InheritingClass extends {base.DoWork()}";
        }
    }
}
