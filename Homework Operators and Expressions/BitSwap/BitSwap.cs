using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitSwap
{
    class BitSwap
    {
        static void Main(string[] args)
        {
            //INPUT
            uint number = uint.Parse(Console.ReadLine());
            int indexP = int.Parse(Console.ReadLine());
            int indexQ = int.Parse(Console.ReadLine());
            int indexK = int.Parse(Console.ReadLine());
            //OUTPUT
            //FORMAT INPUT STRING
            string toPrint = Convert.ToString(number, 2);
            for (int i = toPrint.Length; i < 32; i++)
            { toPrint = "0" + toPrint; }

            string tempStrP = "";
            string tempStrQ = "";
            for ( int i = 0; i < indexK; i++)
            {
                tempStrP =  toPrint.ElementAt
                    (toPrint.Length- (indexP+i+1)) +tempStrP;
                tempStrQ = toPrint.ElementAt
                    (toPrint.Length - (indexQ + i + 1)) + tempStrQ;
            }
     
            toPrint = toPrint.Insert(toPrint.Length - (indexQ + indexK ), tempStrP); // insert string P to position Q
            toPrint = toPrint.Remove(toPrint.Length - (indexQ  + indexK) , indexK); // remove strQ
            toPrint = toPrint.Insert(toPrint.Length - (indexP + indexK ), tempStrQ); // insert string Q to pos P
            toPrint = toPrint.Remove(toPrint.Length - (indexP + indexK) , indexK); // remove strP   
            
            Console.WriteLine(Convert.ToInt64(toPrint, 2)); 
        }
    }
}
