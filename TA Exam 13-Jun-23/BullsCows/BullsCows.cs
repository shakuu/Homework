using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsCows
{
    class BullsCows
    {
        static void Main()
        {
            //input
            string inputSecretNumber = Console.ReadLine();
            int inputBulls = int.Parse(Console.ReadLine());
            int inputCows = int.Parse(Console.ReadLine());

            //vars
            int currBulls = 0;
            int currCows = 0;
            string counter = "1111";
            string currNumber = counter;
            string SecretNumber;
            while ( counter != "9999")
            {
                SecretNumber = inputSecretNumber;
                currNumber = counter;
                currBulls = 0;
                currCows = 0;
                //test for Bulls 
                for (int i = 0; i<4; i++)
                {
                    if (currNumber.Substring(i, 1) == SecretNumber.Substring(i,1))
                    {
                        currBulls++;
                        currNumber = currNumber.Insert(0, currNumber.Substring(i, 1));
                        currNumber = currNumber.Remove(i + 1, 1);
                        SecretNumber = SecretNumber.Insert(0, SecretNumber.Substring(i, 1));
                        SecretNumber = SecretNumber.Remove(i + 1, 1);

                    }
                }

                //test for Cows 
                for (int i = 0+currBulls; i<4; i++)
                {
                    for (int p = 0+currBulls; p<4; p++)
                    {
                        if (currNumber.Substring(i, 1) == SecretNumber.Substring(p, 1)
                            && i!=p)
                        {
                            currCows++;
                        }
                    }
                }

                if ( currBulls==inputBulls && currCows==inputCows)
                {
                    Console.Write(counter + " ");
                }

                //increment the number
                counter =( int.Parse(counter) + 1).ToString();
                //get rid of 0s
                while(counter.Contains("0"))
                {
                    counter =counter.Insert(counter.IndexOf("0"), "1");
                    counter = counter.Remove(counter.IndexOf("0"), 1);
                }
            }
        }
    }
}
