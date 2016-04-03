using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSolverCopyPaste
{
    class Program
    {
        static void Main()
        {
            int numbN = int.Parse(Console.ReadLine());

            string[] arrToPrint = new string[numbN];
            
            arrToPrint[0] = "1 ";

            for (int i = 1; i < numbN; i++)
            {

                arrToPrint[i] = arrToPrint[i-1].ToString() + "* " +(i+1).ToString() + " ";
                Console.WriteLine(arrToPrint[i]);
                
            }
            System.IO.File.WriteAllLines(@"D:\GitHub\Homework\6. Loops\Calculate\CalculateCP.txt", arrToPrint);
        }
    }
}
