using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace _09_Delete_Odd_Lines_2
{
    class Program
    {
        static void Main()
        {
            // File to parse
            var filePath = @"D:\GitHub\Test-Files\notfound.html";//Console.ReadLine();

            var fileHelper = @"temp.txt";

            var reader = new StreamReader(filePath);

            var writer = new StreamWriter(fileHelper);

            var counter = 0;

            while (!reader.EndOfStream)
            {
                if (counter++ % 2 == 0)
                {
                    writer.WriteLine(reader.ReadLine());
                }
                else
                {
                    reader.ReadLine();
                }
            }

            reader.Close();
            writer.Close();

            File.Delete(filePath);
            File.Move(fileHelper, filePath);
        }
    }
}
