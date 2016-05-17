using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _09_Delete_Odd_Lines
{
    class DeleteOddLinesweirdstuff
    {
        static void Main()
        {
            // Input file path
            var filePath = new FileInfo(@"D:\GitHub\Test-Files\07input.txt"); //new FileInfo(Console.ReadLine());

            var stream = filePath.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);

            byte toinsert = Convert.ToByte('*');

            stream.Position = 0;

            while (stream.Position < 10)
            {
                if (stream.ReadByte() == Convert.ToByte('f'))
                {
                    //stream.WriteByte(toinsert);
                    stream.Write(new byte[] { toinsert }, 0, 1);
                }

            }

            stream.Close();
        }
    }
}
