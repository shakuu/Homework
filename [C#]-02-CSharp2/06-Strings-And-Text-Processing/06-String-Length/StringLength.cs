using System;
using System.Text;

namespace _06_String_Length
{
    class StringLength
    {
        static void Main()
        {
            //Console.WriteLine(
            //    Console.ReadLine()
            //    .PadRight(20, '*')
            //    );

            var buildOutput = new StringBuilder(20);

            buildOutput.Append(Console.ReadLine());

            while (buildOutput.Length < 20)
            {
                buildOutput.Append("*");
            }

            Console.WriteLine(buildOutput);
        }
    }
}
