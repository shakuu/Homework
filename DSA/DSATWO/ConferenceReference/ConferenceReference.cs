using System;
using System.Collections.Generic;
using System.Linq;

namespace Conference
{
    public class ConferenceExam
    {
        public class Company
        {
            public Company(int employeeCount)
            {
                this.EmployeeCount = employeeCount;
            }

            public int EmployeeCount { get; set; }
        }

        public static void Main()
        {
            var companyDependencies = new Dictionary<Company, HashSet<int>>();

            var input = Console.ReadLine().Split(' ').ToArray();
            var devCount = int.Parse(input[0]);
            var inputLinesCount = int.Parse(input[1]);

            var companies = new List<Company>();
            companies.Add(new Company(-1));

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
                    companies.Add(new Company(2));
                }
                else if (empACompanyIndex != 0 && empBCompanyIndex != 0)
                {
                    var companyB = companies[empBCompanyIndex];
                    var companyA = companies[empACompanyIndex];
                    if (companyA == companyB)
                    {
                        continue;
                    }

                    companyB.EmployeeCount += companyA.EmployeeCount;
                    companies[empACompanyIndex] = companyB;

                    var companyIndexExists = companyDependencies.ContainsKey(companyB);
                    if (!companyIndexExists)
                    {
                        companyDependencies.Add(companyB, new HashSet<int>());
                    }

                    companyDependencies[companyB].Add(empACompanyIndex);
                    companyDependencies[companyB].Add(empBCompanyIndex);

                    if (companyDependencies.ContainsKey(companyA))
                    {
                        foreach (var index in companyDependencies[companyA])
                        {
                            companies[index] = companyB;
                            companyDependencies[companyB].Add(index);
                        }
                        
                        companyDependencies.Remove(companyA);
                    }
                }
                else if (empACompanyIndex == 0 && empBCompanyIndex != 0)
                {
                    devs[empAIndex] = empBCompanyIndex;
                    companies[empBCompanyIndex].EmployeeCount++;
                }
                else if (empBCompanyIndex == 0 && empACompanyIndex != 0)
                {
                    devs[empBIndex] = empACompanyIndex;
                    companies[empACompanyIndex].EmployeeCount++;
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            //foreach (var dev in devs)
            //{
            //    if (dev == 0)
            //    {
            //        companies.Add(1);
            //    }
            //}

            var eligibleCompanies = new HashSet<Company>();
            foreach (var company in companies)
            {
                if (company.EmployeeCount <= 0)
                {
                    continue;
                }

                eligibleCompanies.Add(company);
            }

            // long == 100
            long result = 0;
            var remainingEmployees = devCount;
            foreach (var company in eligibleCompanies)
            {
                remainingEmployees -= company.EmployeeCount;
                result += company.EmployeeCount * remainingEmployees;
            }

            while (remainingEmployees > 0)
            {
                result += --remainingEmployees;
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