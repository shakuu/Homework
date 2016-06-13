namespace StartUp._02_PersonAssembly_Tests
{
    using PersonAssembly;
    using System;

    public static class BasicTests
    {
        public static void Test_01()
        {
            var person = new Person("Pesho");
            var person1 = new Person("Goshe", 27);

            Console.WriteLine(person.ToString());
            Console.WriteLine(person1.ToString());
        }
    }
}
