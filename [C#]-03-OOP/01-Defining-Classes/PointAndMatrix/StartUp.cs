
namespace PointAndMatrix
{
    using System;
    using Tests;
    using Attributes;

    [Version(1, 14)]
    class StartUp
    {
        static void Main(string[] args)
        {
            var type = typeof(StartUp);
            var attributes = type.GetCustomAttributes(false);
            
            foreach (VersionAttribute atr in attributes)
            {
                Console.WriteLine("Version: {0}", atr.Version);
            }


            //GenericListTesting.MainTest();
            MatrixTesting.MainTest();
        }
    }
}
