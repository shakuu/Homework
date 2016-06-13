
namespace StartUp._03_BitArray64Assembly_Tests
{
    using System;

    public static class BasicTests
    {
        public static void Test_01()
        {
            //var test = new BitArray64Assembly.BitArray64Models.BitArray64("1010101");
            var test = new BitArray64Assembly.BitArray64Models.BitArray64(9151314442816847872);
            var test1 = new BitArray64Assembly.BitArray64Models.BitArray64(9151314442816847872);

            Console.WriteLine("ulong value: {0}", test.ULongValue);
            Console.WriteLine("binary value: {0}", test.ToString());

            //Console.WriteLine(string.Join(", ", test));
            //test[62] = 0;
            Console.WriteLine(test.ULongValue);
            Console.WriteLine(test.ToString());

            Console.WriteLine(test.GetHashCode());
            Console.WriteLine(test1.GetHashCode());
            test[62] = 0;
            Console.WriteLine(test.GetHashCode());
            Console.WriteLine(test1.GetHashCode());
        }
    }
}
