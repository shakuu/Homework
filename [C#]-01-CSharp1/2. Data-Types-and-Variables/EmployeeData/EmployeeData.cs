using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData
{
    class EmployeeData
    {
        static void Main(string[] args)
        {
            Employee toPrint = new Employee();
            toPrint.FirstName = "h";
            toPrint.LastName = "t";
            toPrint.Age = 10;
            toPrint.IsFemale = true;
            toPrint.PersonalID = 8306112507;
            toPrint.UniqueNumber = 1234;

            Console.Write(toPrint.ToString());
        }
    }

    class Employee
    {
        string firstName;
        string lastName;
        byte isAge;
        bool isFemale;
        long personalID;
        short uniqueNumber;
        string uniquePrefix = "2756";

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public byte Age
        {
            get { return isAge; }
            set { isAge = value; }
        }

        public bool IsFemale
        {
            get { return isFemale; }
            set { isFemale = value; }
        }

        public long PersonalID
        {
            get { return personalID; }
            set { personalID = value; }
        }

        public short UniqueNumber
        {
            get { return uniqueNumber; }
            set { uniqueNumber = value; }
        }

        public override string ToString()
        {
            if (isFemale == true)
            {
                return firstName + "\n" + lastName + "\n" +
                  isAge + "\n" + "Female" + "\n" +
                  personalID + "\n" +
                  uniquePrefix + uniqueNumber;
            }
            else
            {
                return firstName + "\n" + lastName + "\n" +
                  isAge + "\n" + "Male" + "\n" +
                  personalID + "\n" +
                  uniquePrefix + uniqueNumber;
            }  
        }
    }
}
