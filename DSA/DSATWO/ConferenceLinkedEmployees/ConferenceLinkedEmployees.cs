using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceLinkedEmployees
{
    public class Company
    {
        public LinkedEmployee FirstEmployee { get; set; }

        public LinkedEmployee LastEmployee { get; set; }

        public int EmployeesCount { get; set; }
    }

    public class LinkedEmployee
    {
        public bool HasCompany { get; set; }

        public LinkedEmployee NextEmployee { get; set; }

        public LinkedEmployee PreviousEmployee { get; set; }
    }

    public class ConferenceLinkedEmployees
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').ToArray();
            var employeeCount = int.Parse(input[0]);
            var inputLinesCount = int.Parse(input[1]);

            var employees = new LinkedEmployee[employeeCount];
            for (int inputLineIndex = 0; inputLineIndex < inputLinesCount; inputLineIndex++)
            {
                var nextCommand = Console.ReadLine().Split(' ');
                var employeeAIndex = int.Parse(nextCommand[0]);
                var employeeBIndex = int.Parse(nextCommand[1]);

                var employeeA = employees[employeeAIndex];
                var employeeB = employees[employeeBIndex];

                if (!employeeA.HasCompany && !employeeB.HasCompany)
                {
                    employeeA.HasCompany = true;
                    employeeB.HasCompany = true;

                    employeeA.NextEmployee = employeeB;
                    employeeB.PreviousEmployee = employeeA;
                }
                else if (employeeA.HasCompany && employeeB.HasCompany)
                {
                    var lastEmployeeAColeague = employeeA;
                    while (lastEmployeeAColeague != null)
                    {
                        lastEmployeeAColeague = lastEmployeeAColeague.NextEmployee;
                    }

                    var firstEmployeeBColeague = employeeB;
                    while (firstEmployeeBColeague != null)
                    {
                        firstEmployeeBColeague = firstEmployeeBColeague.PreviousEmployee;
                    }

                    lastEmployeeAColeague.NextEmployee = firstEmployeeBColeague;
                    firstEmployeeBColeague.PreviousEmployee = lastEmployeeAColeague;
                }
                else if (employeeA.HasCompany)
                {
                    var employeeANext = employeeA.NextEmployee;
                    employeeA.NextEmployee = employeeB;
                    employeeB.NextEmployee = employeeANext;
                    employeeB.HasCompany = true;
                }
                else if (employeeB.HasCompany)
                {
                    var employeeBNext = employeeB.NextEmployee;
                    employeeB.NextEmployee = employeeA;
                    employeeA.NextEmployee = employeeBNext;
                    employeeA.HasCompany = true;
                }
            }
        }
    }
}
