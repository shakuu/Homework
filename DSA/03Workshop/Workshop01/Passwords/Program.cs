using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Passwords
{
    public class Program
    {
        private static Stack<string> operations = new Stack<string>();

        private static Stack<string> currentSequence = new Stack<string>();

        private static string[] possibleSymbols = Enumerable.Range(1, 10).Select(x => x.ToString().Substring(x.ToString().Length - 1, 1)).ToArray();
        
        private static int combinationsCount;
        private static int currentCombination = 0;

        private static List<string> results = new List<string>();

        public static void Main()
        {
            var sequenceLength = int.Parse(Console.ReadLine());

            var sequenceInput = Console.ReadLine();
            for (int i = 0; i < sequenceInput.Length; i++)
            {
                operations.Push(sequenceInput[i].ToString());
            }

            combinationsCount = int.Parse(Console.ReadLine());

            Program.GenerateSequence(possibleSymbols.Length - 1);
            currentSequence.Pop();
            for (int i = 0; i < possibleSymbols.Length - 1; i++)
            {
                Program.GenerateSequence(i);
                currentSequence.Pop();
            }
        }

        private static void GenerateSequence(int currentIndex)
        {
            currentSequence.Push(possibleSymbols[currentIndex]);

            if (operations.Count == 0)
            {
                Program.currentCombination++;
                return;
            }

            var nextOperation = operations.Pop();
            if (nextOperation == "=")
            {
                //currentSequence.Push(possibleSymbols[currentIndex]);
                Program.GenerateSequence(currentIndex);
                operations.Push("=");

                if (Program.currentCombination != Program.combinationsCount)
                {
                    currentSequence.Pop();
                }
                else
                {
                    Program.End();
                }
            }
            else if (nextOperation == "<")
            {
                for (int i = 0; i < currentIndex; i++)
                {
                    //currentSequence.Push(possibleSymbols[i]);
                    Program.GenerateSequence(i);

                    if (Program.currentCombination == Program.combinationsCount)
                    {
                        Program.End();
                    }

                    currentSequence.Pop();
                }

                operations.Push("<");
            }
            else if (nextOperation == ">")
            {

                if (currentIndex != possibleSymbols.Length - 1)
                {
                    Program.GenerateSequence(possibleSymbols.Length - 1);

                    if (Program.currentCombination == Program.combinationsCount)
                    {
                        Program.End();
                    }

                    currentSequence.Pop();
                }

                if (!(Program.currentCombination == Program.combinationsCount))
                {
                    for (int i = currentIndex + 1; i < possibleSymbols.Length - 1; i++)
                    {
                        //currentSequence.Push(possibleSymbols[i]);
                        Program.GenerateSequence(i);

                        if (Program.currentCombination == Program.combinationsCount)
                        {
                            Program.End();
                        }

                        currentSequence.Pop();
                    }
                }

                operations.Push(">");
            }
        }

        private static void End()
        {
            var result = new StringBuilder();
            var len = currentSequence.Count;
            for (var i = 0; i < len; i++)
            {
                result = result.Insert(0, currentSequence.Pop());
            }

            Console.WriteLine(result.ToString());
            Environment.Exit(0);
        }
    }
}
