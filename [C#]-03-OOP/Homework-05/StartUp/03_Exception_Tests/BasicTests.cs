
namespace StartUp._03_Exception_Tests
{
    using System;
    using ExceptionsAssembly;

    public static class BasicTests
    {
        public static void Test_01()
        {
            Console.WriteLine();

            var min = DateTime.ParseExact("01-01-1980", "dd-MM-yyyy", null);
            var max = DateTime.ParseExact("31-12-2013", "dd-MM-yyyy", null);

            var teste = new InvalidRangeException<DateTime>("unsuccessful",
                    DateTime.ParseExact("01-01-1980", "dd-MM-yyyy", null),
                    DateTime.ParseExact("31-12-2013", "dd-MM-yyyy", null));

            var test = DateTime.Parse("1.1.1975");
            try
            {
                Validate.ValidateDataInRange(test, min, max);
            }
            catch (InvalidRangeException<DateTime> e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
