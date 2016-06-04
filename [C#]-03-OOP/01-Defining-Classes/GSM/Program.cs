using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM
{
    class Program
    {
        static void Main(string[] args)
        {
            var mygsm = new GSM("apple", "iphone");
            mygsm.CallHistory.Add(new Call( DateTime.Now, DateTime.Now.AddMinutes(4.5), "00000"));

            Console.WriteLine(mygsm.Calls); 

        }
    }
}
