using System.Reflection;

using ExamPrep.Data.Common.Services.Contracts;

using Ninject;
using ExamPrep.Data.Utils.RandomDataGenerators;

namespace ExamPrep.Testing
{
    public class Program
    {
        public static void Main()
        {
            var ninject = new StandardKernel();
            ninject.Load(Assembly.GetExecutingAssembly());

            var service = ninject.Get<ISampleService>();

            var randomData = new RandomDataGenerator();
            service.CreateSampleModel(randomData.GenerateString(10));
            service.CreateSampleModel(randomData.GenerateString(10));
            service.CreateSampleModel(randomData.GenerateString(10));
            service.CreateSampleModel(randomData.GenerateString(10));
            service.CreateSampleModel(randomData.GenerateString(10));
            service.CreateSampleModel(randomData.GenerateString(10));
            service.CreateSampleModel(randomData.GenerateString(10));
        }
    }
}
