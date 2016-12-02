using System;

namespace BinaryPasswords
{
    public class BinaryPasswords
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            long result = 1;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '*')
                {
                    result *= 2;
                }
            }

            Console.WriteLine(result);
        }
    }
}
