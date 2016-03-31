using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifyBit
{
    class ModifyBit
    {
        static void Main()
        {
            //INPUT
            long number = long.Parse(Console.ReadLine());
            int position = int.Parse(Console.ReadLine());
            int newValue = int.Parse(Console.ReadLine());
            //OUTPUT
            string tempStr = Convert.ToString(number, 2);      
            for ( int i = tempStr.Length; i< 65; i++) // possible input range 0-64
            { tempStr = "0" + tempStr; }
            tempStr = tempStr.Insert(tempStr.Length - (position + 1), newValue.ToString());
            tempStr = tempStr.Remove(tempStr.Length-(position + 1), 1);
            Console.WriteLine(Convert.ToInt64(tempStr, 2));
        }
    }
}
