using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintADeck
{
    class PrintADeck
    {
        static void Main()
        {
            string playerCard = (Console.ReadLine()).ToUpper();
            //char playerCard = char.Parse((Console.ReadLine()).Substring(0,1));

            string allCards = "2 3 4 5 6 7 8 9 10 J Q K A";
            string allSuits = "spades clubs hearts diamonds";

            string[] Cards = allCards.Split(' ');
            string[] Suits = allSuits.Split(' ');

            for (int cardIndex = 0; cardIndex < Cards.Length; cardIndex++)
            {
                for (int suitIndex = 0; suitIndex < Suits.Length; suitIndex++)
                {
                    Console.Write("{0} of {1}", Cards[cardIndex], Suits[suitIndex]);
                    if (suitIndex != Suits.Length - 1)
                    { Console.Write(", "); }
                }
                Console.Write("\n");

                if (playerCard.ToString() == Cards[cardIndex])
                { return; }
            }

        }
    }
}
