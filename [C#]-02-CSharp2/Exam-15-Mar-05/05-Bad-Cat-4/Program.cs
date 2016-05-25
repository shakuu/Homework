

namespace _05_Bad_Cat_4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Collections;

    class Program
    {
        static List<List<string>> instructionsList = new List<List<string>>();
        static string[] ControlStrings = new string[10];

        static void Main()
        {
            for (int i = 0; i < 10; i++)
            {
                instructionsList.Add(new List<string>());
            }

            var numberOfInputLines = int.Parse(Console.ReadLine());

            // Get All instructions
            for (int line = 0; line < numberOfInputLines; line++)
            {
                var curLine =
                    Console.ReadLine()
                    .Trim()
                    .Split(' ')
                    .ToArray();

                var curDigit = int.Parse(curLine[0]);

                instructionsList[curDigit].Add(string.Join(" ", curLine, 2, 2));
            }

            // Build All strings , excludiing 0
            for (int digit = 0; digit < 10; digit++)
            {
                // Build string
                if (instructionsList[digit].Count() > 0)
                {
                    ControlStrings[digit] = BuildString(digit);
                }
            }

            // Replace Numbers in 0 string with 
            // their strings
            ControlStrings[0] = ZeroString();

            // Get Output out of all strings
            Console.WriteLine(GetOutput());

        }

        // GetOuput
        static string GetOutput()
        {
            var temp = new StringBuilder();

            var curOutput = ControlStrings[1];

            for (int index = 2; index < ControlStrings.Length; index++)
            {
                if (string.IsNullOrEmpty(ControlStrings[index]))
                {
                    continue;
                }

                var curString = ControlStrings[index].ToArray().ToList();
                var prevOutput = curOutput.ToCharArray().ToList();

                while (curString.Count() > 0 || prevOutput.Count() > 0)
                {
                    if (curString.Count() == 0)
                    {
                        temp.Append(prevOutput[0]);
                        prevOutput.RemoveAt(0);
                    }
                    else if (prevOutput.Count() == 0)
                    {
                        temp.Append(curString[0]);
                        curString.RemoveAt(0);
                    }
                    else if (curString[0] < prevOutput[0])
                    {
                        temp.Append(curString[0]);
                        curString.RemoveAt(0);
                    }
                    else if (curString[0] > prevOutput[0])
                    {
                        temp.Append(prevOutput[0]);
                        prevOutput.RemoveAt(0);
                    }
                    else if (curString[0] == prevOutput[0])
                    {
                        temp.Append(prevOutput[0]);
                        prevOutput.RemoveAt(0);
                        curString.RemoveAt(0);
                    }
                }

                curOutput = temp.ToString();
                temp.Clear();
            }

            if (string.IsNullOrEmpty(ControlStrings[0]))
            {
                return curOutput;
            }

            // Find the 0 Spot
            if (ControlStrings[0][0] == '0')
            {
                // Zero cannot be first
                var zeroStringNoZero = ControlStrings[0].Substring(1, ControlStrings[0].Length - 1);
                var length = ControlStrings[0].Length - 1;

                var indexOfFirstDigit = curOutput.IndexOf(zeroStringNoZero);

                if (indexOfFirstDigit != 0)
                {
                    curOutput.Insert(indexOfFirstDigit, "0");
                }
                else
                {
                    var digitToInsert = curOutput[indexOfFirstDigit + length];

                    curOutput = curOutput.Remove(indexOfFirstDigit + length, 1);
                    curOutput = curOutput.Insert(0, "0");
                    curOutput = curOutput.Insert(0, digitToInsert.ToString());
                }

            }
            else
            {
                var zeroStringIdex = curOutput.IndexOf(ControlStrings[0]);
                var zeroIndex = ControlStrings[0].IndexOf("0");

                curOutput = curOutput.Insert(zeroStringIdex + zeroIndex, "0");
            }

            return curOutput;
        }

        // Zero String
        static string ZeroString()
        {
            if (string.IsNullOrEmpty(ControlStrings[0]))
            {
                return null;
            }

            foreach (var digit in ControlStrings[0])
            {
                if (digit != '0')
                {
                    ControlStrings[0] = ControlStrings[0].Replace(digit.ToString(), ControlStrings[digit - '0']);
                }
            }

            var newzerostring = new StringBuilder();
            var flags = new BitArray(10);
            foreach (var digit in ControlStrings[0])
            {
                if (!flags[digit - '0'])
                {
                    flags[digit - '0'] = true;
                    newzerostring.Append(digit);
                }
            }

            return newzerostring.ToString();
        }

        static string BuildString(int digit)
        {
            var curString = new StringBuilder().Append(digit);

            foreach (var instruction in instructionsList[digit])
            {
                var parseInstruction = instruction.Split(' ').ToArray();

                if (curString.ToString().Contains(parseInstruction[1].ToString()))
                {
                    continue;
                }

                if (parseInstruction[0] == "after")
                {
                    for (int index = 0; index < curString.Length; index++)
                    {
                        if (curString[index] - '0' == digit)
                        {
                            curString.Insert(index, parseInstruction[1]);
                            break;
                        }

                        if (int.Parse(parseInstruction[1]) > int.Parse(curString[index].ToString()))
                        {
                            continue;
                        }
                        else
                        {
                            curString.Insert(index, parseInstruction[1]);
                        }
                    }
                }
                else
                {
                    var curPositionOfDigit = curString.ToString().IndexOf(digit.ToString());

                    for (int index = curString.Length - 1; index >= curPositionOfDigit; index--)
                    {

                        if (curString[index] - '0' == digit)
                        {
                            curString.Insert(index + 1, parseInstruction[1]);
                            break;
                        }

                        if (int.Parse(parseInstruction[1]) < int.Parse(curString[index].ToString()))
                        {
                            continue;
                        }
                        else
                        {
                            curString.Insert(index + 1, parseInstruction[1]);
                        }
                    }
                }

            }

            return curString.ToString();
        }
    }
}
