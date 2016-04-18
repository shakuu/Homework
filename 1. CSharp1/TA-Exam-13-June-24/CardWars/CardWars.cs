using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardWars
{
    class CardWars
    {
        class Player
        {
            public int currHand = 0;
            public int score = 0;
            public int gamesWon = 0;
            public int zCounter = 0;
            public bool hasX = false;
            public string currCard = "";
        }

        static void Main(string[] args)
        {
            //get scoring
            string Cards = "2 3 4 5 6 7 8 9 10 A J Q K Y Z X";
            string Points = "10 9 8 7 6 5 4 3 2 1 11 12 13 -200 2 50";
            string[] cardsToDictionary = Cards.Split(' ');
            string[] pointsToDictionary = Points.Split(' ');

            Dictionary<string, int> Score = new Dictionary<string, int>();
            for (int i = 0; i < cardsToDictionary.Length; i++)
            {
                Score.Add(cardsToDictionary[i],
                   Convert.ToInt32(pointsToDictionary[i]));
            }

            //Console.WriteLine( Score["2"]);
            //input
            int matchLength = int.Parse(Console.ReadLine());

            Player Pesho = new Player();
            Player Gosho = new Player();

            for (int round = 0; round < matchLength; round++)
            {
                //reset
                Pesho.zCounter = 0;Pesho.hasX = false;
                Gosho.zCounter = 0;Gosho.hasX = false;
                //Pesho goes 1st
                for (int i = 0; i < 3; i++)
                {
                    Pesho.currCard = Console.ReadLine();
                    if (Pesho.currCard == "X")
                    {
                        Pesho.hasX = true;
                    }
                    else if (Pesho.currCard == "Z")
                    {
                        Pesho.zCounter++;
                    }
                    else
                    {
                        Pesho.currHand += Score[Pesho.currCard];
                    }
                }
                //Gosho 2nd
                for (int i = 0; i < 3; i++)
                {
                    Gosho.currCard = Console.ReadLine();
                    if (Gosho.currCard == "X")
                    {
                        Gosho.hasX = true;
                    }
                    else if (Gosho.currCard == "Z")
                    {
                        Gosho.zCounter++;
                    }
                    else
                    {
                        Gosho.currHand += Score[Gosho.currCard];
                    }
                }
                //apply zCounter
                Pesho.currHand *= (int)Math.Pow(2, Pesho.zCounter);
                Gosho.currHand *= (int)Math.Pow(2, Gosho.zCounter);
                //Determine current round winner
                ///check for X cards first
                if (Pesho.hasX && Gosho.hasX)
                {
                    Pesho.score += Score["X"];
                    Gosho.score += Score["X"];
                }
                else if (Pesho.hasX && !Gosho.hasX)
                {
                    Console.WriteLine("X card drawn! Player one wins the match!");
                    return;
                }
                else if (!Pesho.hasX && Gosho.hasX)
                {
                    Console.WriteLine("X card drawn! Player two wins the match!");
                    return;
                }
                else if (Pesho.currHand > Gosho.currHand)
                {
                    Pesho.gamesWon++;
                    Pesho.score += Pesho.currHand;
                }
                else if (Pesho.currHand < Gosho.currHand)
                {
                    Gosho.gamesWon++;
                    Gosho.score += Gosho.currHand;
                }
                else if (Pesho.currHand == Gosho.currHand)
                {
                    //do nothing
                }
            }
            //get winner and print
            if (Pesho.score>Gosho.score)
            {
                Console.WriteLine("First player wins!\nScore: {0}\nGames Won: {1}",
                    Pesho.score, Pesho.gamesWon);
            }
            else if(Pesho.score<Gosho.score)
            {
                Console.WriteLine("Second player wins!\nScore: {0}\nGames Won: {1}",
                    Gosho.score, Gosho.gamesWon);
            }
            else if (Pesho.score==Gosho.score)
            {
                Console.WriteLine("It's a tie!\nScore: {0}",
                    Pesho.score);
            }
        }
    }
}
