using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolToNumber
{
    class SymToNum
    {
        static void Main()
        {
            int SECRET = int.Parse(Console.ReadLine());
            string TEXT = Console.ReadLine();

            Queue<int> encode = new Queue<int>();

            foreach ( var symbol in TEXT)
            {
                if (symbol == '@')
                {
                    break;
                }
                else if (symbol >= 'a' && symbol <= 'z') //97 122
                {
                    encode.Enqueue( symbol * SECRET + 1000); 
                }
                else if (symbol >= 'A' && symbol <= 'Z') //97 122
                {
                    encode.Enqueue(symbol * SECRET + 1000);
                }
                else if (symbol >= '0' && symbol <= '9') //97 122
                {
                    encode.Enqueue(symbol + SECRET + 500);
                }
                else { encode.Enqueue(symbol - SECRET );  }
            }

            while (encode.Count > 0)
            {
                Console.WriteLine((Convert.ToDouble(encode.Dequeue().ToString()) / 100).ToString("F2"));
                
                if (encode.Count > 0)
                {
                    Console.WriteLine(Convert.ToInt32(encode.Dequeue().ToString()) * 100);
                   
                }
            }
        }
    }
}
