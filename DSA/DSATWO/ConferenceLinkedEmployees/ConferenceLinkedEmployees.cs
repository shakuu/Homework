using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceLinkedEmployees
{
    public class LinkedEmployee
    {
        public LinkedEmployee()
        {
            this.Merged = new HashSet<LinkedEmployee>();
        }

        public bool IsCount { get; set; }

        public bool HasCompany
        {
            get
            {
                return this.NextEmployee != null || this.PreviousEmployee != null;
            }
        }

        public LinkedEmployee NextEmployee { get; set; }

        public LinkedEmployee PreviousEmployee { get; set; }

        public HashSet<LinkedEmployee> Merged { get; set; }
    }

    public class ConferenceLinkedEmployees
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').ToArray();
            var totalEmployeeCount = int.Parse(input[0]);
            var inputLinesCount = int.Parse(input[1]);

            var employees = Enumerable.Range(0, totalEmployeeCount).Select(x => new LinkedEmployee()).ToArray();
            for (int inputLineIndex = 0; inputLineIndex < inputLinesCount; inputLineIndex++)
            {
                var nextCommand = Console.ReadLine().Split(' ');
                var employeeAIndex = int.Parse(nextCommand[0]);
                var employeeBIndex = int.Parse(nextCommand[1]);

                var employeeA = employees[employeeAIndex];
                var employeeB = employees[employeeBIndex];

                if (!employeeA.HasCompany && !employeeB.HasCompany)
                {
                    employeeA.NextEmployee = employeeB;
                    employeeB.PreviousEmployee = employeeA;
                }
                else if (employeeA.HasCompany && employeeB.HasCompany)
                {
                    employeeA.Merged.Add(employeeB);
                    employeeB.Merged.Add(employeeA);
                }
                else if (employeeA.HasCompany)
                {
                    var employeeANext = employeeA.NextEmployee;
                    employeeA.NextEmployee = employeeB;
                    employeeB.NextEmployee = employeeANext;
                }
                else if (employeeB.HasCompany)
                {
                    var employeeBNext = employeeB.NextEmployee;
                    employeeB.NextEmployee = employeeA;
                    employeeA.NextEmployee = employeeBNext;
                }
            }

            var emplyeesCounts = new List<int>();
            for (int employeeIndex = 0; employeeIndex < totalEmployeeCount; employeeIndex++)
            {
                var currentEmployee = employees[employeeIndex];
                if (currentEmployee.IsCount)
                {
                    continue;
                }

                var currentEmployeeCount = 1;

                var employeeStack = new Stack<LinkedEmployee>();
                employeeStack.Push(currentEmployee);

                while (employeeStack.Count > 0)
                {
                    var nextEmployeeToEvaluate = employeeStack.Pop();
                    if (nextEmployeeToEvaluate.IsCount)
                    {
                        continue;
                    }

                    nextEmployeeToEvaluate.IsCount = true;
                    foreach (var employee in nextEmployeeToEvaluate.Merged)
                    {
                        employeeStack.Push(employee);
                    }

                    var previousEmployee = nextEmployeeToEvaluate.PreviousEmployee;
                    while (previousEmployee != null)
                    {
                        if (previousEmployee.IsCount)
                        {
                            continue;
                        }

                        currentEmployeeCount++;
                        previousEmployee.IsCount = true;
                        foreach (var employee in previousEmployee.Merged)
                        {
                            employeeStack.Push(employee);
                        }

                        previousEmployee = previousEmployee.PreviousEmployee;
                    }

                    var nextEmployee = nextEmployeeToEvaluate.NextEmployee;
                    while (nextEmployee != null)
                    {
                        if (nextEmployee.IsCount)
                        {
                            continue;
                        }

                        currentEmployeeCount++;
                        nextEmployee.IsCount = true;
                        foreach (var employee in nextEmployee.Merged)
                        {
                            employeeStack.Push(employee);
                        }

                        nextEmployee = nextEmployee.NextEmployee;
                    }
                }

                emplyeesCounts.Add(currentEmployeeCount);
            }

            long result = 0;
            var remainingEmployees = totalEmployeeCount;
            foreach (var employeeCount in emplyeesCounts)
            {
                remainingEmployees -= employeeCount;
                result += employeeCount * remainingEmployees;
            }

            while (remainingEmployees > 0)
            {
                result += --remainingEmployees;
            }

            Console.WriteLine(result);
        }
    }
}
