using System;
using System.Threading;

namespace _00_Generate_Array_Input_HW_Format
{
    class GenerateArrayInput
    {
        static void Main()
        {
            // input
            Console.WriteLine("Paste path to debug folder here:\n" +
                              "Example: C:\\GitHub\\00-Sample-Project\\bin\\Debug\n");
            string PathToDebug =  Console.ReadLine();

            if (PathToDebug=="")
            {
                PathToDebug = ".";
            }

            Console.WriteLine("Enter Array Size: ");
            int inputSize = int.Parse(Console.ReadLine());

            string[] array = new string[inputSize + 1];

            array[0] = inputSize.ToString(); // line 1 -> number of elements

            Random randomizer = new Random();

            for (int i = 1; i < inputSize+1; i++)
            {
                array[i] = (randomizer.Next(0, int.MaxValue)).ToString(); // change max value
            }

            // INSTRUCTIONS
            string[] Path = PathToDebug.Split('\\');
            string[] Instructions = new string[1];
            Instructions[0] = Path[Path.Length - 3] + ".exe < test001.txt > test001out.txt";

            try
            {
                System.IO.File.WriteAllLines(PathToDebug + "\\CMD-Instructions.txt", Instructions);
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                Console.WriteLine("Folder does NOT exist");
            }

            try
            {
                System.IO.File.WriteAllLines(PathToDebug + "\\test001.txt", array);

                Console.WriteLine("done!\nCopy array from .txt or copy cmd line from\nInstructions.txt to generate an output file");
                Console.WriteLine("This app will self destruct in 5...");
                Thread.Sleep(5000);
                return;
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                Console.WriteLine("Folder does NOT exist");
            }
        }
    }
}
