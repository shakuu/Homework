using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ConsoleApp4
{
    class ConsoleApp4
    {
        static void Main()
        {
            BigInteger RESULT = 1;
            bool isRunning = true;
            string currNumber = "";

            while(isRunning)
            {
                currNumber = Console.ReadLine().ToUpper();
                //Stop on END
                if (currNumber=="END")
                {
                    Console.WriteLine(RESULT);
                    return;
                }
                if (Convert.ToInt64(currNumber) > 0)
                {
                    foreach (char currDigit in currNumber)
                    {
                        if (currDigit>='1' && currDigit<='9')
                        {
                            RESULT *= (currDigit - '0');
                        }
                    }
                }

                currNumber = Console.ReadLine().ToUpper();

                if (currNumber == "END")
                {
                    Console.WriteLine(RESULT);
                    return;
                }
            }
        }
    }
}
