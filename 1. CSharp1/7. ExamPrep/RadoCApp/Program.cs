using System;
using System.Numerics;

class ConsoleApplication1
{
    static void Main(string[] args)
    {
        string numbers = Console.ReadLine();
        int IsOdd = 0;
        BigInteger products = 1;
        BigInteger product10 = 1;
        bool isMoreThanTen = false;
        while (numbers != "END")
        {

            BigInteger product = 1;
            if ((IsOdd == 10) && (!isMoreThanTen))
            {
                isMoreThanTen = true;
                product10 = products;
                products = 1;
            }
            else if ((IsOdd % 2 == 0) && (numbers != "0"))
            {
                for (int i = 0; i < numbers.Length; i++)
                {

                    if (int.Parse(numbers[i].ToString()) == 0) continue;
                    else product *= int.Parse(numbers[i].ToString());
                }

            }
            products *= product;
            IsOdd++;
            numbers = Console.ReadLine();

        }
        if (isMoreThanTen) Console.WriteLine(product10);
        Console.WriteLine(products);
    }
}
