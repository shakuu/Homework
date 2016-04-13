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
            int MitkoHad = 0;
            int VladkoHad = 0;

            int currOddNumber = 0;
            string currDrunkenNumber = "";
            for (int i = 0; i< numberOfRounds; i++)
            {
                currOddNumber = 0;
                currDrunkenNumber = Console.ReadLine();
                //remove Zeroes
                while ( currDrunkenNumber.Substring(0,1) == "0")
                {
                    currDrunkenNumber = currDrunkenNumber.Remove(0, 1);
                }
                //check ODD len
                if ( currDrunkenNumber.Length%2 != 0)
                {
                    currOddNumber = Convert.ToInt32( currDrunkenNumber.Substring
                        ((currDrunkenNumber.Length - 1) / 2, 1));
                    currDrunkenNumber = currDrunkenNumber.Remove
                        ((currDrunkenNumber.Length - 1) / 2, 1);
                        
                }
                //Mitko
                for (int p = 0; p < currDrunkenNumber.Length/2; p++)
                {
                    MitkoHad += int.Parse( currDrunkenNumber.Substring(p, 1));
                }
                //Vladko
                for ( int p = currDrunkenNumber.Length/2; p< currDrunkenNumber.Length; p++)
                {
                    VladkoHad += int.Parse(currDrunkenNumber.Substring(p, 1));
                }

                //If odd
                if ( currOddNumber!= 0)
                {
                    MitkoHad += currOddNumber;
                    VladkoHad += currOddNumber;
                }
            }

            //OUTPUT
            if ( MitkoHad>VladkoHad)
            {
                Console.WriteLine("M {0}", MitkoHad- VladkoHad);
            }
            if (MitkoHad < VladkoHad)
            {
                Console.WriteLine("V {0}", VladkoHad- MitkoHad);
            }
            if (MitkoHad == VladkoHad)
            {
                Console.WriteLine("No {0}", MitkoHad + VladkoHad);
            }
        }
    }
}
