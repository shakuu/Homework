using System;

using CSharpExam1.Task4.Models;

namespace CSharpExam1.Task4
{
    public class BatConsoleSignal
    {
        public static void Main()
        {
            var batmanSize = int.Parse(Console.ReadLine());
            var batmanCharacterToPrint = Console.ReadLine();

            var batman = new Batman(batmanSize, batmanCharacterToPrint[0]);
            Console.WriteLine(batman.ToString());
        }
    }
}
