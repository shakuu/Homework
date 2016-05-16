using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _06_Save_Sorted_Names
{
    class Program
    {
        static void Main()
        {
            // Input.
            var fileInput = @"D:\GitHub\Test-Files\06input.txt";//Console.ReadLine();
            var fileOutput = @"D:\GitHub\Test-Files\06output.txt";//Console.ReadLine();

            var toSort = new List<string>();

            // Read the file.
            using (var reader = new StreamReader(fileInput))
            {
                var curLine = reader.ReadLine();

                while (curLine!=null)
                {
                    toSort.Add(curLine);

                    curLine = reader.ReadLine();
                }
            }

            toSort.Sort();

            // Write to a new file.
            using (var writer = new StreamWriter(fileOutput, false, Encoding.UTF8))
            {
                foreach (var item in toSort)
                {
                    writer.WriteLine(item);
                }
            }
        }
    }
}
