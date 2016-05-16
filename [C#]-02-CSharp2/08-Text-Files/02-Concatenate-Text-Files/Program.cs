using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _02_Concatenate_Text_Files
{
    class Program
    {
        static void Main()
        {
            var input1 = @"D:\GitHub\notfound.html"; //Console.ReadLine();
            var input2 = @"D:\GitHub\notfound.html"; //Console.ReadLine();
            var output = @"D:\GitHub\NinjaTimes2.html"; //Console.ReadLine();

            using (var writer = new StreamWriter(output))
            {
                using (var reader = new StreamReader(input1))
                {
                    writer.WriteLine(reader.ReadToEnd());
                }

                using (var reader = new StreamReader(input2))
                {
                    writer.WriteLine(reader.ReadToEnd());
                }
            }
        }
    }
}
