using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayCard
{
    class PlayCard
    {
        static void Main()
        {
            string playCard = Console.ReadLine();
            string allCards = "2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A";

            string[] Cards = allCards.Split(',');
            string YesNo = "no";

            foreach (string c in Cards)
            {
                if (c.TrimStart(' ') == playCard)
                {
                    YesNo = "yes";
                }
            }
            Console.WriteLine("{0} {1}",YesNo, playCard);
        }
    }
}
