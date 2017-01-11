using System;
using System.Collections.Generic;
using System.Linq;

namespace Conference
{
    public class ConferenceExam
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').ToArray();
            var devCount = int.Parse(input[0]);
            var inputLinesCount = int.Parse(input[1]);

            var companies = new List<int>();
            companies.Add(-1);

            var devs = new int[devCount];
            for (int i = 0; i < inputLinesCount; i++)
            {
                var nextCommand = Console.ReadLine().Split(' ');
                var empAIndex = int.Parse(nextCommand[0]);
                var empBIndex = int.Parse(nextCommand[1]);

                var empACompanyIndex = devs[empAIndex];
                var empBCompanyIndex = devs[empBIndex];

                if (empACompanyIndex == 0 && empBCompanyIndex == 0)
                {
                    var nextCompanyIndex = companies.Count;
                    devs[empAIndex] = nextCompanyIndex;
                    devs[empBIndex] = nextCompanyIndex;
                    companies.Add(2);
                }
                else if (empACompanyIndex != 0 && empBCompanyIndex != 0)
                {
                    var reassignedEmployeesCounter = 0;
                    for (int k = 0; k < devs.Length; k++)
                    {
                        if (devs[k] == empACompanyIndex)
                        {
                            devs[k] = empBCompanyIndex;
                            reassignedEmployeesCounter++;
                        }
                    }

                    companies[empBCompanyIndex] += reassignedEmployeesCounter;
                    companies[empACompanyIndex] -= reassignedEmployeesCounter;
                }
                else if (empACompanyIndex == 0 && empBCompanyIndex != 0)
                {
                    devs[empAIndex] = empBCompanyIndex;
                    companies[empBCompanyIndex]++;
                }
                else if (empBCompanyIndex == 0 && empACompanyIndex != 0)
                {
                    devs[empBIndex] = empACompanyIndex;
                    companies[empACompanyIndex]++;
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            foreach (var dev in devs)
            {
                if (dev == 0)
                {
                    companies.Add(1);
                }
            }

            // long == 100
            long result = 0;
            var multiplier = devCount;
            for (int nextCompanyIndex = 1; nextCompanyIndex < companies.Count; nextCompanyIndex++)
            {
                var employeeCount = companies[nextCompanyIndex];
                if (employeeCount <= 0)
                {
                    continue;
                }

                multiplier -= employeeCount;
                result += employeeCount * multiplier;
            }

            //var result = 0;
            //for (int firstIndex = 0; firstIndex < companies.Count; firstIndex++)
            //{
            //    if (companies[firstIndex] < 0)
            //    {
            //        continue;
            //    }

            //    for (int secondIndex = firstIndex + 1; secondIndex < companies.Count; secondIndex++)
            //    {
            //        if (companies[secondIndex] < 0)
            //        {
            //            continue;
            //        }

            //        var nextValue = companies[firstIndex] * companies[secondIndex];
            //        result += nextValue;
            //    }
            //}


            //companies.Sort();

            //var toBreak = false;
            //var initial = devCount;
            //var result = 0;
            //for (int i = 1; i < companies.Count; i++)
            //{
            //    var currentValue = companies[i];
            //    if (currentValue < 0)
            //    {
            //        continue;
            //    }

            //    while (currentValue > 0)
            //    {
            //        initial -= currentValue;
            //        if (initial < 0)
            //        {
            //            initial += currentValue;
            //            result += initial;

            //            toBreak = true;
            //            break;
            //        }

            //        result += initial;
            //        currentValue--;
            //    }

            //    if (toBreak)
            //    {
            //        break;
            //    }
            //}

            Console.WriteLine(result);
        }
    }
}
