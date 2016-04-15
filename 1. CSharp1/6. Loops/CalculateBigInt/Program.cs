using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CalculateBigInt
{
    class CalculateBigInt
    {
        static void Main()
        {
            int numbN = int.Parse(Console.ReadLine());
            string numbX = Console.ReadLine();

            if (numbX.Contains("."))
            {
                string floatbit = numbX.Substring(numbX.IndexOf("."),
                    numbX.Length - numbX.IndexOf("."));
                int decimalPoint = floatbit.Length - 1;
                numbX = numbX.Remove(numbX.IndexOf("."), 1);
            }

            BigInteger numbX1 = BigInteger.Parse(numbX);

            BigInteger[] results = new BigInteger[numbN + 1];
            results[0] = 1;

            BigInteger[] Top = new BigInteger[numbN + 1];
            BigInteger[] Bottome = new BigInteger[numbN + 1];
            //TODO SEPARATE CALCULATIONS
            unchecked
            {
                for (int index = 1; index < numbN + 1; index++)
                {

                    results[index] = results[index - 1] * (index / numbX1);

                }
            }

            BigInteger SUM = 0;

            for ( int i = 0; i< numbN+1;i++)
            {
                SUM += results[i];
            }
            Console.WriteLine("{0,0:f5}", SUM);
        }
    }
}
