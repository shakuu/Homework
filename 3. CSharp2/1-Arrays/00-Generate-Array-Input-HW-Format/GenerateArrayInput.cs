using System;

namespace _00_Generate_Array_Input_HW_Format
{
    class GenerateArrayInput
    {
        static void Main()
        {
            // input
            Console.WriteLine("Enter Array Size: ");
            int inputSize = int.Parse(Console.ReadLine());

            string[] array = new string[inputSize + 1];

            array[0] = inputSize.ToString(); // line 1 -> number of elements

            Random randomizer = new Random();

            for (int i = 1; i < inputSize+1; i++)
            {
                array[i] = (randomizer.Next(0, 100)).ToString(); // change max value
            }

            // IMPORTANT: CHANGE THIS TO YOUR OWN EXISTING FOLDER
            System.IO.File.WriteAllLines(@"D:\GitHub\_ArrayInput\test001.txt",  array);
        }
    }
}
