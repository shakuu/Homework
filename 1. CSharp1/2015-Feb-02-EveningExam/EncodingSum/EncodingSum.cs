using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodingSum
{
    class EncodingSum
    {
        static void Main()
        {
            short Module = short.Parse(Console.ReadLine());
            string Text = Console.ReadLine().ToUpper();
            long RESULT = 0;

            foreach(char currChar in Text)
            {
                if (currChar=='@')
                {
                    Console.WriteLine(RESULT);
                    return;
                }
                else if ( currChar >= 'A' && currChar<= 'Z')
                {
                    RESULT += currChar - 'A';
                }
                else if ( currChar>= '0' && currChar <= '9')
                {
                    RESULT *= (currChar - '0');
                }
                else
                {
                    RESULT %= Module;
                }
            }
        }
    }
}
