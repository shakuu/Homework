
namespace StartUp._03_Exception_Tests
{
    using System;

    public static class BasicTests
    {
        public static void Test_01()
        {
            Console.WriteLine();

            var teste = new ExceptionsAssembly
                .InvalidRange
                .InvalidRangeException<DateTime>("unsuccessful",
                    DateTime.ParseExact( "01-01-1980", "dd-MM-yyyy", null),
                    DateTime.ParseExact("31-12-2013", "dd-MM-yyyy", null));

            var test = DateTime.Parse("1.1.1975");
            try
            {
                if (test < teste.Min || test > teste.Max)
                {
                    throw teste;
                }
                else
                {
                    Console.WriteLine("success");
                }
            }
            catch (ExceptionsAssembly.InvalidRange.InvalidRangeException<DateTime> e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
