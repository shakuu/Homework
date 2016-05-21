using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_String_Length_CP
{
    // COPY-PASTED SOLUTION

    class OMFG
    {
        static void Main()
        {
            //string text = "a\u0304\u0308bc\u0327\n";
            string text = Console.ReadLine();
            text = text.Replace(@"\", string.Empty);
            Console.WriteLine(text.PadRight(20, '*'));
        }
    }
}
