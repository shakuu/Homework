using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumofNnumbers
{
    class SumOfNNumbers
    {
        static void Main(string[] args)
        {
            int inputNumb = int.Parse(Console.ReadLine());

            double[] numbers = new double[inputNumb];
            for(int i = 0; i < numbers.Length; i++)
            { numbers[i] = double.Parse(Console.ReadLine()); }

            Console.WriteLine(numbers.Sum());
        }
    }
}
