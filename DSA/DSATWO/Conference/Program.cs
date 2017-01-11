using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conference
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').ToArray();
            var devCount = int.Parse(input[0]);
            var inputLinesCount = int.Parse(input[1]);

            var companies = new List<int>();
            companies.Add(-1);

            var nextCompanyIndex = 1;
            var devs = new int[devCount];
            for (int i = 0; i < inputLinesCount; i++)
            {
                var nextCommand = Console.ReadLine().Split(' ');
                var empA = int.Parse(nextCommand[0]);
                var empB = int.Parse(nextCommand[1]);

                var empACompanyIndex = devs[empA];
                var empBCompanyIndex = devs[empB];

                if (empACompanyIndex == 0 && empBCompanyIndex == 0)
                {
                    companies.Add(2);
                    devs[empA] = nextCompanyIndex;
                    devs[empB] = nextCompanyIndex;
                    nextCompanyIndex++;
                }
                else if (empACompanyIndex != 0 && empBCompanyIndex != 0)
                {
                    for (int k = 0; k < devs.Length; k++)
                    {
                        if (devs[k] == empACompanyIndex)
                        {
                            devs[k] = empBCompanyIndex;
                            companies[empBCompanyIndex]++;
                        }
                    }

                    companies[empACompanyIndex] = -1;
                }
                else if (empACompanyIndex == 0)
                {
                    devs[empA] = devs[empB];
                    companies[devs[empB]]++;
                }
                else if (empBCompanyIndex == 0)
                {
                    devs[empB] = devs[empA];
                    companies[devs[empA]]++;
                }
            }

            foreach (var dev in devs)
            {
                if (dev == 0)
                {
                    companies.Add(1);
                }
            }

            companies.Sort();

            var toBreak = false;
            var initial = devCount;
            var result = 0;
            for (int i = 1; i < companies.Count; i++)
            {
                var currentValue = companies[i];
                if (currentValue < 0)
                {
                    continue;
                }

                while (currentValue > 0)
                {
                    initial -= currentValue;
                    if (initial < 0)
                    {
                        initial += currentValue;
                        result += initial;

                        toBreak = true;
                        break;
                    }

                    result += initial;
                    currentValue--;
                }

                if (toBreak)
                {
                    break;
                }
            }

            Console.WriteLine(result);
        }
    }
}
