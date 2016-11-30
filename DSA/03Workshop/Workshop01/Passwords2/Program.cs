namespace Passwords
{
    using System;

    class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string relations = Console.ReadLine();
            int k = int.Parse(Console.ReadLine());

            var digits = new int[n];
            var output = new char[n];
            Recursion(0, n, k, digits, relations, output);

            Console.WriteLine(output);
        }

        public static int Recursion(int index, int n, int k, int[] digits, string relations, char[] output)
        {
            if (k <= 0)
            {
                return k;
            }

            if (index == n)
            {
                k--;
                if (k == 0)
                {
                    for (int i = 0; i < n; i++)
                    {
                        output[i] = (char)(digits[i] + '0');
                    }
                }
                return k;
            }

            if (index == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    digits[0] = i;
                    k = Recursion(1, n, k, digits, relations, output);
                }

                return k;
            }

            if (relations[index - 1] == '<')
            {
                int digit = digits[index - 1] == 0 ? 10 : digits[index - 1];
                for (int i = 1; i < digit; i++)
                {
                    digits[index] = i;
                    k = Recursion(index + 1, n, k, digits, relations, output);
                }

                return k;
            }

            if (relations[index - 1] == '>')
            {
                int digit = digits[index - 1];
                if (digit == 0)
                {
                    return k;
                }

                digits[index] = 0;
                k = Recursion(index + 1, n, k, digits, relations, output);

                for (int i = digit + 1; i < 10; i++)
                {
                    digits[index] = i;
                    k = Recursion(index + 1, n, k, digits, relations, output);
                }

                return k;
            }

            digits[index] = digits[index - 1];
            return Recursion(index + 1, n, k, digits, relations, output);
        }
    }
}
