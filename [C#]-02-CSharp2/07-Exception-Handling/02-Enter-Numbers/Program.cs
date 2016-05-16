using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Enter_Numbers
{
    class Program
    {
        static void Main()
        {
            var exceptionMessage = "Exception";

            var arraySize = 10;
            var start = 0;
            var end = 100;


            try
            {
                throw new Exception(exceptionMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
