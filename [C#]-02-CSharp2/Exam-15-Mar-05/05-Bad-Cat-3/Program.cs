
namespace _05_Bad_Cat_3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            var instructions = int.Parse(Console.ReadLine());

            var isAfter = new int[10];
            var isBefore = new int[10];
            var isAfterZero = new bool[10];

            for (int i = 0; i < 10; i++)
            {
                isAfter[i] = i - 1;
                isBefore[i] = i + 1;
            }

            var output = new List<int>();

            for (int instruction = 0; instruction < instructions; instruction++)
            {
                var curInstrutcion =
                    Console.ReadLine()
                    .Trim()
                    .Split(' ')
                    .ToArray();

                if (output.IndexOf(int.Parse(curInstrutcion[0])) < 0)
                {
                    output.Add(int.Parse(curInstrutcion[0]));
                }

                if (output.IndexOf(int.Parse(curInstrutcion[3])) < 0)
                {
                    output.Add(int.Parse(curInstrutcion[3]));
                }

                if (curInstrutcion[2] == "after")
                {
                    var curInstrutcionPos = int.Parse(curInstrutcion[3]);
                    
                    isAfter[int.Parse(curInstrutcion[0])] = 
                        curInstrutcionPos > isAfter[int.Parse(curInstrutcion[0])] ?
                        curInstrutcionPos : isAfter[int.Parse(curInstrutcion[0])];

                    if (curInstrutcionPos == 0)
                    {
                        isAfterZero[int.Parse(curInstrutcion[3])] = true;
                    }

                    if (isAfter[int.Parse(curInstrutcion[0])] == 
                        isBefore[int.Parse(curInstrutcion[0])])
                    {
                        isBefore[int.Parse(curInstrutcion[0])]++;
                    }

                    curInstrutcionPos = int.Parse(curInstrutcion[0]);

                    isBefore[int.Parse(curInstrutcion[3])] =
                        curInstrutcionPos < isAfter[int.Parse(curInstrutcion[3])] ?
                        curInstrutcionPos : isAfter[int.Parse(curInstrutcion[3])];
                    
                    if (isAfter[int.Parse(curInstrutcion[3])] ==
                       isBefore[int.Parse(curInstrutcion[3])])
                    {
                        isAfter[int.Parse(curInstrutcion[3])]--;
                    }
                }

                if (curInstrutcion[2] == "before")
                {
                    var curInstrutcionPos = int.Parse(curInstrutcion[0]);

                    isAfter[int.Parse(curInstrutcion[3])] =
                        curInstrutcionPos > isAfter[int.Parse(curInstrutcion[3])] ?
                        curInstrutcionPos : isAfter[int.Parse(curInstrutcion[3])];

                    if (curInstrutcionPos == 0)
                    {
                        isAfterZero[int.Parse(curInstrutcion[3])] = true;
                    }

                    if (isAfter[int.Parse(curInstrutcion[3])] ==
                       isBefore[int.Parse(curInstrutcion[3])])
                    {
                        isBefore[int.Parse(curInstrutcion[3])]++;
                    }

                    curInstrutcionPos = int.Parse(curInstrutcion[3]);

                    isBefore[int.Parse(curInstrutcion[0])] =
                        curInstrutcionPos < isAfter[int.Parse(curInstrutcion[0])] ?
                        curInstrutcionPos : isAfter[int.Parse(curInstrutcion[0])];

                    if (isAfter[int.Parse(curInstrutcion[0])] ==
                        isBefore[int.Parse(curInstrutcion[0])])
                    {
                        isAfter[int.Parse(curInstrutcion[0])]--;
                    }
                }

              
            }

            output.Sort();

            for (int element = output.Count() - 1; element >= 0; element--)
            {
                var digit = output[element];

                var afterDigit = isAfter[digit];
                
                if (afterDigit < 0)
                {
                    continue;
                }

                var digitPosition = output.IndexOf(digit);
                output.RemoveAt(digitPosition);

                var afterPosition = output.IndexOf(afterDigit);
                output.Insert(afterPosition + 1, digit);
            }

            Console.WriteLine(string.Join("", output));
        }
    }
}
