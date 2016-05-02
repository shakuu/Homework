using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrunkenNumbers
{
    class DrunkenNumbers
    {
        static void Main()
        {
            int numberOfRounds = int.Parse(Console.ReadLine());
            long MitkoHad = 0;
            long VladkoHad = 0;

            int currOddNumber = 0;
            string currDrunkenNumber = "";
            for (int i = 0; i < numberOfRounds; i++)
            {
                currOddNumber = 0;
                currDrunkenNumber = Console.ReadLine();
                //remove non Digits
                for (int p = 0; p < currDrunkenNumber.Length; p++)
                {
                    try
                    {
                        Convert.ToInt32(currDrunkenNumber.Substring(p, 1));
                    }
                    catch (FormatException)
                    {
                        currDrunkenNumber = currDrunkenNumber.Remove(p, 1);
                    }

                }
                //remove Zeroes
                while (currDrunkenNumber.Substring(0, 1) == "0")
                {
                    currDrunkenNumber = currDrunkenNumber.Remove(0, 1);
                    if (currDrunkenNumber == "") { break; }
                }
                
                //get first 9
                if (currDrunkenNumber.Length > 9)
                {
                    currDrunkenNumber = currDrunkenNumber.Substring(0, 9);
                }
                //check ODD len
                if (currDrunkenNumber.Length % 2 != 0)
                {
                    currOddNumber = Convert.ToInt32(currDrunkenNumber.Substring
                        ((currDrunkenNumber.Length - 1) / 2, 1));
                    currDrunkenNumber = currDrunkenNumber.Remove
                        ((currDrunkenNumber.Length - 1) / 2, 1);

                }
                //Mitko
                for (int p = 0; p < currDrunkenNumber.Length / 2; p++)
                {
                    try
                    {
                        MitkoHad += int.Parse(currDrunkenNumber.Substring(p, 1));
                    }
                    catch(FormatException)
                    {
                        MitkoHad += 0;
                    }
                }
                //Vladko
                for (int p = currDrunkenNumber.Length / 2; p < currDrunkenNumber.Length; p++)
                {
                    try
                    {
                        VladkoHad += int.Parse(currDrunkenNumber.Substring(p, 1));
                    }
                    catch(FormatException)
                    {
                        VladkoHad += 0;
                    }
                }

                //If odd
                if (currOddNumber != 0)
                {
                    MitkoHad += currOddNumber;
                    VladkoHad += currOddNumber;
                }
            }

            //OUTPUT
            if (MitkoHad > VladkoHad)
            {
                Console.WriteLine("M {0}", MitkoHad - VladkoHad);
            }
            if (MitkoHad < VladkoHad)
            {
                Console.WriteLine("V {0}", VladkoHad - MitkoHad);
            }
            if (MitkoHad == VladkoHad)
            {
                Console.WriteLine("No {0}", MitkoHad + VladkoHad);
            }
        }
    }
}
