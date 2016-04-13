using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Neurons
{
    class Neurons
    {
        static void Main()
        {
            //get strings
            List<string> Strings = new List<string>();
            long temp;
            while (true)
            {
                temp = long.Parse( Console.ReadLine());
                if ( temp<0)
                { break; }

                Strings.Add(Convert.ToString(temp, 2).PadLeft(32, '0'));
            }

            //Fill with 1s
            for ( int i =0; i < Strings.Count; i++)
            {
                if ( Strings[i].Contains('1'))
                {
                    for (int p = Strings[i].IndexOf("1")+1; p < Strings[i].LastIndexOf("1"); p++ )
                    {
                        Strings[i] = Strings[i].Insert(p, "1");
                        Strings[i] = Strings[i].Remove(p + 1, 1);
                    }
                }
                // Console.WriteLine(Strings[i]);
                
                Console.WriteLine(Convert.ToInt64(Strings[i], 2));
            }
        }
    }
}
