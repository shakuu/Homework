using System.Reflection;

using ExamPrep.Data.Common.Services.Contracts;

using Ninject;

namespace ExamPrep.Testing
{
    public class Program
    {
        public static void Main()
        {
            var ninject = new StandardKernel();
            ninject.Load(Assembly.GetExecutingAssembly());

            var service = ninject.Get<ISampleService>();
            var s1 = service.CreateSampleModel("sample");
            var s2 = service.FindOrCreate(2);

            System.Console.WriteLine(s1.Name);
            System.Console.WriteLine(s2.Name);
        }
    }
}
