using System.Reflection;

using ExamPrep.Data.Common.Services.Contracts;
using ExamPrep.Data.Utils.RandomDataGenerators;

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

            var randomData = new RandomDataGenerator();
            service.CreateSampleModel(randomData.GenerateString(10), randomData.GenerateDate(2016, 2006), randomData.GenerateIntValue(100, 20));
            service.CreateSampleModel(randomData.GenerateString(10), randomData.GenerateDate(2016, 2006), randomData.GenerateIntValue(100, 20));
            service.CreateSampleModel(randomData.GenerateString(10), randomData.GenerateDate(2016, 2006), randomData.GenerateIntValue(100, 20));
            service.CreateSampleModel(randomData.GenerateString(10), randomData.GenerateDate(2016, 2006), randomData.GenerateIntValue(100, 20));
            service.CreateSampleModel(randomData.GenerateString(10), randomData.GenerateDate(2016, 2006), randomData.GenerateIntValue(100, 20));
            service.CreateSampleModel(randomData.GenerateString(10), randomData.GenerateDate(2016, 2006), randomData.GenerateIntValue(100, 20));
            service.CreateSampleModel(randomData.GenerateString(10), randomData.GenerateDate(2016, 2006), randomData.GenerateIntValue(100, 20));
            service.CreateSampleModel(randomData.GenerateString(10), randomData.GenerateDate(2016, 2006), randomData.GenerateIntValue(100, 20));
        }
    }
}
